--This creates the database
Create database COCOFitness;
Go

--This creates the Customer table
Create table Customer
(
    CustomerNo char not null,
	Firstname char(15) not null,
	Surname char (15) not null,
	Address varchar (30) not null,
	Postcode varchar (8) not null,
	Town char(20) not null,
	County char(20) not null,
	PhoneNumber varchar(11) not null

	constraint PKCustomer primary key (CustomerNo)
);
go

--This is the content for the customer table
use COCOFitness;
insert into Customer
(
  CustomerNo, Firstname, Surname, Address, Postcode, Town, County, PhoneNumber
)
values('1','Gerald', 'Duffy', '12 Main Street', 'BT11 9ER', 'Derry', 'Derry', '02870258992'),
      ('2', 'Gemma', 'McGee', '8 Main Road', 'BT52 9AT', 'Coleraine', 'Derry', '02870778931'),
	  ('3', 'Steven', 'Bergwijn', '5 Parcel Avenue', 'BT46 5BH', 'Strabane', 'Tyrone', '07936598076'),
	  ('4','Sadio', 'Mane', '19 Champions Street', 'BT45 2BR', 'Strabane', 'Tyrone', '07894561019'),
	  ('5','Rhys', 'Williams', '7 Main Road', 'BT48 8NH', 'Derry', 'Derry', '07564698322'),
	  ('6', 'Harry', 'Potter', '11 Hogwarts way', 'BT57 2PD', 'Belfast', 'Antrim', '07769860911'),
	  ('7','Leigh', 'Griffiths', '9 Paradise Avenue', 'BT51 6GB', 'Tandragee', 'Armagh', '07943190067'),
	  ('8','Barry', 'McGuigan', '10 Shipquay Street', 'BT44 3TJ', 'Enniskillen', 'Fermanagh', '07830312297'),
	  ('9', 'Alicia', 'Kelly', '5 Tottenham Road', 'BT58 6NG', 'Downpatrick', 'Down', '07763145876'),
	  ('10', 'Naomh', 'Coyle', '33 Main Street', 'BT11 9ER', 'Derry', 'Derry', '07543202388'),
	  ('11', 'Geraldine', 'Black', '12 Paradise Avenue', 'BT51 10L', 'Tandragee', 'Armagh', '07893456210'),
	  ('12', 'Kim', 'Possible', '35 Disney Street', 'BT65 1KP', 'Derry', 'Derry', '07898743522'),
	  ('13', 'Caroline', 'Rummenigge', '6 Bavaria way', 'BT14 4WC', 'Enniskillen', 'Fermanagh', '02864491054'),
	  ('14', 'Lucy', 'Duffy', '20 Anastasia Road', 'BT65 3TH', 'Belfast', 'Antrim', '0287025899'),
	  ('15', 'Frank', 'Lampard', '24 Champions Street', 'BT45 2BR', 'Strabane', 'Omagh', '02812345678'),
	  ('16', 'Harry', 'Redknapp', '30 Tottenham Road', 'BT58 6NG', 'Downpatrick', 'Down', '07743590976'),
	  ('17', 'Hannah', 'Brown', '22 Secrets Way', 'BT56 3PT', 'Derry', 'Derry', '02844438902'),
	  ('18', 'Helen', 'Firth', '33 King Street', 'BT11 9ER', 'Enniskillen', 'Fermanagh', '02899951401'),
	  ('19', 'Keith', 'Richards', '97 Highmoore Road', 'BT46 3TT', 'Derry', 'Derry', '07562638108'),
	  ('20', 'Malachy', 'Mackay', '12 Cardiff Street', 'BT11 5HE', 'Tandragee', 'Armagh', '0287063399'),
	  ('21', 'Michelle', 'Green', '33 Rain Avenue', 'BT44 9NG', 'Belfast', 'Antrim', '07569184566'),
	  ('22', 'Sommer', 'Smith', '33 Portal Road', 'BT13 4TH', 'Tandragee', 'Armagh', '07954338922'),
	  ('23', 'Rick', 'Sanchez', '37 Portal Road ', 'BT13 4TH', 'Tandragee', 'Armagh', '07899954321'),
	  ('24', 'Felix', 'McGrath', '42 Wollows way', 'BT38 2QC', 'Coleraine', 'Derry', '07804357827'),
	  ('25', 'Marion', 'Weatherall', '33 Holylands', 'BT57 4FG', 'Belfast', 'Antrim', '07785428341'),
	  ('26', 'Sharon', 'McGee', '4 Hollywood Street', 'BT55 9MD', 'Belfast', 'Antrim', '07865492344'),
	  ('27', 'Harry', 'Styles', '1 Direction Street', 'BT33 1DF', 'Coleraine', 'Derry', '02854630177'),
	  ('28', 'Megan', 'Markle', '5 Pump Street', 'BT48 6FD', 'Derry', 'Derry', '07865493293'),
	  ('29', 'Catherine', 'McWilliams', '11 Shankhill Road', 'BT57 8AU', 'Belfast', 'Antrim', '079865024'),
	  ('30', 'Andrea', 'White', '22 Carington Park', 'BT21 9NF', 'Magherafelt', 'Derry', '02878954322');

use COCOFitness;
create table Engineer
(
 EngineerNo VarChar(3) ,
 Firstname  char(15),
 Surname char(15)

 constraint PKEngineer primary key (EngineerNo)
);
go

--This is the content for the Engineer table
use COCOFitness;
insert into Engineer
( EngineerNo, Firstname, Surname)

values('1','Jurgen',' Klopp'),
      ('2', 'Michael', 'Long'),
	  ('3', 'Steven' , 'Wright'),
	  ('4', 'John','Brown'),
	  ('5','Mark','Long'),
	  ('6','Kevin','McAfferty'),
	  ('7','James','Mcdaid'),
	  ('8','Troy','Parrot'),
	  ('9','Joseph','Hardy'),
	  ('10','Caomhan','McLaughlin');

--This creates the Parts table
Create table Part
(
   PartNo char(3),
   PartName char(30)

	constraint PKParts primary key (PartNo)
);
go

--This is the content for the Parts table
use COCOFitness;
insert into Part
(
 PartNo, PartName
)
values('001','Shoulder Press Handle'),
      ('002','Bench Press Pin'),
      ('003','Dumbbell plate');

Use COCOFitness
--This makes the Supplier table
Create table Supplier
(
  SupplierNo VarChar(3),
  SupplierName char(30),
  SupplierStreet char(30),
  SupplierTown char(15),
  SupplierCounty char(15),
  SupplierPostcode char(8)

  constraint PKSupplier primary key (SupplierNo)
);
go

--This is the content for the Supplier table
use COCOFitness;
insert into Supplier
( SupplierNo, SupplierName, SupplierStreet, SupplierTown, SupplierCounty, SupplierPostcode)

values('001','Machels',' 24 Dressing view','maghera','Derry', 'BT48 2HS'),
      ('002','Neyons',' 1T Messons Park','Strabane','Tyrone', 'BT45 4NY'),
	  ('003','McGeehan Fitness',' 22 Main Street','Limavady','Derry', 'BT48 9AD');

Use COCOFitness
--This makes the Stock table
Create table Stocks
(
  MachineNo VarChar(3),
  MachineName Char(15),
  PartNo char(3),
  PartName char(15),
  SupplierNo varchar(3),
  SupplierName char(30)

  
  constraint PKMachine primary key (MachineNo),
  
  constraint FKStockParts foreign key (PartNo) References Part(PartNo),
  
  constraint FKStockSupplier foreign key (SupplierNo) references Supplier(SupplierNo)

);

--This is the content for the Stock table
use COCOFitness;
insert into Supplier
(MachineNo, MachineName)
values ('001', 'Bench Press'),
       ('002', 'Treadmill'),
       ('003', 'Dumbbell'),
	   ('004', 'Rowing Machine'),
	   ('005', 'Shoulder Press');

Use COCOFitness
--This makes the Order table
Create table Orders
(
  OrderNo VarChar(3),
  OrderDate char(8),
  RentalDuration  datetime,
  Delivered  char(3),
  CustomerNo  char(3),
  

  constraint PKOrders primary key (OrderNo),

   constraint FKOrderCustomer foreign key (CustomerNo) references Customer(CustomerNo)
);
go

--This is the content for the Order table
use COCOFitness;
insert into Customer
(
 OrderNo, OrderDate, Delivered
)
values('001','14/08/20','Yes'),
      ('002','22/10/20','Yes'),
      ('003','10/09/20','Yes');
Use COCOFitness
--This makes the OrderDetails table
Create table OrderDetails
(
  OrderNo VarChar(3),
  MachineNo VarChar(3),
  Delivered Char(3),
  CustomerNo  char(3),
  RentalDuration Date

  constraint PKOrder primary key (OrderNo),

   constraint FKOrderDetMachine foreign key (MachineNo) references Stock(MachineNo),
   constraint FKOrderDetCustomer foreign key (CustomerNo) references Customer(CustomerNo)
);
go

--This is the content for the Stock table
use COCOFitness;
insert into OrderDetails
(OrderNo, MachineNo, Delivered, CustomerNo)
values ('001', 'Bench Press','Yes','1');

use COCOFitness
--This makes the OrderRepair table
Create table OrderRepair
(
  OrderNo VarChar(3),
  MachineNo Char(15),
  PartNo Varchar(3),
  PartName char(15),
  EngineerNo varchar(3),
  

  
  constraint PKOrderRepair primary key (OrderNo, EngineerNo),
  
  constraint FKRepairParts foreign key (PartNo) References Parts(PartNo),
  
  constraint FKRepairEngineer foreign key (EngineerNo) references Engineer(EngineerNo)

);

use COCOFitness;
insert into OrderRepair
( EngineerNo)

values('1'),
      ('2'),
	  ('3'),
	  ('4');
