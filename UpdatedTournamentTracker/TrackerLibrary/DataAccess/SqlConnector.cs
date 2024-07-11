using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        public void CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellPhoneNumber);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[spPeople_Insert]", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@Id");
            }
        }
        public void CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[spPrizes_Insert]", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@Id");
            }
        }
        public void CreateTeam(TeamModel team)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", team.TeamName);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[spTeams_Insert]", p, commandType: CommandType.StoredProcedure);

                team.Id = p.Get<int>("@Id");

                foreach(PersonModel tm in team.TeamMembers)
                {
                    var pa = new DynamicParameters();
                    pa.Add("@TeamId", team.Id);
                    pa.Add("@PersonId", tm.Id);

                    connection.Execute("[dbo].[spTeamMembers_Insert]", pa, commandType: CommandType.StoredProcedure);
                }
            }
        }
        public void CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                SaveTournament(connection,model);

                SaveTournamentPrizes(connection, model);

                SaveTournamentEntries(connection, model);

                SaveTournamentRounds(connection, model);

                TournamentLogic.UpdateTournamentResults(model);
            }
        }
        private void SaveTournament(IDbConnection connection,TournamentModel model)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("[dbo].[spTournaments_Insert]", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@Id");
        }
        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
        {
            foreach (PrizeModel pz in model.Prizes)
            {
                var pa = new DynamicParameters();
                pa.Add("@TournamentId", model.Id);
                pa.Add("@PrizeId", pz.Id);
                pa.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[spTournamentPrizes_Insert]", pa, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
        {
            foreach (TeamModel tm in model.EnteredTeams)
            {
                var pa = new DynamicParameters();
                pa.Add("@TournamentId", model.Id);
                pa.Add("@TeamId", tm.Id);
                pa.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[spTournamentEntries_Insert]", pa, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach(MatchupModel m in round)
                {
                    var pa = new DynamicParameters();
                    pa.Add("@TournamentId", model.Id);
                    pa.Add("@MatchupRound", m.MatchupRound);
                    pa.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("[dbo].[spMatchups_Insert]", pa, commandType: CommandType.StoredProcedure);

                    m.Id = pa.Get<int>("@Id");

                    foreach(MatchupEntryModel entry in m.Entries)
                    {
                        var paa = new DynamicParameters();
                        paa.Add("@MatchupId", m.Id);
                        if(entry.ParentMatchup == null)
                        {
                            paa.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            paa.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                        }
                        if(entry.TeamCompeting == null)
                        {
                            paa.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            paa.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        }
                        
                        paa.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("[dbo].[spMatchupEntries_Insert]", paa, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output = new List<PersonModel>();
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                output = connection.Query<PersonModel>("[dbo].[spPeople_GetAll]").ToList();
            }
            return output;
        }
        public List<TeamModel> GetTeams_All()
        {
            List<TeamModel> output = new List<TeamModel>();
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                output = connection.Query<TeamModel>("[dbo].[spTeams_GetAll]").ToList();
                foreach(TeamModel tm in output)
                {
                    var pa = new DynamicParameters();
                    pa.Add("@TeamId", tm.Id);
                    
                    tm.TeamMembers = connection.Query<PersonModel>("[dbo].[spTeamMembers_GetByTeam]",pa, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }
        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel> output = new List<TournamentModel>();
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                output = connection.Query<TournamentModel>("[dbo].[spTournaments_GetAll]").ToList();
                foreach (TournamentModel t in output)
                {
                    // Populate Prizes
                    var p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    t.Prizes = connection.Query<PrizeModel>("[dbo].[spPrizes_GetByTournament]", p, commandType: CommandType.StoredProcedure).ToList();

                    // Populate Teams
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    t.EnteredTeams = connection.Query<TeamModel>("[dbo].[spTeam_getByTournament]", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (TeamModel team in t.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamId", team.Id);

                        team.TeamMembers = connection.Query<PersonModel>("[dbo].[spTeamMembers_GetByTeam]", p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    List<MatchupModel> matchups = connection.Query<MatchupModel>("[dbo].[spMatchups_GetByTournament]", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (MatchupModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);

                        m.Entries = connection.Query<MatchupEntryModel>("[dbo].[spMatchupEntries_GetByMatchup]", p, commandType: CommandType.StoredProcedure).ToList();

                        List<TeamModel> allTeams = GetTeams_All();

                        if (m.WinnerId > 0)
                        {
                            m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                        }

                        foreach (var me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }

                            if (me.ParentMatchupId > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                            }
                        }
                    }

                    // List<List<MatchupModel>>
                    List<MatchupModel> currRow = new List<MatchupModel>();
                    int currRound = 1;

                    foreach (MatchupModel m in matchups)
                    {
                        if (m.MatchupRound > currRound)
                        {
                            t.Rounds.Add(currRow);
                            currRow = new List<MatchupModel>();
                            currRound += 1;
                        }

                        currRow.Add(m);
                    }

                    t.Rounds.Add(currRow);
                }
            }
            return output;
        }
        public void UpdateTournament(MatchupModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                if (model.Winner != null)
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", model.Id);
                    p.Add("@WinnerId", model.Winner.Id);

                    connection.Execute("[dbo].[spMatchups_Update]", p, commandType: CommandType.StoredProcedure); 
                }

                foreach (MatchupEntryModel me in model.Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        var pa = new DynamicParameters();
                        pa.Add("@Id", me.Id);
                        pa.Add("@TeamCompetingId", me.TeamCompeting.Id);
                        pa.Add("@Score", me.Score);

                        connection.Execute("[dbo].[spMatchupEntries_Update]", pa, commandType: CommandType.StoredProcedure); 
                    }
                }
            }
        }

        public void CompleteTournament(TournamentModel tournament)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnectionString("Sql")))
            {
                var pa = new DynamicParameters();
                pa.Add("@Id", tournament.Id);

                connection.Execute("[dbo].[spTournaments_Complete]", pa, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
