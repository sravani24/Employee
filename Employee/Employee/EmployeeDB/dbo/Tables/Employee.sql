CREATE TABLE [dbo].[Employee] (
    [EmployeeID] INT          IDENTITY (1, 1) NOT NULL,
    [First Name] VARCHAR (50) NOT NULL,
    [Last Name]  VARCHAR (50) NULL,
    [Department] VARCHAR (50) NOT NULL,
    [Contact No] VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NOT NULL,
    [State]      VARCHAR (50) NOT NULL,
    [City]       VARCHAR (50) NOT NULL
);

