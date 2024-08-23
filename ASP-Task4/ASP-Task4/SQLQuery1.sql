CREATE DATABASE MyProductDb
go
USE MyProductDb
go
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Title NVARCHAR(50) NOT NULL
)

GO 
CREATE TABLE Products(
Id int primary key identity(1,1) not null,
[Name] NVARCHAR (50) not null,
Price money not null default(0)
)