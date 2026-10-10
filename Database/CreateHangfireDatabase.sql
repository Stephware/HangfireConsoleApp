-- Run this once in SQL Server's master database using DBeaver.
-- EF Core creates StudentOperationsDb through the InitialCreate migration.
USE [master];

IF DB_ID(N'StudentOperationsHangfireDb') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE [StudentOperationsHangfireDb]');
END;
