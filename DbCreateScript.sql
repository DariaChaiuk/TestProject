CREATE database RegistrationDynamic
GO
Use RegistrationDynamic
GO
Create Table RegistrationByMonth(
	Id Int Identity(1,1) Primary Key,
	Year Int Not Null,
	Month NVARCHAR(50) NOT NULL,
	NumberOfUsers Int Not Null
)


Create Table RegistartionByDevice(
	Id Int Identity(1,1) Primary Key,
	Year Int Not Null,
	Month NVARCHAR(50) NOT NULL,
	Device NVARCHAR(50) Not Null,  
	NumberOfUsers Int Not Null
)

Create Table SessionsByHour(
	Id Int Identity(1,1) Primary Key,
	Hour datetime CHECK(Hour <= getdate()) NOT NULL,
	MaxSessions Int Not Null
)

Create Table SessionsMoreOneDevice(
		Id Int Identity(1,1) Primary Key,
		UserName NVARCHAR(100) NOT NULL,
		DeviceName NVARCHAR(100) NOT NULL,
		LoginTS datetime CHECK(LoginTS <= getdate()) NOT NULL
)

Create Table SessionDuration(
	Id Int Identity(1,1) Primary Key,
	Date date CHECK(Date <= getdate()) NOT NULL,
	Hour Int Not Null,
	TotalSessionDurationForHour Int Not NULL,
	TotalSessionDuration Int Not NULL
)

Create Table LogginAnotherCountry(
	Id Int Identity(1,1) Primary Key,
	UserName NVARCHAR(100) NOT NULL,
	Country NVARCHAR(100) NOT NULL,
	LoginTS datetime CHECK(LoginTS <= getdate()) NOT NULL
)

Insert RegistrationByMonth(Year, Month, NumberOfUsers) Values
(2020, 'August', 13),
(2020, 'September', 5),
(2020, 'October', 7),
(2021, 'January', 9),
(2021, 'February', 6),
(2021, 'July', 32)

Insert RegistartionByDevice(Year, Month, Device, NumberOfUsers) Values
(2020, 'August', 'Laptop', 10),
(2020, 'August', 'Mobile phone', 3),
(2020, 'September', 'Laptop', 5),
(2021, 'July', 'Laptop', 15),
(2021, 'July', 'Mobile phone', 8),
(2021, 'July', 'Tablet', 9)

Insert SessionsByHour(Hour, MaxSessions) Values
('2021-07-01 13:00:00', 3),
('2021-07-01 14:00:00', 23),
('2021-07-01 15:00:00', 19),
('2021-07-01 16:00:00', 10),
('2021-07-01 17:00:00', 15),
('2021-07-01 18:00:00', 8)

Insert SessionsMoreOneDevice(UserName, DeviceName,LoginTS) Values
('John Doe', 'John’s Laptop', '2021-07-01 17:35:18'),
('John Doe', 'John’s Mobile phone', '2021-07-01 17:55:47'),
('Kathy Johnson', 'My Macbook', '2021-07-01 18:11:23'),
('Kathy Johnson', 'My IPhone', '2021-07-01 18:13:26'),
('Kathy Johnson', 'My IPad', '2021-07-01 18:29:31')

Insert SessionDuration(Date, Hour, TotalSessionDurationForHour, TotalSessionDuration) Values
('2021-06-29', 0, 500, 500),
('2021-06-29', 1, 342, 842),
('2021-06-29', 2, 100, 942),
('2021-06-29', 3, 400, 1342),
('2021-06-29', 23, 154, 15643),
('2021-06-30', 0, 100, 100),
('2021-06-30', 1, 200, 300),
('2021-07-01', 0, 450, 450),
('2021-07-01', 1, 200, 650),
('2021-07-01', 18, 100, 21350)Insert LogginAnotherCountry(UserName, Country, LoginTS) Values ('John Doe', 'Switzerland', '2021-07-01 17:35:18'),
('Kathy Johnson', 'Turkey', '2021-07-01 18:11:23')