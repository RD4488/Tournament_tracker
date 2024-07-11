using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizeTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizeTeams.Count);
            int byes = NumberOfByes(rounds, randomizeTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizeTeams));

            CreateOtherRounnds(model,rounds);

        }
        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> rounds in model.Rounds)
            {
                foreach (MatchupModel rm in rounds)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }
            MarkWinnerInMatchups(toScore);

            AdvanceWinner(toScore,model);
            
            toScore.ForEach(x=> GlobalConfig.Connections.UpdateTournament(x));
            int endingRound = model.CheckCurrentRound();

            if(endingRound > startingRound)
            {
                model.AleartUsersToRound();
            }
        }
        public static void AleartUsersToRound(this TournamentModel model)
        {
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currRound = model.Rounds.Where(x=>x.First().MatchupRound == currentRoundNumber).First();

            foreach (MatchupModel m in currRound)
            {
                foreach (MatchupEntryModel me in m.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName,m.Entries.Where(x=>x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel competitor)
        {
            if(p.EmailAddress.Length == 0)
            {
                return;
            }

            string to = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            if(competitor != null)
            {
                subject = $"You have a new matchup with {competitor.TeamCompeting.TeamName}.";

                body.AppendLine("<h1>You have a new matchup<h1>");
                body.Append("<strong>Competotor : </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a Great Time!");
                body.AppendLine("Tournament Tracker");
            }
            else
            {
                subject = $"You have a bye week this round.";

                body.AppendLine("Enjoy Your Round Off!");
                body.AppendLine("Tournament Tracker");
            }

            to = p.EmailAddress;

            EmailLogic.SendMail(to,subject,body.ToString());
        }

        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;
            foreach (List<MatchupModel> round in model.Rounds)
            {
                if(round.All(x=>x.Winner != null))
                {
                    output++;
                }
                else
                {
                    return output;
                }
            }

            CompleteTournament(model);

            return output-1;
        }

        private static void CompleteTournament(TournamentModel model)
        {
            GlobalConfig.Connections.CompleteTournament(model);
            TeamModel winner = model.Rounds.Last().First().Winner;
            TeamModel runnerup = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winner).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerupPrize = 0;

            if (model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;

                PrizeModel firstPlacePrize = model.Prizes.Where(x=>x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizeLayOut(totalIncome);
                }

                if (secondPlacePrize != null)
                {
                    runnerupPrize = secondPlacePrize.CalculatePrizeLayOut(totalIncome);
                }
            }


            string to = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            subject = $"In {model.TournamentName}, {winner.TeamName} has won!";

            body.AppendLine("<h1>We have a WINNER!<h1>");
            body.Append("<p> Congratulations to our winner on a great tournament.</p>");
            body.AppendLine("<br /");

            if(winnerPrize >0)
            {
                body.AppendLine($"<p> {winner.TeamName} will receive ${winnerPrize}. </p>");
            }
            if (runnerupPrize > 0)
            {
                body.AppendLine($"<p> {runnerup.TeamName} will receive ${runnerupPrize}. </p>");
            }

            body.AppendLine("<br/>");
            body.AppendLine("<p>Thanks for greate tournament Everyone!");
            body.AppendLine("Tournament Tracker");
    
            List<string> bcc = new List<string>();

            foreach (TeamModel t in model.EnteredTeams)
            {
                foreach (PersonModel p in t.TeamMembers)
                {
                    if(p.EmailAddress.Length > 0)
                    {
                        bcc.Add(p.EmailAddress);
                    }
                }
            }

            EmailLogic.SendMail(new List<string>(),bcc, subject, body.ToString());

            model.CompleteTournament();
        }
        private static decimal CalculatePrizeLayOut(this PrizeModel prize,decimal totalIncome)
        {
            decimal output = 0;
            if(prize.PrizeAmount > 0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome , Convert.ToDecimal(prize.PrizePercentage/100));
            }
            return output;
        }

        private static void AdvanceWinner(List<MatchupModel> models,TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> rounds in tournament.Rounds)
                {
                    foreach (MatchupModel round in rounds)
                    {
                        foreach (MatchupEntryModel me in round.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connections.UpdateTournament(round);
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            string greaterWins = GlobalConfig.GetConnectionString("greaterWins");

            foreach (MatchupModel m in models)
            {
                if(m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }
                if(greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if(m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("tie is not allowed");
                    }
                }
                else
                {
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("tie is not allowed");
                    }
                }
            }

        }
        private static void CreateOtherRounnds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRounds = model.Rounds[0];
            List<MatchupModel> currRounds = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while(round <= rounds)
            {
                foreach(MatchupModel matchup in previousRounds)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup =  matchup });
                    if(currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRounds.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }
                model.Rounds.Add(currRounds);
                previousRounds = currRounds;
                currRounds = new List<MatchupModel>();
                round++;
            }
        }
        private static List<MatchupModel> CreateFirstRound(int byes,List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();
            foreach(TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel() { TeamCompeting =  team });

                if(byes > 0 || curr.Entries.Count>1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();
                    if(byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }
        private static int NumberOfByes(int round,int numberofTeams)
        {
            int output = 0;
            int totalTeam = 1;

            for(int i = 1; i <= round; i++)
            {
                totalTeam *= 2;
            }
            output = totalTeam - numberofTeams;
            return output;
        }
        private static int FindNumberOfRounds(int count)
        {
            int output = 1;
            int val = 2;
            while(val < count)
            {
                output++;

                val *= 2;
            }
            return output;
        }
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
