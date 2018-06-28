CREATE TABLE [dbo].[Clients]
(
	[ClientID] INT NOT NULL,
	[Surname] NVARCHAR(100) NOT NULL,
	[GivenName] NVARCHAR(100) NOT NULL,
	[Gender] NVARCHAR(1) NOT NULL,
	Constraint PK_ClientID PRIMARY KEY (ClientID)

)
