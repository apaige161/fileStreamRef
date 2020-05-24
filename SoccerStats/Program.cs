using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added system.IO
using System.IO;
using System.Windows.Markup;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //directory class give us some static methods (can traverse folders or files) from the System.IO
            //first need to get the path of dir
            string currentDirectory = Directory.GetCurrentDirectory();
            //then ask for the info
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            //find a file before attempting to read it
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            //use the method below to read and print out results
            var fileContents = ReadSoccerResults(fileName);
        }

        //read a file from start to finish
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        //parses into useable data types
        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            
            var soccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                //positions the reader of our file in the first line of data
                reader.ReadLine();

                //parse all columns of data into computer readable form
                while ((line = reader.ReadLine()) != null)
                {
                    //creates a new var Type: GameResult
                    var gameResult = new GameResult();
                    //creates an array for each line
                    string[] values = line.Split(',');
                    
                    //added date of game
                        //declare the var to update value
                    DateTime gameDate;
                    //if tryparse is success print game date
                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    //add team name to output
                    gameResult.TeamName = values[1];

                    //add played at home or away
                    HomeOrAway homeOrAway;
                    if(Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    //add goals, goal attemps, shots on goal, shots missed
                    int parseInt;

                    //goals
                    if(int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }

                    //attempts
                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }

                    //shots on goal
                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }

                    //shots missed
                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    //possesion percent
                    double possesionPercent;
                    if(double.TryParse(values[7], out possesionPercent))
                    {
                        gameResult.PossesionPercent = possesionPercent;
                    }
                    
                    //add all data above to soccerResults
                    soccerResults.Add(gameResult);
                }
            }
            //all columns of data are parsed and displayed
            return soccerResults;
        }









    }
}
