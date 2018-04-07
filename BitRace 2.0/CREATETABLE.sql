CREATE TABLE Questions
(
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Difficulty NVARCHAR(255),
	[Text] NVARCHAR(255)
);

CREATE TABLE Answers
(
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Question_ID INT,
	Character_Key CHAR,
	[Text] NVARCHAR(255),
	IsCorrectAnswer BIT,
	FOREIGN KEY(Question_ID) REFERENCES Questions(ID)
);

CREATE TABLE Players
(
	ID INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(255),
	Score INT
);