using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

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
        /*
         *         // movies

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




            sqlite_conn.Open();
            sqlite_conn.();

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


*/
        static void Main()
        {
            string connectionString = "Data Source=C:\\Users\\AQ232596\\source\\repos\\Cin\\Server.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL statement to create the "Movies" table
                string insertQuery = "CREATE TABLE Movies (ID int not null, Title varchar(255), Rating varchar(255), Seats varchar(255) deafault, Date&Time datetime null, Disabilities bool deafault, PRIMARY KEY (ID))";


                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                // Continue with other database operations as needed.
            }
        }
    }
}
