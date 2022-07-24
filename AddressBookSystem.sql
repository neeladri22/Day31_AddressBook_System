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

--Size of Addressbook by City / State
select COUNT(City) FROM AddressBook
select COUNT(State) FROM AddressBook

INSERT INTO AddressBook Values
('Srinu','Marri','sonna','sonna', 'Odisa','546321','3652147896','srinu@gmail.com'),
('Padma','Marri','Plpuram','Plpuram', 'Andhra','654321','7894561236','padma@gmail.com'),
('Hema','Dunna','Donkuru','Donkuru', 'Bangalore','654789','9638527417','sony@gmail.com');

--Sort Persons Name Alphabetically for a given city
SELECT * FROM AddressBook WHERE City = 'Donkuru' ORDER by FirstName PNR

--Identify the address book by Name and Type
ALTER TABLE AddressBook ADD AddressBookName varchar (20),AddressBookType varchar (20);

--Update AddressBook Contact
update AddressBook SET AddressBookName = 'Self', AddressBookType = 'Family' where FirstName = 'Neeladri'
update AddressBook SET AddressBookName = 'Hema', AddressBookType = 'Friend' where FirstName = 'Hema'
update AddressBook SET AddressBookName = 'Varsa', AddressBookType = 'Family' where FirstName = 'Varsa'
update AddressBook SET AddressBookName = 'Usha', AddressBookType = 'Family' where FirstName = 'Usha'

--Get number of contact persons i.e count by type
SELECT AddressBookType,  COUNT(AddressBookType) from AddressBook group by AddressBookType

--Adding AddressBookID for AddressBook Table to Assign AddressBooktype
AlTER table AddressBook drop column AddressBookID

--Adding COnstraints to AddressBook Table
Alter table AddressBook add AddressBookID int foreign key references AddressBookCategory

--Creating the AddressBookCategory table to differentiate Family, Friend and Profession
CREATE TABLE AddressBookCategory(
AddressBookID int primary key, 
AddressBookType varchar(20)
)

SELECt * FROM AddressBookCategory
SELECT * FROM AddressBook
--Assigning Id to Family, Friend and Profession
Insert into AddressBookCategory values (1,'Family'),(2,'Friend'),(3,'Profession')

--Add person to both Friend and Family
update AddressBook SET AddressBookID =1  where FirstName = 'Neeladri'
update AddressBook SET AddressBookID =2  where FirstName = 'Usha'
update AddressBook SET AddressBookID =1  where FirstName = 'Varsa'
update AddressBook SET AddressBookID = 1 where FirstName = 'Hema'
update AddressBook SET AddressBookID = 2 where FirstName = 'Padma'
update AddressBook SET AddressBookID = 3 where FirstName = 'Sony'



--E-R Diagram




























