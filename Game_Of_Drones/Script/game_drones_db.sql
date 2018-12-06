CREATE TABLE [drones]..tblRounds(
RoundID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstPlayerName VARCHAR(40) NOT NULL,
SecondPlayerName VARCHAR(40) NOT NULL,
FirstPlayerMove VARCHAR(40) NOT NULL,
SecondPlayerMove VARCHAR(40) NOT NULL,
GameNumber int NOT NULL,
Winner VARCHAR(40),
RoundNumber int,
);
GO

CREATE TABLE [drones]..tblMoves(
MoveID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
MoveName VARCHAR(20) NOT NULL,
Kills VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE [drones]..tblScores(
ScoreID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
PlayerName VARCHAR(40) NOT NULL,
GamesWon int,
);
GO

INSERT INTO [drones]..tblMoves VALUES ('Paper','Rock');
INSERT INTO [drones]..tblMoves VALUES ('Rock','Scissors');
INSERT INTO [drones]..tblMoves VALUES ('Scissors','Paper');