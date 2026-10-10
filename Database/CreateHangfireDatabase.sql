-- Run this once in SQL Server's master database using DBeaver.
-- EF Core creates StudentOperationsDb through InitialCreate migration.
USE [master];

IF DB_ID(N'StudentOperationsHangfireDb') IS NULL
BEGIN
    CREATE DATABASE [StudentOperationsHangfireDb];
END;
