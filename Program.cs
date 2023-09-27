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
            string connectionString = "Data Source=C:\\Users\\paulj\\source\\repos\\Cinema\\Server.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL statement to create the "Movies" table
                string insertQuery = "SELECT * FROM Movies;";


                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Access and output data from each row
                            int id = reader.GetInt32(0); // Assuming id is in the first column
                            string title = reader.GetString(1); // Assuming title is in the second column
                            string rating = reader.GetString(2); // Assuming rating is in the third column
                            string seats = reader.GetString(3); // Assuming seats is in the fourth column
                            DateTime dateTime = reader.GetDateTime(4); // Assuming date_time is in the fifth column
                            string disabilities = reader.GetString(5); // Assuming disabilities is in the sixth column

                            Console.WriteLine($"ID: {id}, Title: {title}, Rating: {rating}, Seats: {seats}, Date & Time: {dateTime}, Disabilities: {disabilities}");
                            Console.ReadKey();
                        }
                    }
                }
                // Continue with other database operations as needed.
            }
        }
    }
}
