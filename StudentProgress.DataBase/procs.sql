USE StudentsProgress
GO

----------------------------------------Getting procedures----------------------------------------------

CREATE PROC spGetStudents 
	@firstName NVARCHAR(50) = '',
	@lastName NVARCHAR(50) = '',
	@group NVARCHAR(50),
	@groupYear INT = 2016
AS
BEGIN 
	DECLARE @groupId INT;
	SELECT @groupId = Id FROM tblGroup WHERE Name = @group AND AcademicYear = @groupYear AND IsDeleted <> 1;
	SELECT tblStudent.Id, FirstName, LastName, PhoneNumber, Email, Age, tblGroup.Name AS GroupName, AcademicYear
	FROM tblStudent 
	JOIN tblGroup ON tblStudent.GroupId = tblGroup.Id
	WHERE FirstName LIKE ('%' + @firstName + '%')
	AND LastName LIKE ('%' + @lastName + '%')
	AND GroupId = @groupId
	AND tblStudent.IsDeleted <> 1;
END
GO


CREATE PROC spGetInfoAboutStudentsTest
	@studentId INT,
	@topic NVARCHAR(50) = ''
AS
BEGIN
	DECLARE @topicId INT;
	SELECT @topicId = Id FROM tblTopic WHERE Title = @topic;

	SELECT tblQuestion.Id, Question, Answer, tblTopic.Id, IsCorrect
	FROM tblQuestion
	JOIN tblStudentAnswer 
	ON tblQuestion.Id = tblStudentAnswer.QuestionId
	JOIN tblStudent 
	ON tblStudent.Id = tblStudentAnswer.StudentId
	JOIN tblTopic 
	ON tblQuestion.TopicId = tblTopic.Id
	WHERE tblStudent.Id = @studentId
	AND tblTopic.Id = @topicId
	AND tblStudent.IsDeleted <> 1 
	AND tblTopic.IsDeleted <> 1
END
GO

CREATE PROC spGetTopicsQuestions
	@topic NVARCHAR(50)
AS
BEGIN
	SELECT q.Id, q.Question, q.Answer, q.TopicId
	FROM tblQuestion q
	JOIN tblTopic t ON q.TopicId = t.Id
	WHERE t.Title = @topic
	AND t.IsDeleted <> 1
END
GO

CREATE PROC spGetMarks
	@studentId INT
AS
BEGIN
	SELECT tblMarks.Id, tblTopic.Title, Mark
	FROM tblMarks
	JOIN tblTopic ON tblMarks.TopicId = tblTopic.Id
	WHERE StudentId = @studentId
	AND tblMarks.IsDeleted <> 1
	AND tblTopic.IsDeleted <> 1
END
GO

CREATE PROC spGetUserByLogin
	@login NVARCHAR(50),
	@password NVARCHAR(50)
AS 
BEGIN
	SELECT Id, FirstName, LastName, [Login]
	FROM tblUser 
	WHERE [Login] = @login AND [Password] = @password AND [Disabled] <> 1
END
GO


---------------------------------------------Adding procedures-------------------------------------------------------

CREATE PROC spAddStudent
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@phoneNumber NVARCHAR(50),
	@email NVARCHAR(50),
	@age INT,
	@group NVARCHAR(50),
	@year INT,
	@studentId INT OUT
AS
BEGIN
	IF EXISTS (SELECT * FROM tblStudent WHERE FirstName = @firstName AND LastName = @lastName AND Email = @email)
		RAISERROR('Student already exist', 50001, 1)
	ELSE
	BEGIN
		DECLARE @groupId INT;
		SELECT @groupId = Id FROM tblGroup WHERE Name = @group AND AcademicYear = @year;
		INSERT INTO tblStudent(FirstName, LastName, PhoneNumber, Email, Age, GroupId) VALUES
			(@firstName, @lastName, @phoneNumber, @email, @age, @groupId);
		SELECT @studentId = @@IDENTITY;
	END
END
GO


CREATE PROC spAddStudentsAnswer
	@studentId INT,
	@questionId INT,
	@isCorrect BIT,
	@studentAnswerId INT OUT
AS
BEGIN
	INSERT INTO tblStudentAnswer(StudentId, QuestionId, IsCorrect) VALUES
		(@studentId, @questionId, @isCorrect)
	SELECT @studentAnswerId = @@IDENTITY;
END
GO


CREATE PROC spAddMark
	@studentId INT,
	@topicId INT,
	@mark numeric(18, 4),
	@markId INT OUT
AS
BEGIN
	INSERT INTO tblMarks(StudentId, TopicId, Mark) VALUES
		(@studentId, @topicId, @mark);
	SELECT @markId = @@IDENTITY;
END
GO

CREATE PROC spAddGroup
	@name NVARCHAR(50),
	@year INT,
	@groupId INT OUT
AS
BEGIN
	IF EXISTS (SELECT * FROM tblGroup WHERE Name = @name AND AcademicYear = @year)
		RAISERROR('Group already exist', 1, 1)
	ELSE
	BEGIN
		INSERT INTO tblGroup(Name, AcademicYear) VALUES
			(@name, @year)
		SELECT @groupId = @@IDENTITY;
	END
END
GO


CREATE PROC spAddTopic
	@title NVARCHAR(50),
	@topicId INT OUT
AS
BEGIN
	INSERT INTO tblTopic(Title) VALUES
		(@title)
	SELECT @topicId = @@IDENTITY
END
GO


CREATE PROC spAddQuestion
	@question NVARCHAR(50),
	@answer NVARCHAR(50),
	@topic NVARCHAR(50),
	@questionId INT OUT
AS
BEGIN
	DECLARE @topicId INT;
	SELECT @topicId = Id FROM tblTopic WHERE Title = @topic
	IF EXISTS (SELECT * FROM tblQuestion WHERE Question = @question AND TopicId = @topicId)
		RAISERROR('The question already exist', 1, 1)
	ELSE
	BEGIN
		INSERT INTO tblQuestion(Question, Answer, TopicId) VALUES
			(@question, @answer, @topicId)
		SELECT @questionId = @@IDENTITY
	END
END
GO

---------------------------------------------------Functions-----------------------------------------------------------

CREATE FUNCTION fnIsTestAlreadyChecked(@studentId INT, @topic NVARCHAR(50))
RETURNS BIT
AS 
BEGIN
	DECLARE @alreadyExist BIT
	IF EXISTS (SELECT * FROM  tblMarks 
				JOIN tblTopic ON tblMarks.TopicId = tblTopic.Id
				WHERE StudentId = @studentId AND tblTopic.Title = @topic)
		SET @alreadyExist = 1;
	ELSE 
		SET @alreadyExist = 0;
	RETURN @alreadyExist;
END
GO


---------------------------------------------Deleting procedures-------------------------------------

CREATE PROC spDeleteStudent
	@studentId INT
AS
BEGIN
	UPDATE tblStudent 
	SET IsDeleted = 1
	WHERE Id = @studentId

	UPDATE tblStudentAnswer 
	SET IsDeleted = 1
	WHERE StudentId = @studentId

	UPDATE tblMarks 
	SET IsDeleted = 1
	WHERE StudentId = @studentId
END
GO


CREATE PROC spDeleteGroup
	@name NVARCHAR(50),
	@year INT
AS
BEGIN
	DECLARE @groupId INT;
	SELECT @groupId = Id FROM tblGroup WHERE Name = @name AND AcademicYear = @year;
	UPDATE tblGroup
	SET IsDeleted = 1
	WHERE Id = @groupId;

	WHILE EXISTS(SELECT Id FROM tblStudent WHERE GroupId = @groupId) 
	BEGIN
		EXEC spDeleteStudent (SELECT TOP 1 Id FROM tblStudent WHERE GroupId = @groupId)
	END
END
GO


CREATE PROC spDeleteQuestion
	@questionId INT
AS
BEGIN
	UPDATE tblQuestion
	SET IsDeleted = 1
	WHERE Id = @questionId
END
GO

CREATE PROC spDeleteTopic 
	@title NVARCHAR(50)
AS 
BEGIN
	DECLARE @topicId INT;
	SELECT @topicId = Id FROM tblTopic WHERE Title = @title;
	UPDATE tblTopic
	SET IsDeleted = 1
	WHERE Id = @topicId;

	UPDATE tblQuestion
	SET IsDeleted = 1
	WHERE TopicId = @topicId

	UPDATE tblMarks 
	SET IsDeleted = 1
	WHERE TopicId = @topicId
END
GO