CREATE TABLE CalculationHistory
(
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Operation   NVARCHAR(50)     NOT NULL,
    A           NVARCHAR(100)    NOT NULL,
    B           NVARCHAR(100)    NOT NULL,
    Result      NVARCHAR(100)    NOT NULL,
    PerformedAt DATETIME2        NOT NULL DEFAULT GETUTCDATE()
);
