CREATE USER CGSample FOR LOGIN CGSample WITH DEFAULT_SCHEMA = dbo;
GO
EXEC sp_addrolemember N'db_owner', N'CGSample';
GO