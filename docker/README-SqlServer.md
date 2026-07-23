# Docker - Setup - SQL Server

Install and set up SQL Server on Docker.

1. Setup:
    - [Docker Quickstart](https://learn.microsoft.com/en-us/sql/linux/install-upgrade/quickstart-install-docker?view=sql-server-ver17&tabs=cli&pivots=cs1-bash)

2. Download the SQL Server image:

  ```
  docker pull mcr.microsoft.com/mssql/server:2025-latest
  ```

3. Create and start the new container:

  ```
  docker run \
  -p 1433:1433 \
  --hostname local_mssql \
  --name local_mssql \
  --network pilot-net \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=<sa-password>" \
  -e "MSSQL_AGENT_ENABLED=true" \
  -v "mssql_data:/var/opt/mssql" \
  -v "C:\Working\Storage\Dev\Docker\Working:/local_working" \
  -d mcr.microsoft.com/mssql/server:2025-latest
  ```
	
  SQL Server password requirements:

    - The password doesn't contain the account name of the user.
    - The password is at least eight characters long.
    - The password contains characters from three of the following four categories:
      - Latin uppercase letters (A through Z)
      - Latin lowercase letters (a through z)
      - Base 10 digits (0 through 9)
      - Nonalphanumeric characters such as: exclamation point (!), dollar sign ($), number sign (#), or percent (%).

4. Validate assignment of password:

  ```
  docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "<sa-password>" -C
  ```

  If validation failed, run the following from the command line:
	
  ```
  # 1. Access the container's terminal
  docker exec -it local_mssql bash

  # 2. Force-reset the SA password (must meet complexity requirements)
  MSSQL_SA_PASSWORD="<sa-password>" /opt/mssql/bin/mssql-conf set-sa-password

  # 3. Restart your container for changes to apply
  docker restart local_mssql
  ```

5. Disable the 'sa' account:
    1. Create a new login user (to take the place of the 'sa' user id):
	
    ```
	  docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd \
	  -S localhost -U sa -P "<sa-password>" -C \
	  -Q "CREATE LOGIN [DevUser] WITH PASSWORD = '<dev-user-password>'; ALTER SERVER ROLE [sysadmin] ADD MEMBER [DevUser];"
	  ```

	  2. Disable the 'sa' account:
	
  	```
    docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd \
	  -S localhost -U DevUser -P "<dev-user-password>" -C \
	  -Q "ALTER LOGIN [sa] DISABLE;"
	  ```

6. Create the NorthWind database:

  ```
  docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U DevUser -P "<dev-user-password>" -C \
  -Q "CREATE DATABASE NorthWind;"
  ```

  Validate database was created (should not get an error):
	
  ```
  docker exec local_mssql /opt/mssql-tools18/bin/sqlcmd -S localhost \
  -U DevUser -P "<dev-user-password>" -C -d NorthWind
  ```

7. Copy database script:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  copy "..\PilotApiDotNet\docker\SqlServer\Northwind.sql" "C:\Working\Storage\Dev\GitHub\Working"
  ```

8. Load data into the database:

  ```
  docker exec -i local_mssql /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U DevUser -P "<dev-user-password>" -d northwind -C \
  < ..\PilotApiDotNet\docker\SqlServer\Northwind.sql
  ```
  Validate (should show a list of tables):

  ```
  docker exec local_mssql /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U DevUser -P "<dev-user-password>" -d NorthWind -C \
  -Q "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';"
  ```

9. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

10. Copy custom script:

  ```
  copy "..\PilotApiDotNet\docker\SqlServer\customobjects.sql" "C:\Working\Storage\Dev\GitHub\Working"
  ```

11. Load data into the database:

  ```
  docker exec -i local_mssql /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U DevUser -P "<dev-user-password>" -d northwind -C \
  < ..\PilotApiDotNet\docker\SqlServer\customobjects.sql
  ```

12. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

## Additional CLI commands

1. Start the Docker container:

	```
    docker start local_mssql
	```

2. Stop and remove container:
	```
    docker rm -f local_mssql
	```

3. Remove a database:

  ```
  docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U DevUser -P "<dev-user-password>" /
  -C -Q "ALTER DATABASE Northwind SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE Northwind;"
  ```

4. List all databases:

  ```
  docker exec -it local_mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U DevUser -P "<dev-user-password>" /
  -C -Q "SELECT name FROM sys.databases;"
  ```
