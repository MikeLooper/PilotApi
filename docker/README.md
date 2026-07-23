# Docker - Setup

## Install

Install and set up Docker on your local PC.

Docker documentation:
- [Download and Install](https://docs.docker.com/desktop/setup/install/windows-install/)
- [Get Started](https://www.docker.com/get-started/)
- [CheatSheet](https://docs.docker.com/get-started/docker_cheatsheet.pdf)

## Preparation

Open a command prompt and change to a working directory:
  
```
cd C:\Working\Storage\Dev\GitHub\Working
```
  
The docker CLI commands found in this, and related, READMEs will be executed in this command line window.

### Network

Create an internal network that will be shared by the different containers that need to communicate with one another.

```
docker network create pilot-net
```

## SQL Server

Follow the directions in the SQL Server README: [SQL Server README](.\README-SqlServer.md)

## PostgreSQL

Follow the directions in the SQL Server README: [PostgreSQL README](.\README-PostgreSQL.md).

## Pilot API

Follow the directions in the SQL Server README: [API README](.\README-Api.md).
