using System;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
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

            //Retrieve the persons city / State by using persons name
            RetrievePersonBelongsToCityByPersonsName();

            //Size of Addressbook by City 
            SizeOfAddressBookByCity();

            //Size of Addressbook by State
            SizeOfAddressBookByState();
            */

            //Sort Persons Name Alphabetically for a given city
            RetrieveEntriesSortedAlphabeticallyByPersonsName();

            //Identify the address book by Name and Type
            IdentifyAddressBookByNameandType(); //UC9

            //Identify the address book by Name and Type
            UpdateAddressBookByNameandType(); //UC9-extended
            //Get number of contact persons i.e count by type-U10
            GetNumberOfPersonsCountbyType();

            //Add person to both Friend and Family
            AddPersonToBothFriendAndFamily();

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

        //Retrieve the persons city / State by using persons name
        public static void RetrievePersonBelongsToCityByPersonsName()
        {
            var SQL = @$"Select City, State from AddressBook where FirstName = 'Neeladri'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Person Belongs to {0} - City {1} - State", reader["City"], reader["State"]);
                }
                reader.Close();
            };
            Console.ReadKey();
        }
        //Size of Addressbook by City 
        public static void SizeOfAddressBookByCity()
        {
            var SQL = @$"select COUNT(City) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine("Size of the AddressBook is " + reader);
            Console.ReadKey();
        }

        //Size of the Addressbook by State
        public static void SizeOfAddressBookByState()
        {
            var SQL = @$"select COUNT(State) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine("Size of the AddressBook is " + reader);
            Console.ReadKey();
        }

        //Sort Persons Name Alphabetically for a given city
        public static void RetrieveEntriesSortedAlphabeticallyByPersonsName()
        {
            var SQL = @$"SELECT * FROM AddressBook WHERE City = 'Donkuru' ORDER by FirstName PNR";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Person Belongs to {0} - City {1} - State", reader["City"], reader["State"]);
                }
                reader.Close();
            };
            Console.ReadKey();
        }

        //Identify the address book by Name and Type
        public static void IdentifyAddressBookByNameandType()
        {
            var SQL = @$"ALTER TABLE AddressBook ADD AddressBookName varchar (20),AddressBookType varchar (20)";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table is Updated Successfully ");
            Console.ReadKey();
        }

        //Identify the address book by Name and Type
        public static void UpdateAddressBookByNameandType()
        {
            var SQL = @$"update AddressBook SET AddressBookName = 'Self', AddressBookType = 'Family' where FirstName = 'Neeladri'
                        update AddressBook SET AddressBookName = 'Varsa', AddressBookType = 'Friend' where FirstName = 'Dunna'
                        update AddressBook SET AddressBookName = 'Usha', AddressBookType = 'Family' where FirstName = 'Pulakala'";
           
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table is Updated Successfully ");
            Console.ReadKey();
        }

        //Get number of contact persons i.e count by type
        public static void GetNumberOfPersonsCountbyType()
        {
            var SQL = @$"SELECT AddressBookType,  COUNT(AddressBookType) from AddressBook group by AddressBookType";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("AddressBook Type {0}  - Numbers {1} ", reader["AddressBookType"], reader);
                }
                reader.Close();
            };
            Console.WriteLine("\nRetrieve data Successfully");
            Console.ReadKey();
        }
        //Add person to both Friend and Family
        public static void AddPersonToBothFriendAndFamily()
        {
            var SQL = @$"INSERT INTO AddressBook Values('Laxman','togu','donkuru','Ap', 'Ap','369852','879456321','laxman@gmail.com','Friend','lax'),
                                                         ('Raji','yarra','sonna','Odisa', 'Odisa','741852','7418529632','raji@gmail.com','Friend','raji')";

            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Contact Person is Added Successfully ");
            Console.ReadKey();
        }

    }
}

