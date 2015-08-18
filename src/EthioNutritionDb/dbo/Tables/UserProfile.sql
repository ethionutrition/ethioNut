CREATE TABLE [dbo].[UserProfile]
(
	[ProfileId] BIGINT  IDENTITY (1, 1) NOT NULL,
    [UserBirthDate] DATETIME NULL, 
    [UserHeightInMeter] FLOAT NULL, 
    [UserWeightInKg] FLOAT NULL, 
    [UserBMI] FLOAT NULL, 
    [ts] ROWVERSION NOT NULL,
	PRIMARY KEY CLUSTERED ([ProfileId] ASC)
)
