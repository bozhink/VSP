CREATE TABLE [cms].[JobDetails]
(
    [CarNo] NVARCHAR(15) NOT NULL PRIMARY KEY, 
    [JobDate] DATETIME NOT NULL, 
    [WorkerID] INT NOT NULL, 
    [KMs] INT NULL, 
    [Tuning] INT NULL, 
    [Alignment] INT NULL, 
    [Balancing] INT NULL, 
    [Tires] INT NULL, 
    [Weights] INT NULL, 
    [OilChanged] INT NULL, 
    [OilQty] INT NULL, 
    [OilFilter] INT NULL, 
    [GearOil] INT NULL, 
    [GearOilQty] INT NULL, 
    [Point] INT NULL, 
    [Condenser] INT NULL, 
    [Plug] INT NULL, 
    [PlugQty] INT NULL, 
    [FuelFilter] INT NULL, 
    [AirFilter] INT NULL, 
    [Remarks] INT NULL
)
