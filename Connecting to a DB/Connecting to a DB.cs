using System;
using System.Data.SqlClient;

namespace DDBB_Exercices
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string checkSurname, newCountry;

            Console.Write("Enter your surname: ");
            checkSurname = Console.ReadLine();

            SqlConnection connection = new SqlConnection("Data Source=TRAVELMATE\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            string querySurname = $"SELECT * FROM Employees WHERE Lastname = '{checkSurname}'";
            SqlCommand command = new SqlCommand(querySurname, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())

            {
                connection.Close();
                Console.Write("\n Your surname appears in the database. \n\n Enter your new country: ");
                newCountry = Console.ReadLine();

                string queryCountry = $"UPDATE Employees SET Country = '{newCountry}' WHERE LastName = '{checkSurname}'";


                SqlCommand commandCountry = new SqlCommand(queryCountry, connection);

                connection.Open();
                
                Console.WriteLine("\n Your country has been changed.");
                Console.WriteLine("\n" + commandCountry.ExecuteNonQuery() + " rows modified.");
                
                connection.Close();
            }
            else
            {
                Console.WriteLine("Your surname does not appears in the database. Try  again.");
            }

            //SqlConnection connection = new SqlConnection("Data Source=TRAVELMATE\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            //string query = $"UPDATE Employees SET Country = '{"SP"}' WHERE Country = 'AUS'";
            //SqlCommand command = new SqlCommand(query, connection);
            //connection.Open();

            //Console.WriteLine(command.ExecuteNonQuery() + " rows affected");

            //SqlConnection connection = new SqlConnection("Data Source=TRAVELMATE\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            //string query = "SELECT * FROM Employees";
            //SqlCommand command = new SqlCommand(query, connection);
            //connection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            //while(reader.Read())
            //{
            //    Console.WriteLine(reader[0].ToString() + " - " + reader[1].ToString() + ", " + reader[2].ToString() + " - " + reader[1].ToString());
            //}
        }
    }
}