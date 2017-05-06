CREATE TABLE [dbo].[Game]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Count] INT NOT NULL
)
INSERT INTO [dbo].[Game] ([Title], [Count]) VALUES (N'3 x 3', 9)
INSERT INTO [dbo].[Game] ([Title], [Count]) VALUES (N'5 x 5', 25)
INSERT INTO [dbo].[Game] ([Title], [Count]) VALUES (N'7 x 7', 49)

CREATE TABLE [dbo].[Results]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [TimeGame] TIMESTAMP NOT NULL, 
    [CountSteps] INT NOT NULL, 
    [idgame] INT NOT NULL,
CONSTRAINT gameForeign FOREIGN KEY (idgame) REFERENCES Game
)