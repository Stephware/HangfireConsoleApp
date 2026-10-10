-- Run in DBeaver after testing each activity.
USE [StudentOperationsDb];

SELECT Id, StudentNumber, FullName, Email, CreatedAt
FROM dbo.Students
ORDER BY Id;

SELECT Id, StudentId, Status, CreatedAt, ProcessedAt,
       ConfirmationSent, SimulateTransientFailure, HasFailedOnce
FROM dbo.EnrollmentRequests
ORDER BY Id;

SELECT Id, EnrollmentRequestId, Message, CreatedAt
FROM dbo.ProcessingLogs
ORDER BY CreatedAt DESC;
