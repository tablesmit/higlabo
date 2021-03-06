
Create Procedure HigLabo_Data_LinkedServer_Create
(@ServerName Nvarchar(400)
,@DataSource Nvarchar(400)
,@DatabaseName Nvarchar(400)
,@UserName Nvarchar(100)
,@Password Nvarchar(100)
) 
As 

Exec sp_addlinkedserver 
@server=@ServerName, 
@srvproduct='',
@provider='sqlncli',
@datasrc=@DataSource,
@location='',
@provstr='',
@catalog=@DatabaseName

Exec sp_addlinkedsrvlogin
@rmtsrvname = @ServerName,
@useself = 'false',
@rmtuser = @UserName,
@rmtpassword = @Password

Exec sp_serveroption @ServerName, 'rpc out', true;

Go



Create Type GuidTable As Table
(GuidValue Uniqueidentifier not null
)


--http://msdn.microsoft.com/ja-jp/library/ms190273.aspx
ALTER TABLE MVideoChannel Add LastImportTime DateTimeOffset(7) Not Null 
Constraint LastImportTime_Default DEFAULT '2000/1/1 00:00:00'
GO
