﻿CREATE TABLE [dbo].[equipment] (
    [name]  NVARCHAR (MAX) NOT NULL,
    [empID] INT            NOT NULL,
    [description]  NVARCHAR (MAX) NOT NULL,
    [phone] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([empID] ASC)
);

