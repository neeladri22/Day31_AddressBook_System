--Welcome to Address Book System Problem
--Creating the Address Book Service data base
CREATE DATABASE Address_Book_Service

use Address_Book_Service

--Create AddressBook Table
CREATE TABLE AddressBook
(
FirstName Varchar(20),
LastName Varchar(15),
Address Varchar(50),
City Varchar(20),
State Varchar(20),
ZIP int,
PhoneNumber Varchar(15),
Email Varchar(20)
)

--To View the AddressBook Table
SELECT * FROM AddressBook

--Insert COntacts into AddressBook
INSERT INTO AddressBook Values 
('Neeladri','Pulakala','Srikakulam','Andhra pradesh', 'AP','532312','7385412789','neela@gmail.com'),
('Usha','Pulakala','Icchapuram','Andhra pradesh', 'AP','532312','6535412789','usha@gmail.com'),
('Varsa','Pulakala','Srikakulam','Andhra pradesh', 'AP','532312','5235412789','varsa@gmail.com');



--Edit the existing data in the table
UPDATE AddressBook
set Address = 'Dwaraka', City = 'Visaka' where FirstName = 'Usha' ;

--Delete person using persons name
DELETE AddressBook WHERE FirstName = 'Varsa'


--Retrieve the persons city / State by using persons name
Select City, State from AddressBook where FirstName = 'Neeladri'







