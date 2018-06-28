CREATE TABLE [dbo].[TourEvents]
(
    [EventID] INT NOT NULL,
	[EventDate] DATE NOT NULL,
	[Fee] MONEY NOT NULL,
	[TourName] NVARCHAR (20) NOT NULL,
	CONSTRAINT PK_EventID PRIMARY KEY (EventID),
	CONSTRAINT FK_TourEvents_TourName FOREIGN KEY (TourName) REFERENCES Tours (TourName)
)
