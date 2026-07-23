# Docker - Setup - API

## Publish

Publish the API by following the commands:

Run the standard command from your application's root directory:



1. Get the latest image:

  ```
  docker pull mcr.microsoft.com/dotnet/aspnet:10.0
  ```

2. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

3. Change to the application's root directory:

  ```
  cd ..\PilotApiDotNet
  ``` 

4. Build the application, so it can execute on Linux

  ```
  dotnet publish --configuration Release --os linux --arch x64 --output ..\Working
  ```

5. Change back to the working directory:

  ```
  cd ..\Working
  ```
	
6. Copy the dockerfile to the publish directory (for SQL Server):

  ```
  copy /y "..\PilotApiDotNet\docker\Api\dockerfile_mssql" "C:\Working\Storage\Dev\GitHub\Working\dockerfile"
  ```

7. Copy the appsettings file to the publish directory (for SQL Server):

  ```
  copy /y "..\PilotApiDotNet\docker\SqlServer\appsettings.Production.json" "C:\Working\Storage\Dev\GitHub\Working"
  ```

8. build the docker image (for SQL Server):
	
  ```
  docker build -t pilot-api-dotnet-mssql:1.0 .
  ```

9. Create and start the container (for SQL Server):

  ```
  docker run -d -p 55551:55551 \
  --network pilot-net \
  --name pilot-api-dotnet-mssql pilot-api-dotnet-mssql:1.0
  ```

6. Copy the dockerfile to the publish directory (for SQL PostgreSQL):

  ```
  copy /y "..\PilotApiDotNet\docker\Api\dockerfile_postgres" "C:\Working\Storage\Dev\GitHub\Working\dockerfile"
  ```

10. Copy the appsettings file to the publish directory (for PostgreSQL):

  ```
  copy /y "..\PilotApiDotNet\docker\PostgreSQL\appsettings.Production.json" "C:\Working\Storage\Dev\GitHub\Working"
  ```

11. build the docker image (for PostgreSQL):
	
  ```
  docker build -t pilot-api-dotnet-postgres:1.0 .
  ```

12. Create and start the container (for PostgreSQL):

  ```
  docker run -d -p 55552:55552 \
  --network pilot-net \
  --name pilot-api-dotnet-postgres pilot-api-dotnet-postgres:1.0
  ```

13. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

## Usage

After executing the above steps, you can now access your API at following base URL:
```
http://localhost:55551/....
```
### Example Usages


### Docker = Production

The Docker container is executing with an environment of 'Production'.
This means that the Scalar and Swagger UIs will not be available, which follows API deployment best practices.

## Additional CLI commands

1. Start the Docker container:

	```
    docker start pilot-api-dotnet
	```

2. Stop and remove container:
	```
    docker rm -f pilot-api-dotnet
	```

