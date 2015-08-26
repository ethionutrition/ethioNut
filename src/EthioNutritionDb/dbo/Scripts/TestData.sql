
declare 
	@userId uniqueidentifier

if not exists(select * from dbo.aspnet_Applications where ApplicationId = '8b2e549a-c283-46f2-b481-25136daa9059')
	insert into dbo.aspnet_Applications(ApplicationName, LoweredApplicationName, ApplicationId)
		values('/', '/', '8b2e549a-c283-46f2-b481-25136daa9059')

if not exists (select * from aspnet_Roles where RoleId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')
	INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) 
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e', N'UserCreators', N'usercreators', NULL)

if not exists (select * from aspnet_Roles where RoleId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')
	INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) 
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f', N'Administrators', N'Administrators', NULL)

if not exists (select * from [aspnet_Users] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')
	INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) 
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e', N'webform@ethionutrition.com', N'webform@ethionutrition.com', NULL, 0, CAST(0x0000A100003CF03D AS DateTime))

if not exists (select * from [aspnet_Users] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')
	INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) 
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f', N'yordan.desta@gmail.com', N'yordan.desta@gmail.com', NULL, 0, CAST(0x0000A100003CF03D AS DateTime))

if not exists(select * from aspnet_UsersInRoles where userId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e' and roleId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')
	INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) 
		VALUES (N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')

if not exists(select * from aspnet_UsersInRoles where userId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f' and roleId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')
	INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) 
		VALUES (N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')

if not exists (select * from [aspnet_Membership] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')
	INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment])
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e', N'Cd2DIcbwqkLCpZf4OUh1TahrK1I=', 1, N'Wb9LMh5+xpcVjqCQFFcJeQ==', NULL, N'webform@ethionutrition.com', N'webform@ethionutrition.com', NULL, NULL, 1, 0, CAST(0x0000A0E600088AB8 AS DateTime), CAST(0x0000A100003CF03D AS DateTime), CAST(0x0000A0E600088AB8 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)

if not exists (select * from [aspnet_Membership] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')
	INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment])
		VALUES (N'8b2e549a-c283-46f2-b481-25136daa9059', N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f', N'Cd2DIcbwqkLCpZf4OUh1TahrK1I=', 1, N'Wb9LMh5+xpcVjqCQFFcJeQ==', NULL, N'webform@ethionutrition.com', N'webform@ethionutrition.com', NULL, NULL, 1, 0, CAST(0x0000A0E600088AB8 AS DateTime), CAST(0x0000A100003CF03D AS DateTime), CAST(0x0000A0E600088AB8 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)

-- Password for jbob: jbob12345
if not exists(select * from dbo.UserProfile where ProfileId = 1)	
	insert into dbo.UserProfile(UserBirthDate,UserHeightInMeter,UserWeightInKg,UserBMI)
		values( NULL, NULL, NULL, NULL);
if not exists(select * from dbo.UserProfile where ProfileId = 2)	
	insert into dbo.UserProfile(UserBirthDate,UserHeightInMeter,UserWeightInKg,UserBMI)
		values( NULL, NULL, NULL, NULL);

if not exists (select * from [User] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e')
	INSERT [dbo].[User] ([UserId], [Firstname], [Lastname],[ProfileId]) 
		VALUES (N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8e', N'ethionutrition', N'webform',1)
if not exists (select * from [User] where UserId = N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f')
	INSERT [dbo].[User] ([UserId], [Firstname], [Lastname],[ProfileId]) 
		VALUES (N'6c82524a-b1e0-4b20-97b1-dbdf0dadad8f', N'Yordanos', N'Desta',2)





