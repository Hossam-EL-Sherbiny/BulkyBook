	When Creating Database Table Add The Following Configurations:
	
	1) Use ConnectionString To Create The DataBase and Create The Table We Want Inside The DataBase:
		=> Using EFCore and creating Object Of The DbContext ( Using DbContext to make connection to the database).
		=> Create Data Folder (AppDbContext - Installing EFCoreSql).
		=> Create Constructor to establish the connection with EFCore.
		=> To create table inside the database, create The DbSet inside the AppDbContext.
		=> Tell our Application that it has to use the DbContext inside it (Doing that inside Program.cs, Using SQLSERVER();).