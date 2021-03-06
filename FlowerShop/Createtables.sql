﻿CREATE TABLE [dbo].[Flowers] (
    [FlowerID]      INT           IDENTITY (1, 1) NOT NULL,
    [FlowerName]       NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([FlowerID] ASC)
);
CREATE TABLE [dbo].[Bouquets] (
    [BouquetID] INT           IDENTITY (1, 1) NOT NULL,
    [BouquetName]    NVARCHAR (50) NULL,
	[Description]    NVARCHAR (100) NULL,
    [Price]  DECIMAL(8,2)           NULL,
    PRIMARY KEY CLUSTERED ([BouquetID] ASC)
);
CREATE TABLE [dbo].[FlowerBouquets] (
    [FlowerBouquetID] INT IDENTITY (1, 1) NOT NULL,
    [BouquetID]     INT NOT NULL,
    [FlowerID]    INT NOT NULL,
	[Quantity]    INT NULL,
    PRIMARY KEY CLUSTERED ([FlowerBouquetID] ASC),
    CONSTRAINT [FK_dbo.FlowerBouquets_dbo.Bouquets_BouquetID] FOREIGN KEY ([BouquetID]) 
        REFERENCES [dbo].[Bouquets] ([BouquetID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FlowerBouquets_dbo.Flowers_FlowerID] FOREIGN KEY ([FlowerID]) 
        REFERENCES [dbo].[Flowers] ([FlowerID]) ON DELETE CASCADE)
