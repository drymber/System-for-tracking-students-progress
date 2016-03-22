CREATE DATABASE StudentsProgress
GO

USE StudentsProgress
GO

CREATE TABLE tblGroup
(
	Id INT NOT NULL IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	AcademicYear INT NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblGoup_Id PRIMARY KEY(Id),
	CONSTRAINT CK_tblGroup UNIQUE(Name, AcademicYear)
);

CREATE TABLE tblStudent
(
	Id INT NOT NULL IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Age INT,
	GroupId INT NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblStudent_Id PRIMARY KEY(Id),
	CONSTRAINT FK_tblStudent_GroupId_tblGroup_Id FOREIGN KEY(GroupId) REFERENCES tblGroup(Id),
	CONSTRAINT UQ_tblStudent_PhoneNumber UNIQUE(PhoneNumber),
	CONSTRAINT UQ_tblStudent_Email UNIQUE(Email),
);

CREATE TABLE tblTopic
(
	Id INT NOT NULL IDENTITY(1,1),
	Title NVARCHAR(50),
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblTopic_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_tblTopic_Title UNIQUE(Title)
);

CREATE TABLE tblQuestion
(
	Id INT NOT NULL IDENTITY(1,1),
	Question NVARCHAR(MAX) NOT NULL,
	Answer NVARCHAR(50) NOT NULL,
	TopicId INT NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblQuestion_Id PRIMARY KEY(Id),
	CONSTRAINT FK_tblQuestion_TopicId_tblTopic_Id FOREIGN KEY(TopicId) REFERENCES tblTopic(Id),
);

CREATE TABLE tblStudentAnswer
(
	Id INT NOT NULL IDENTITY(1,1),
	QuestionId INT NOT NULL,
	StudentId INT NOT NULL,
	IsCorrect BIT NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblStudentAnswer_Id PRIMARY KEY(Id),
	CONSTRAINT FK_tblStudentAnswer_QuestionId_tblQuestion_Id FOREIGN KEY(QuestionId) REFERENCES tblQuestion(Id),
	CONSTRAINT FK_tblStudentAnswer_StudentId_tblStudent_Id FOREIGN KEY(StudentId) REFERENCES tblStudent(Id)
);

CREATE TABLE tblMarks
(
	Id INT NOT NULL IDENTITY(1, 1),
	StudentId INT NOT NULL,
	TopicId INT NOT NULL,
	Mark NUMERIC(18, 4) NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_tblMark_Id PRIMARY KEY(Id),
	CONSTRAINT FK_tblMarks_StudentId_tbStudent_Id FOREIGN KEY(StudentId) REFERENCES tblStudent(Id),
	CONSTRAINT FK_tblMarks_TopicId_tblTopic_Id FOREIGN KEY(TopicId) REFERENCES tblTopic(Id)
);

CREATE TABLE tblUser
(
	Id INT NOT NULL IDENTITY(1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Login] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Disabled] BIT NOT NULL,
	CONSTRAINT PK_tblUser_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_tblUser_Username UNIQUE([Login])
);
