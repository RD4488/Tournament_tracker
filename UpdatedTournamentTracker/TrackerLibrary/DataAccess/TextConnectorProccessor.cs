using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public static class TextConnectorProccessor
    {
        public static string FullFilePath(this string filename)
        {
            return $"{GlobalConfig.GetConnectionString("Text")}\\{filename}";
        }
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel
                {
                    Id = int.Parse(cols[0]),
                    PlaceNumber = int.Parse(cols[1]),
                    PlaceName = cols[2],
                    PrizeAmount = decimal.Parse(cols[3]),
                    PrizePercentage = double.Parse(cols[4])
                };

                output.Add(p);
            }

            return output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel
                {
                    Id = int.Parse(cols[0]),
                    FirstName = cols[1],
                    LastName = cols[2],
                    EmailAddress = cols[3],
                    CellPhoneNumber = cols[4]
                };

                output.Add(p);
            }

            return output;
        }
        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TournamentModel p = new TournamentModel();
                p.Id = int.Parse(cols[0]);
                p.TournamentName = cols[1];
                p.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split("|");

                foreach (string id in teamIds)
                {
                    p.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                if (cols[4].Length > 0)
                {
                    string[] prizesIds = cols[4].Split("|");

                    foreach (string id in prizesIds)
                    {
                        p.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    }
                }

                string[] rounds = cols[5].Split("|");
                
                foreach (var round in rounds)
                {
                    string[] msText = round.Split("^");
                    List<MatchupModel> ms = new List<MatchupModel>();
                    foreach (var matchupmodelTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupmodelTextId)).First());
                    }
                    p.Rounds.Add(ms);
                }

                output.Add(p);
            }

            return output;
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> persons = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel p = new TeamModel();
                p.Id = int.Parse(cols[0]);
                p.TeamName = cols[1];

                string[] perosonId = cols[2].Split("|");

                foreach(string id in perosonId)
                {
                    p.TeamMembers.Add(persons.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(p);
            }

            return output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
        }
        public static void SaveToPeopleFile(this List<PersonModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellPhoneNumber}");
            }

            File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
        }
        public static void SaveToTeamFile(this List<TeamModel> models)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel p in models)
            {
                lines.Add($"{p.Id},{p.TeamName},{ConvertPeopleListToString(p.TeamMembers)}");
            }

            File.WriteAllLines(GlobalConfig.TeamFile.FullFilePath(), lines);
        }
        public static void SaveToTournamentFile(this List<TournamentModel> models)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel p in models)
            {
                lines.Add($"{p.Id},{p.TournamentName},{p.EntryFee},{ConvertTeamListToString(p.EnteredTeams)},{ConvertPrizeListToString(p.Prizes)},{ConvertRoundListToString(p.Rounds)}");
            }

            File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
        }
        public static void SaveRoundsToFile(this TournamentModel model)
        {
            foreach(List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.SaveMatchupsToFile();
                }
            }
        }
        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> input)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string line in input)
            {
                string[] cols = line.Split(',');

                MatchupEntryModel p = new MatchupEntryModel();
                p.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    p.TeamCompeting = null;
                }
                else
                {
                    p.TeamCompeting = LookUpTeamById(int.Parse(cols[1]));
                }
                p.Score = double.Parse(cols[2]);
                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    p.ParentMatchup = LookUpMatchUpById(int.Parse(cols[3]));
                }
                else
                {
                    p.ParentMatchup = null;
                }
                output.Add(p);
            }

            return output;
        }
        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModel(string inout)
        {
            string[] ids = inout.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');

                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();
            return output;
        }
        private static TeamModel LookUpTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();
            foreach (string team in teams)
            {
                string[] cols = team.Split(',');

                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels().First();
                }
            }

            return null;
        }
        private static MatchupModel LookUpMatchUpById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');

                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModels().First();
                }
            }

            return null;
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupModel p = new MatchupModel();

                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModel(cols[1]);
                if (cols[2].Length == 0)
                {
                    p.Winner = null;
                }
                else
                {
                    p.Winner = LookUpTeamById(int.Parse(cols[2]));
                }
                
                p.MatchupRound = int.Parse(cols[3]);
                

                output.Add(p);
            }

            return output;
        }
        public static void SaveMatchupsToFile(this MatchupModel model)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            matchups.Add(model);

            foreach (MatchupEntryModel entry in model.Entries)
            {
                entry.SaveEntriesToFile();
            }            

            List<string> lines = new List<string>();

            foreach (MatchupModel p in matchups)
            {
                string winner = "";
                if (p.Winner != null)
                {
                    winner = p.Winner.Id.ToString();
                }
                lines.Add($"{p.Id},{ConvertMatchupEntryListToString(p.Entries)},{winner},{p.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }
        public static void UpdateMatchupsToFile(this MatchupModel matchup)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            MatchupModel oldMatchup = new MatchupModel();

            foreach (MatchupModel m in matchups)
            {
                if(m.Id == matchup.Id)
                {
                    oldMatchup = m;
                }
            }
            matchups.Remove(oldMatchup);

            matchups.Add(matchup);

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.UpdateEntriesToFile();
            }

            List<string> lines = new List<string>();

            foreach (MatchupModel p in matchups)
            {
                string winner = "";
                if (p.Winner != null)
                {
                    winner = p.Winner.Id.ToString();
                }
                lines.Add($"{p.Id},{ConvertMatchupEntryListToString(p.Entries)},{winner},{p.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }
        public static void UpdateEntriesToFile(this MatchupEntryModel model)
        {
            List<MatchupEntryModel> Entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            MatchupEntryModel oldMatchupEntry = new MatchupEntryModel();

            foreach (MatchupEntryModel m in Entries)
            {
                if (m.Id == model.Id)
                {
                    oldMatchupEntry = m;
                }
            }
            Entries.Remove(oldMatchupEntry);

            Entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel p in Entries)
            {
                string parent = "";
                if (p.ParentMatchup != null)
                {
                    parent = p.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (p.TeamCompeting != null)
                {
                    teamCompeting = p.TeamCompeting.Id.ToString();
                }
                lines.Add($"{p.Id},{teamCompeting},{p.Score},{parent}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }
        public static void SaveEntriesToFile(this MatchupEntryModel model)
        {
            List<MatchupEntryModel> Entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            int currentId = 1;

            if (Entries.Count > 0)
            {
                currentId = Entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            Entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel p in Entries)
            {
                string parent = "";
                if(p.ParentMatchup != null)
                {
                    parent = p.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (p.TeamCompeting != null)
                {
                    teamCompeting = p.TeamCompeting.Id.ToString();
                }
                lines.Add($"{p.Id},{teamCompeting},{p.Score},{parent}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }
        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> model)
        {
            string output = "";

            if (model.Count == 0)
            {
                return "";
            }

            foreach (MatchupEntryModel p in model)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<MatchupModel> r in rounds)
            {
                output += $"{ConvertMatchUpListToString(r)}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchUpListToString(List<MatchupModel> match)
        {
            string output = "";

            if (match.Count == 0)
            {
                return "";
            }

            foreach (MatchupModel m in match)
            {
                output += $"{m.Id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel p in prizes)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel t in teams)
            {
                output += $"{t.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }

            foreach (PersonModel p in people)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
