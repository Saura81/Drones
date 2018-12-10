USE [master]
GO

CREATE TABLE tblRounds(
RoundID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstPlayerName VARCHAR(40) NOT NULL,
SecondPlayerName VARCHAR(40) NOT NULL,
FirstPlayerMove VARCHAR(40),
SecondPlayerMove VARCHAR(40) ,
Winner VARCHAR(40),
);
GO

CREATE TABLE tblMoves(
MoveID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
MoveName VARCHAR(20) ,
Kills int,
);
GO

CREATE TABLE tblScores(
ScoreID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
PlayerName VARCHAR(40) NOT NULL,
GamesWon int,
);
GO

INSERT INTO tblMoves VALUES ('Paper',2);
INSERT INTO tblMoves VALUES ('Rock',3);
INSERT INTO tblMoves VALUES ('Scissors',1);