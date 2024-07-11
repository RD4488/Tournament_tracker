using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";
        public static IDataConnection Connections { get; private set; }

        public static void InitializeConnection(Databasetype db)
        {
            switch (db)
            {
                case Databasetype.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connections = sql;
                    break;
                case Databasetype.TextFile:
                    TextConnector text = new TextConnector();
                    Connections = text;
                    break;
                default:
                    break;
            }
        }
        public static string GetConnectionString(string connectionString)
        {
            string output = "";

            var Builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = Builder.Build();

            output = config.GetConnectionString(connectionString);

            return output;
        }
    }
}
