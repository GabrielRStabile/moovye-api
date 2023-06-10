migration-name?=DefaultMigration

ef-migrations-identity:
	cd src/Movye.Identity && dotnet ef migrations add $(migration-name) --context IdentityDataContext -o ./Migrations -s ../Movye.Api

ef-update-identity:
	cd src/Movye.Identity && dotnet ef database update -s ../Movye.Api --context IdentityDataContext

start-dev:
	cd src/Movye.Api && dotnet watch run
