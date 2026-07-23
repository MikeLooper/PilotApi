# Docker - Setup - PostgreSQL

Install and set up PostgreSQL on Docker.

Docker documentation:
- [Download and Install](https://www.docker.com/blog/how-to-use-the-postgres-docker-official-image/)
- [Get Started](https://docs.docker.com/guides/postgresql/)

1. Get the latest image:

  ```
  docker pull postgres
  ```

2. Create and start an instance:

  ```
  docker run --name local_postgres \
  -p 5432:5432 \
  --network pilot-net \
  -e POSTGRES_USER=DevUser \
  -e POSTGRES_PASSWORD=<dev-user-password> \
  -e POSTGRES_DB=devDb \
  -v "postgres_data:/var/lib/postgresql" \
  -v "C:\Working\Storage\Dev\GitHub\Working:/local_working" \
  -d postgres
  ```

3. Create the northwind database:

  ```
  docker exec local_postgres psql -U DevUser -d devDb \
  -c "CREATE DATABASE northwind;"
  ```

  Validate database was created (should not get an error):

  ```
  docker exec local_postgres psql -U DevUser -d northwind
  ```

4. Copy database script:

  ```
  copy "..\PilotApiDotNet\docker\PostgreSQL\northwind.sql" "C:\Working\Storage\Dev\GitHub\Working"
  ```

5. Load data into the database:

  ```
  docker exec -i local_postgres psql -U DevUser -d northwind \
  < ..\PilotApiDotNet\docker\PostgreSQL\northwind.sql
  ```

  Validate (should show a list of tables):

  ```
  docker exec local_postgres psql -U DevUser -d northwind \
  -c "SELECT table_name FROM information_schema.tables WHERE table_schema = 'pilot' AND table_type = 'BASE TABLE';"
  ```

6. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

7. Copy custom script:

  ```
  copy "..\PilotApiDotNet\docker\PostgreSQL\customobjects.sql" "C:\Working\Storage\Dev\GitHub\Working"
  ```

8. Load data into the database:

  ```
  docker exec -i local_postgres psql -U DevUser -d northwind \
  < ..\PilotApiDotNet\docker\PostgreSQL\customobjects.sql
  ```

9. Clean up prior working files:

  ```
  erase C:\Working\Storage\Dev\GitHub\Working\* /S /Q
  ```

## Additional CLI commands

1. start container

  ```
  docker start local_postgres
  ```

2. Stop and remove container:

  ```
  docker rm -f local_postgres
  ```

3. Remove a database:

  ```
  docker exec local_postgres psql -U DevUser -d devDb -c "DROP DATABASE northwind WITH (FORCE);"
  ```

4. List all databases:

  ```
  docker exec local_postgres psql -U DevUser -d devDb -l
  ```

## Interacting with a Docker database

How can we interact with a database installed on a Docker container?

1. Via Command Line (psql)

  ```
  docker exec -it postgres_db psql -U myuser -d mydatabase
  ```

2. Via GUI Desktop Tools:
- Open tools like:
	- DBeaver, 
	- DataGrip, or 
	- pgAdmin
- Connect using:
	- Host: localhost
	- Port: 5432
	- User/Password: As defined in your environment variables.

