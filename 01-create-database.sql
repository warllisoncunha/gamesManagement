IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'gamesDb')
BEGIN
  CREATE DATABASE gamesDb
END;