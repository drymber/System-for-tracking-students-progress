USE StudentsProgress
GO

DROP TABLE tblMarks;

DROP TABLE tblStudentAnswer;

DROP TABLE tblQuestion;

DROP TABLE tblTopic;

DROP TABLE tblStudent;

DROP TABLE tblGroup;

DROP TABLE tblUser;



DROP PROC spAddGroup;

DROP PROC spAddMark;

DROP PROC spAddQuestion;

DROP PROC spAddStudent;

DROP PROC spAddStudentsAnswer;

DROP PROC spAddTopic;

DROP PROC spDeleteGroup;

DROP PROC spDeleteQuestion;

DROP PROC spDeleteStudent;

DROP PROC spDeleteTopic;

DROP PROC spGetInfoAboutStudentsTest;

DROP PROC spGetMarks;

DROP PROC spGetStudents;

DROP PROC spGetTopicsQuestions;

DROP PROC spGetUserByLogin



DROP FUNCTION fnGetUser;

DROP FUNCTION fnIsTestAlreadyChecked;