CREATE TABLE [dbo].[City] (
    [StateID]  INT          NOT NULL,
    [CityID]   INT          IDENTITY (1, 1) NOT NULL,
    [CityName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK__City__F2D21A96060DEAE8] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [FK__City__StateID__07F6335A] FOREIGN KEY ([StateID]) REFERENCES [dbo].[State] ([StateID])
);

