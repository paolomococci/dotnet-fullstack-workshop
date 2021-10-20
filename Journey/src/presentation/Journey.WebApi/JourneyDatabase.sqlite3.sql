BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "JourneyLists" (
	"Id"	INTEGER NOT NULL,
	"Country"	TEXT,
	"City"	TEXT,
	CONSTRAINT "PK_JourneyLists" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "JourneySelections" (
	"Id"	INTEGER NOT NULL,
	"ListId"	INTEGER NOT NULL,
	"Name"	TEXT,
	"Hope"	TEXT,
	"MapLocation"	TEXT,
	"Price"	REAL NOT NULL,
	"Duration"	INTEGER NOT NULL,
	"Confirmation"	INTEGER NOT NULL,
	"Currency"	INTEGER NOT NULL,
	"JourneysId"	INTEGER,
	CONSTRAINT "FK_JourneySelections_JourneyLists_JourneysId" FOREIGN KEY("JourneysId") REFERENCES "JourneyLists"("Id") ON DELETE RESTRICT,
	CONSTRAINT "PK_JourneySelections" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20211020031214_InitialCreate','5.0.11');
CREATE INDEX IF NOT EXISTS "IX_JourneySelections_JourneysId" ON "JourneySelections" (
	"JourneysId"
);
COMMIT;
