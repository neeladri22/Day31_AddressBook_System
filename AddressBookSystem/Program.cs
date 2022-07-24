﻿using System;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create AddreessBook_System Database
            CreateAddressBookServiceDB();

            //Create AddressBook Table
            CreateAddressBookTable();

            //Insert New Contacts in  AddressBook Table
            InsertContactInAddressBookTable();

            //Update existing Contacts in  AddressBook Table
            UpdateExistingContactInAddressBookTable();

            //Delete existing Contacts in  AddressBook Table by using persons name
            DeleteContactInAddressBookTable();
        }
        //Create New Database
        public static void CreateAddressBookServiceDB()
        {
            string SQL = "CREATE DATABASE AddreessBook_System ";

            string connectingstring = @"Server=localhost;Integrated security=SSPI;database=master";

            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database Created Successfully....");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        //Create AddressBook Table
        public static void CreateAddressBookTable()
        {
            var SQL = @$"CREATE TABLE AddressBook ( FirstName Varchar(20), LastName Varchar(15), Address Varchar(50), City Varchar(20), State Varchar(20), ZIP int, PhoneNumber Varchar(15), Email Varchar(20) )";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table Created Successfully");
            Console.ReadKey();
        }

        //Insert New Contacts in  AddressBook Table
        public static void InsertContactInAddressBookTable() //UC3
        {
            var SQL = @$"INSERT INTO AddressBook Values  ('Neeladri','Pulakala','PL puram','Ichapuram', 'Andhra','123654','8965741236','neela@gmail.com'),
                                                         ('Usha','Pulakala','Ichapuram','Ichapuram', 'Visaka','789456','8547962314','usha@gmail.com'),
                                                         ('Varsa','Pulakala','Donkuru','Donkuru', 'Visaka','456321','741852963','varsa@gmail.com');";
           
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("New contact is Successfully inserted");
            Console.ReadKey();
        }

        //Update existing Contacts in  AddressBook Table
        public static void UpdateExistingContactInAddressBookTable()
        {
            var SQL = @$"UPDATE AddressBook set Address = 'madhurai', City = 'madhurai' where FirstName = 'Neeladri'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Contact is Updated Successfully ");
            Console.ReadKey();
        }

        //Delete existing Contacts in  AddressBook Table by using persons name
        public static void DeleteContactInAddressBookTable()
        {
            var SQL = @$"DELETE AddressBook WHERE FirstName = 'Usha'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Contact is deleted Successfully ");
            Console.ReadKey();
        }

    }
}

