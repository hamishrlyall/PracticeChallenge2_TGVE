CREATE TABLE [dbo].[Bookings]
(
	[BookingID] INT NOT NULL,
	[ClientID] INT NOT NULL,
	[TourName] NVARCHAR(20) NOT NULL,
	[EventID] INT NOT NULL,
	[EventDate] DATE NOT NULL,
	[Payment] MONEY NOT NULL,
	[DateBooked] DATE NOT NULL,
	CONSTRAINT PK_BookingID PRIMARY KEY (BookingID),
	CONSTRAINT FK_Bookings_ClientID FOREIGN KEY (ClientID) REFERENCES Clients (ClientID),
	CONSTRAINT FK_Bookings_TourName FOREIGN KEY (TourName) REFERENCES Tours (TourName),
	CONSTRAINT FK_Bookings_EventID FOREIGN KEY (EventID) REFERENCES TourEvents (EventID)
)