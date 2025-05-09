using System.Data.SqlClient;
using System;

namespace SQLAndLINQLab
{
    public class ResettingDatabase
    {
        public static void ResetDatabase(SqlConnection sqlconnection)
        {
            Console.WriteLine("\n=> Resetting database...");

            // cmd batch
            string resetSql = @"
                DELETE FROM Students;

                DBCC CHECKIDENT ('Students', RESEED, 0);

                INSERT INTO Students (Name, Age, GPA) VALUES ('Alice', 20, 3.8);
                INSERT INTO Students (Name, Age, GPA) VALUES ('Bob', 22, 3.5);
                INSERT INTO Students (Name, Age, GPA) VALUES ('Charlie', 21, 3.9);
            ";

            using (SqlCommand cmd = new SqlCommand(resetSql, sqlconnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\n=> Database reset done");
                }
                catch (SqlException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR in database reset: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
