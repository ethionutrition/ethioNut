CREATE TABLE [dbo].[UserProfile]
(
	[ProfileId] BIGINT NOT NULL PRIMARY KEY, 
    [UserBirthDate] DATETIME NULL, 
    [UserHeightInMeter] FLOAT NULL, 
    [UserWeightInKg] FLOAT NULL, 
    [UserBMI] FLOAT NULL, 
    [ts] ROWVERSION NOT NULL
)
