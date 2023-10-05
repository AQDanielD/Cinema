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

        public static void InsertMovie(string cs,string table,string title,string rating, string[ , ] seats,DateTime datetime,bool disabilities)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Open();
            string insertStm = $"INSERT INTO {table} (title, rating, Seats, date_time, disabilities) VALUES ('{title}', '{rating}', '{seats}', '{datetime}', 0);";
            using (var insertCmd = new SQLiteCommand(insertStm, con))
            {
                int insertResult = insertCmd.ExecuteNonQuery();
                if (insertResult > 0)
                {
                    Console.WriteLine("Insertion successful.");
                }
                else
                {
                    Console.WriteLine("No rows were inserted.");
                }
            }

        }

        public static void CreateTable(string cs)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Open();
            string insertStm = $"" +
                //$"PRAGMA foreign_keys = ON;" +
                $"CREATE TABLE Movies (MovieID INTEGER PRIMARY KEY,Title TEXT,Genre TEXT,Duration INTEGER);" +
                $"CREATE TABLE Showtimes (ShowtimeID INTEGER PRIMARY KEY,MovieID INTEGER,DateTime DATETIME,CinemaHall TEXT);" +
                //$"FOREIGN KEY (MovieID) REFERENCES Movies (MovieID);" +
                $"CREATE TABLE Seats (SeatID INTEGER PRIMARY KEY,RowNumber INTEGER,SeatNumber INTEGER,IsAvailable BOOLEAN,Price DECIMAL(10, 2),ShowtimeID INTEGER);" +
                //$"FOREIGN KEY (ShowtimeID) REFERENCES Showtimes (ShowtimeID));" +
                $"CREATE TABLE Reservations (ReservationID INTEGER PRIMARY KEY,ShowtimeID INTEGER,SeatID INTEGER,CustomerName TEXT,ReservationDate DATETIME);";
                //$"FOREIGN KEY (ShowtimeID) REFERENCES Showtimes (ShowtimeID)," +
                //$"FOREIGN KEY (SeatID) REFERENCES Seats (SeatID);";
            using (var insertCmd = new SQLiteCommand(insertStm, con))
            {
                int insertResult = insertCmd.ExecuteNonQuery();
                if (insertResult > 0)
                {
                    Console.WriteLine("Insertion successful.");
                }
                else
                {
                    Console.WriteLine("No rows were inserted.");
                }
            }
        }

        public static void DropTable(string cs,string table)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Open();
            string insertStm = $"DROP TABLE {table}";
            using (var insertCmd = new SQLiteCommand(insertStm, con))
            {
                int insertResult = insertCmd.ExecuteNonQuery();
                if (insertResult > 0)
                {
                    Console.WriteLine("Insertion successful.");
                }
                else
                {
                    Console.WriteLine("No rows were inserted.");
                }
            }
        }

        public static void Movie(string cs)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={cs};");
            con.Open();

            var stm = $"SELECT Title FROM Movies WHERE date_time > datetime('now');";

            var cmd = new SQLiteCommand(stm, con);

            Console.WriteLine($"The showings for today are as shown:");

            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr.GetString(0)}");
                }
            }



            con.Close();
        }

        static void Main()
        {
            string cs = "C:\\Users\\paulj\\source\\repos\\Cinema\\Server.db";

            CreateTable(cs);

            Console.ReadKey();

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