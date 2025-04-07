USE master
If EXISTS(Select * From sys.databases Where name = 'CLDV6211POE')
Drop database CLDV6211POE
Create Database CLDV6211POE

Use CLDV6211POE

Create table Venue(
VenueID Int Identity (1,1) PRIMARY KEY not null, 
VenueName VarChar(250) not null ,
Location VarChar(250) not null ,
Capacity VarChar(250) not null ,
ImageURL VarChar(250) not null 
);

Create table Event(
EventID Int Identity (1,1) PRIMARY KEY not null, 
EventName VarChar(250) not null ,
EventDate Date not null ,
Description VarChar(250) not null ,
VenueID int,Foreign KEY (VenueID) References Venue(VenueID)
);

Create table Booking(
BookingID Int Identity (1,1) PRIMARY KEY not null, 
BookingDate Date not null ,
EventID int,Foreign KEY (EventID) References Event(EventID),
VenueID int,Foreign KEY (VenueID) References Venue(VenueID)
);


