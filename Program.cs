using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.Runtime.Remoting.Messaging;

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
        public class MovieFormat
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


        public static void Open(string cs)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Open();
        }

        public static void Close(string cs)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Close();
        }

        public static void Movie(string cs)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            var stm = "INSERT INTO Movies (ID, Title, Rating, Seats, Date_Time, Disabilities) VALUES (3, 'Shrek', 'PG', 'b', '2023-10-10 14:00:00', False);";

            var cmd = new SQLiteCommand(stm,con);



            stm = "SELECT ID FROM Movies";

            cmd = new SQLiteCommand(stm, con);

            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr.GetInt32(0)}");
                }
            }


            List<string> list = new List<string>();
            con.Close();
        }

        public static void Seats(int seats)
        {
            
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
            string cs = "C:\\Users\\paulj\\source\\repos\\Cinema\\Server.db";


            Open(cs);
            Movie(cs);






            Console.ReadKey();
            Close(cs);
        }
    }
}


/*
 *     READER
 *             using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read()) 
                {
                    Console.WriteLine($"{rdr.GetString(0)}");
                }
            }

            List<string> list = new List<string>();
*/