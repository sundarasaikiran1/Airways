create table loginData
(PassportNo varchar(20),Name varchar(30),emailId varchar(30),Passwd varchar(10))


create table flight
(flightId varchar(10) NOT NULL PRIMARY KEY,origin varchar(10),Destination varchar(10),DateOfTravel Varchar(20),TravelTime varchar(20),distance varchar(20), price float,AvailbleSeats int)

Alter table flight 
Select * from flight


insert into flight Values ('DH001','Delhi','Hyderabad','Sunday','3 AM','1253 KM',4500,50)
insert into flight Values ('DC002','Delhi','Chennai','Monday',' 10 AM','1653 KM',4900,50)
insert into flight Values ('DM003','Delhi','Mumbai','Tuesday','4 PM','1353 KM',3500,50)
insert into flight Values ('DP004','Delhi','Pune','Wednesday','10 AM','1422 KM',5500,50)
insert into flight Values ('DK005','Delhi','Kolkata','Thursday',' 6 PM','1053 KM',3500,50)

insert into flight Values ('HD001','Hyderabad','Delhi','Monday','9 AM','1253 KM',4500,50)
insert into flight Values ('HC002','Hyderabad','Chennai','Tuesday','9 PM','753 KM',2500,50)
insert into flight Values ('HM003','Hyderabad','Mumbai','Wednesday','7 AM','1003 KM',3500,50)
insert into flight Values ('HP004','Hyderabad','Pune','Thursday','11 AM','800 KM',2500,50)
insert into flight Values ('HK005','Hyderabad','Kolkata','Friday','3 PM','1113 KM',2500,50)


insert into flight Values ('CD001','Chennai','Delhi','Tuesday','10 AM','1653 KM',4900,50)
insert into flight Values ('CH002','Chennai','Hyderabad','Wednesday','1! AM','753 KM',2500,50)
insert into flight Values ('CM003','Chennai','Mumbai','Thursday','9 AM','1665 KM',2567,50)
insert into flight Values ('CP004','Chennai','Pune','Friday','8 AM','3245KM',4923,50)
insert into flight Values ('CK005','Chennai','Kolkata','Saturday','7 AM','1645 KM',4521,50)


insert into flight Values ('MD001','Mumbai','Delhi','Thursday','8 PM','1853 KM',3500,50)
insert into flight Values ('MH002','Mumbai','Hyderabad','Fridayday','9 PM','753 KM',3500,50)
insert into flight Values ('MC003','Mumbai','Chennai','Saturday','10 PM','1665 KM',2567,50)
insert into flight Values ('MP004','Mumbai','Pune','Sunday','11 PM','1422 KM',5900,50)
insert into flight Values ('MK005','Mumbai','Kolkata','Monday','12 PM','1853 KM',3900,50)



insert into flight Values ('PD001','Pune','Delhi','Wednesday','11 AM','1422 KM',5500,50)
insert into flight Values ('PH002','Pune','Hyderabad','Thursday','10 AM','1673 KM',2500,50)
insert into flight Values ('PC003','Pune','Chennai','Friday','9 AM','3245 KM',4923,50)
insert into flight Values ('PM004','Pune','Mumbai','Saturday','8 AM','1422 KM',5900,50)
insert into flight Values ('PK005','Pune','Kolkata','Sunday','7 PM','1422 KM',5513,50)

insert into flight Values ('KD001','Kolkata','Delhi','Thursday',' 5 pM','1053 KM',3500,50)
insert into flight Values ('KH002','Kolkata','Hyderabad','Friday',' 6 pM','1113 KM',2500,50)
insert into flight Values ('KC003','Kolkata','Chennai','Saturday',' 7 pM','1645 KM',3900,50)
insert into flight Values ('KM004','Kolkata','Mumbai','Sunday',' 8 pM','1853 KM',3900,50)
insert into flight Values ('KP005','Kolkata','Pune','Monday',' 9 pM','1422 KM',5900,50)