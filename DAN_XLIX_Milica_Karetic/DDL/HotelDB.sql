-- Dropping the tables before recreating the database in the order depending how the foreign keys are placed.
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL DROP TABLE tblEmployee;
IF OBJECT_ID('tblManager', 'U') IS NOT NULL DROP TABLE tblManager;
IF OBJECT_ID('tblUser', 'U') IS NOT NULL DROP TABLE tblUser;
if OBJECT_ID('vwEmployee','v') IS NOT NULL DROP VIEW vwEmployee;
if OBJECT_ID('vwManager','v') IS NOT NULL DROP VIEW vwManager;

-- Checks if the database already exists.
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelDB')
CREATE DATABASE HotelDB;
GO

USE HotelDB

CREATE TABLE tblUser(
	UserID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR (13) NOT NULL,
	DateOfBirth date not null,
	Email varchar(50) not null,
	Username varchar(50) unique not null,
	Password varchar(50) not null
);

CREATE TABLE tblEmployee(
	EmployeeID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Floor int not null,
	Gender char not null,
	Citizenship varchar(50) not null,
	Engagement varchar(30) not null,
	Salary varchar(40) not null,
	UserID INT FOREIGN KEY REFERENCES tblUser(UserID) NOT NULL,
);


CREATE TABLE tblManager(
	ManagerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Floor int not null,
	Experience int not null,
	QualificationsLevel int not null,
	UserID INT FOREIGN KEY REFERENCES tblUser(UserID) NOT NULL,
);


GO
CREATE VIEW vwEmployee AS
	SELECT	tblUser.*, 
			tblEmployee.Floor, tblEmployee.Gender, tblEmployee.Citizenship, 
			tblEmployee.Engagement, tblEmployee.Salary
	FROM	tblUser, tblEmployee
	WHERE	tblUser.UserID = tblEmployee.UserID


GO
CREATE VIEW vwManager AS
	SELECT	tblUser.*, 
			tblManager.Floor, tblManager.Experience, tblManager.QualificationsLevel
	FROM	tblUser, tblManager 
	WHERE	tblUser.UserID = tblManager.UserID


