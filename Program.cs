using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;

namespace Cinema


/*Class for structure of movies:
 * 
 * 
 * Link code to database for getting information of movies
 * 
 * 
 * 
 * 
 * Group paying
 * Ask for amount of adults and children
 * confirm the age ranges
 * ask for all teh seats
 * ask if they have any disabilities (front row seats)
 * 
 * 
 * 
 * 2D array for seats
 * 1 for taken
 * 0 for empty
 *
 * 
 * Start While loop -> Ask if they want to continue as guest or login -> check if they are admin or just a user by the Database in table users
 * Show the current available movies with their ratings availability -> ask if its a group or not 
 * Group-> get group size -> for for disabilities and age range
 *                         Acceptable age
 *                              Yes -> Disabilities -> show times whithin the age range which are suita
 *                              
 *                              
 */
{
    internal class Program
    {
        public class Movie
        {
            public Nullable<int> ID = null;
            public string name = string.Empty;
            public string rating = string.Empty;
            public string[ , ] seats = {{ "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"},
                                        { "0", "0", "0", "0", "0", "0", "0", "0", "0"}};
                                            //  DAY1      DAY2    DAY 3   DAY4    DAY5    DAY6    DAY7
            public DateTime?[ , ] dates = { { null,     null,   null,   null,   null,   null,   null },
                                            { null,     null,   null,   null,   null,   null,   null },
                                            { null,     null,   null,   null,   null,   null,   null },
                                            { null,     null,   null,   null,   null,   null,   null },
                                            { null,     null,   null,   null,   null,   null,   null },};
                
        }
            

        public static void movie()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("C:\\Users\\AQ232596\\source\\repos\\Server");
            conn.Open();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            Movie movie = new Movie();
            List<string> list = new List<string>();




            do
            {
                //Display all Movies from db

                Console.WriteLine($"Welcome to the Cinema!\nThe available movies are\n1.{}");
            }
        }


        public static void Seats(int seats)
        {
            Movie movie = new Movie();
            
        }



        static void ReadData(SQLiteConnection conn)
        {
            conn.Open();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Movies";
            
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            while (sqlite_datareader.Read())
            {
                var myreader = sqlite_datareader.GetInt32(0);

                Console.WriteLine(myreader);
            }
            conn.Close();
        }



        static void Main()
        {
            string connectionString = "Data Source=C:\\Users\\AQ232596\\source\\repos\\Cinema\\Server.db";

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            ReadData(connection);
        }
    }
}
