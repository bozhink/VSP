CREATE TABLE [KeyTests].[Orders]
(
    [order_no] CHAR(4) NOT NULL PRIMARY KEY, 
    [order_price] INT NULL, 
    [order_quatity] INT NULL, 
    [order_date] DATETIME NULL, 
    [cust_no] CHAR(4) NOT NULL
    references [KeyTests].[Customers] (cust_no)
)
