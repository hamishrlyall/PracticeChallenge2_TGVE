/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF '$(LoadTestData)' = 'true'

BEGIN

DELETE FROM Bookings
DELETE FROM Clients
DELETE FROM TourEvents
DELETE FROM Tours

INSERT INTO TOURS (TourName, [Description]) VALUES
('West', 'Tour of wineries and outlets of the Geelong and Otways region'),
('East', 'Tour of wineries and outlets of the Yarra Valley'),
( 'South', 'Tour of wineries and outlets of Mornington Penisula'),
('North', 'Tour of wineries and outlets of the Bedigo and Castlemaine region');

INSERT INTO Clients (ClientID, Surname, GivenName, Gender) VALUES
(1,	'Price', 'Taylor', 'M'),
(2,	'Gamble', 'Ellyse',	'F'),
(3, 'Tan', 'Tilly', 'F');

INSERT INTO TourEvents (EventID, TourName, EventDate, Fee) VALUES
(1,'North', '2016.01.09', $200.00),
(2,'North', '2016.02.13', $225.00),
(3,'South', '2016.01.16', $200.00),
(4,'West', '2016.01.29', $225.00);

INSERT INTO Bookings (BookingID, ClientID, TourName, EventID, EventDate, Payment, DateBooked) VALUES
(1, 1, 'North', 1, '2016.01.09', $200.00, '2015.12.10'),
(2, 2, 'North', 1, '2016.01.09', $200.00, '2015.12.16'),
(3, 1, 'North', 2, '2016.02.13', $225.00, '2016.01.08'),
(4, 2, 'North', 2, '2016.02.13', $225.00, '2015.01.14'),
(5, 3, 'North', 2, '2016.02.13', $225.00, '2015.02.03'),
(6, 1, 'South', 3, '2016.01.16', $200.00, '2015.12.10'),
(7, 2, 'South', 3, '2016.01.16', $200.00, '2015.12.18'),
(8, 3, 'South', 3, '2016.01.16', $200.00, '2015.12.10'),
(9, 2, 'West', 4, '2016.01.29', $200.00, '2015.12.1'),
(10, 3, 'West', 4, '2016.01.29', $200.00, '2015.12.18');


END;
