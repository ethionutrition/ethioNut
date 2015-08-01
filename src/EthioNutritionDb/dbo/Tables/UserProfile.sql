CREATE TABLE [dbo].[UserProfile]
(
	[ProfileId] BIGINT NOT NULL PRIMARY KEY, 
    [UserBirthDate] DATETIME NOT NULL, 
    [UserHeightInMeter] FLOAT NOT NULL, 
    [UserWeightInKg] FLOAT NOT NULL, 
    [UserBMI] FLOAT NOT NULL, 
    [ts] ROWVERSION NOT NULL
)
