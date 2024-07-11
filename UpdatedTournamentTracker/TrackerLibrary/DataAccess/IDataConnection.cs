using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel prize);
        void CreatePerson(PersonModel person);
        void CreateTeam(TeamModel team);
        void CreateTournament(TournamentModel model);
        void UpdateTournament(MatchupModel model);
        void CompleteTournament(TournamentModel tournament);
        List<TeamModel> GetTeams_All();
        List<PersonModel> GetPerson_All();
        List<TournamentModel> GetTournament_All();
    }
}
