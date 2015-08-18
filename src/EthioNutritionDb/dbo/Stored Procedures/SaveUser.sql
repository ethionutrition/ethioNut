create proc SaveUser
(
	@userId uniqueidentifier,
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@profileid bigint
)
as
begin

	set nocount on

	merge dbo.[User] as target
	using (select @userId, @firstname, @lastname, @profileid) as source (UserId, Firstname, Lastname,ProfileId)
	on (target.UserId = source.UserId)
	when matched then
		update set Firstname = target.Firstname, Lastname = target.Lastname
	when not matched then
		insert (UserId, Firstname, Lastname, ProfileId)
		values (source.UserId, source.Firstname, source.Lastname, source.ProfileId);

end
go
