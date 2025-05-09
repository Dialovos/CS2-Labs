using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SQLAndLINQLab
{
    /// <summary>
    /// Lab11
    /// </summary>
    class Program
    {
        // replace SQL Server connection string
        private const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StudentDB;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            try
            {
                // connecting to SQL database
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    Console.WriteLine("Connection established.");

                    // for reset testing; comment out when not
                    ResettingDatabase.ResetDatabase(sqlConnection);

                    Console.WriteLine("\n(Part 2)");

                    // Read all students
                    Console.WriteLine("Reading all students:");
                    ReadAllStudents(sqlConnection);

                    // new student
                    Console.WriteLine("\nAdding a new students");
                    int newStudent = AddStudent(sqlConnection, "Yo_mama", 24, 3.7);
                    if (newStudent > 0)
                    {
                        Console.WriteLine($"Added StudentID: {newStudent}");
                        ReadAllStudents(sqlConnection);
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Yo_mama.");
                    }

                    // locate Bob & update his GPA
                    Console.WriteLine("\nUpdating Bob's GPA to 3.6:");
                    int bob = GetStudentByName(sqlConnection, "Bob");
                    if (bob > 0)
                    {
                        UpdateStudentGPA(sqlConnection, bob, 3.6);
                        ReadAllStudents(sqlConnection);
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find Bob for update.");
                    }

                    // locate Charlie and vanish him
                    Console.WriteLine("\nDeleting Charlie:");
                    int charlie = GetStudentByName(sqlConnection, "Charlie");
                    if (charlie > 0)
                    {
                        DeleteStudent(sqlConnection, charlie);
                        ReadAllStudents(sqlConnection);
                    }
                    else
                    {
                        Console.WriteLine("Could not find Charlie for deletion.");
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception error: {ex.Message}");
            }

            LinqExample();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        // AI help for CRUD related code => Deepseek R1
        #region ADO.NET CRUD
        /// <summary>
        /// Read all students
        /// </summary>
        /// <param name="sqlConnection"></param>
        public static void ReadAllStudents(SqlConnection sqlConnection)
        {
            string query = "SELECT StudentID, Name, Age, GPA FROM Students";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Students not listed in the table.");
                            return;
                        }
                        Console.WriteLine("Current Students:");
                        while (reader.Read())
                        {
                            // Access the columns to read it
                            int id = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string name = reader.GetString(reader.GetOrdinal("Name"));

                            // handle null & conversion type
                            int age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age"));
                            double gpa = reader.IsDBNull(reader.GetOrdinal("GPA")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("GPA")); 

                            Console.WriteLine($" -> ID: {id}, Name: {name}, Age: {age}, GPA: {gpa:F2}"); // F2 formats float/double to 2 decimal places
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Reading error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// helper to get ID
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetStudentByName(SqlConnection sqlConnection, string name)
        {
            string query = "SELECT StudentID FROM Students WHERE Name = @Name";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                // ExecuteScalar because we expect only one value back 
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            return -1; // return -1 if not found
        }


        /// <summary>
        /// Add student
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gpa"></param>
        /// <returns></returns>
        public static int AddStudent(SqlConnection sqlConnection, string name, int age, double gpa)
        {
            // using parameterized to prevent SQL Injection
            // using OUTPUT INSERTED.StudentID to get the new ID back
            string query = "INSERT INTO Students (Name, Age, GPA) OUTPUT INSERTED.StudentID VALUES (@Name, @Age, @GPA);";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@GPA", gpa);

                try
                {
                    // ExecuteScalar is suitable here because we expect one value back (the new ID)
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                }
                return -1; // return -1 when unable to add student
            }
        }

        /// <summary>
        /// Gpa modifier
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="studentId"></param>
        /// <param name="newGpa"></param>
        public static void UpdateStudentGPA(SqlConnection sqlConnection, int studentId, double newGpa)
        {
            string query = "UPDATE Students SET GPA = @GPA WHERE StudentID = @StudentID;";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@GPA", newGpa);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    int rowsChanged = cmd.ExecuteNonQuery();
                    if (rowsChanged > 0)
                    {
                        Console.WriteLine($"Updated GPA ID: {studentId}");
                    }
                    else
                    {
                        Console.WriteLine($"Student: {studentId} not found");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating GPA: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// removing Student
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="studentId"></param>
        public static void DeleteStudent(SqlConnection sqlConnection, int studentId)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID;";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Deleted Student ID: {studentId}");
                    }
                    else
                    {
                        Console.WriteLine($"Student: {studentId} not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting student: {ex.Message}");
                }
            }
        }
        #endregion

        #region Part 3 & 4
        public static void LinqExample()
        {
            Console.WriteLine("\n(Part 3)");

            Console.WriteLine("LINQ Queries:");
            List<Student> studentList = new List<Student> {
                 new Student { StudentID=1, Name = "Alice", Age = 20, GPA = 3.8 },
                 new Student { StudentID=2, Name = "Bob", Age = 22, GPA = 3.5 },
                 new Student { StudentID=3, Name = "Charlie", Age = 21, GPA = 3.9 },
             };

            // filter students with a GPA > 3.6
            var highGPAStudents_Objects = studentList.Where(s => s.GPA > 3.6);
            /* same as above but simplify
             * var highGPAStudents_Objects = from s in studentList
             *                               where s.GPA > 3.6
             *                               select s;
             */

            Console.WriteLine("Students with GPA > 3.6:");
            foreach (var student in highGPAStudents_Objects)
            {
                Console.WriteLine($" -> {student.Name}, GPA: {student.GPA:F2}");
            }

            /* Comparing SQL and LINQ syntax
             * Query Comparison: Students older than 21
             * 
             * SQL  => "SELECT StudentID, Name, Age, GPA FROM Students WHERE Age > 21;"
             * Then use ADO.NET to exc it like in part 2
             * 
             * LINQ => 
             * var olderStudents_LinqObjects = studentList.Where(s => s.Age > 21);
             * foreach (var student in olderStudents_LinqObjects)
             * {
             *  Console.WriteLine($" -> {student.Name}, Age: {student.Age}");
             * }
             * 
             * SQL:string-based, prone to runtime syntax errors,
             * & need careful handling to prevent SQL injection
             * Not to mention you also have to set it up
             *
             * LINQ: uses language syntax, better readability
             * reducing injection risk
             */
        }
        #endregion
    }
}
