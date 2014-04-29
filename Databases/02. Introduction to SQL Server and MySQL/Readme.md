## Introduction to SQL Server and MySQL

1. Download and install SQL Server Express. Install also SQL Server Management Studio Express (this could take some effort but be persistent).
* Connect to the SQL Server with SQL Server Management Studio. Use Windows authentication.
* Create a new database Pubs and create new login with permissions to connect to it. Execute the script install_pubs.sql to populate the DB contents (you may need slightly to edit the script before).
* Attach the database Northwind (use the files Northwind.mdf and Northwind.ldf) to SQL Server and connect to it.
* Backup the database Northwind into a file named northwind-backup.bak and restore it as database named North.
* Export the entire Northwind database as SQL script. Use [Tasks] -> [Generate Scripts]. Ensure you have exported table data rows (not only the schema).
* Create a database NW and execute the script in it to create the database and populate table data.
* Detatch the database NW and attach it on another computer in the training lab. In case of name collision, preliminary rename the database.
* Download and install MySQL Community Server  + MySQL Workbench + the sample databases.
* Export the MySQL sample database "world" as SQL script.
* Modify the script and execute it to restore the database world as "worldNew".
* Connect through the MySQL console client and list the first 20 tons from the database "worldNew".