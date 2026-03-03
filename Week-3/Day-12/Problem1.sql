CREATE DATABASE EventDb

USE EventDb

CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    [Role] VARCHAR(50) NOT NULL CHECK (Role IN('Admin','Participant')),
    [Password] VARCHAR(20) NOT NULL CHECK (LEN(PASSWORD) BETWEEN 6 AND 20)

);

INSERT INTO UserInfo VALUES
('durga@gmail.com','Durga Prasad','Participant', 'durga123'),
('admin@gmail.com','Admin User', 'Admin', 'admin123');


CREATE TABLE EventDetails
(
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    [Description] VARCHAR(255),
    [Status] VARCHAR(20) CHECK([Status] in ('Active','In-Active'))

);

INSERT INTO EventDetails VALUES
(1, '.NET Full Stack Developer Training', 'Software Development', 
 '2026-04-20', 
 'Hands-on .NET and SQL Server training', 
 'Active'),
 (2, 'Python Full Stack Developer Training','Web Development',
'2026-03-20',
'Hands-on Python and Web Development Training',
'In-Active'
 );

CREATE TABLE SpeakersDetails
(
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL

);

INSERT INTO SpeakersDetails VALUES
(101, 'Narasimha Sir'),
(102, 'Venkat Sir');


CREATE TABLE SessionInfo
(
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    [Description] VARCHAR(255),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)

);

INSERT INTO SessionInfo VALUES
(1001, 1, 'Introduction to .NET', 101,
 'Overview of .NET and C# Basics',
 '2026-04-20 10:00:00',
 '2026-04-20 11:30:00',
 'https://meetlink.com/dotnet'),

(1002, 2, 'Python Basics', 102,
 'Introduction to Python and Web Concepts',
 '2026-03-20 09:00:00',
 '2026-03-20 10:30:00',
 'https://meetlink.com/python');

CREATE TABLE ParticipantEventDetails
(
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK(IsAttended in (0,1)),
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)

);

INSERT INTO ParticipantEventDetails VALUES
(1, 'durga@gmail.com', 1, 1001, 1),
(2, 'durga@gmail.com', 2, 1002, 0);
