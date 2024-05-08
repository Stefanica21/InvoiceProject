-- Check if the database exists; if not, create it
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'InvoiceDB')
BEGIN
    CREATE DATABASE InvoiceDB;
    PRINT 'Database "InvoiceDB" created successfully.';
END
ELSE
BEGIN
    PRINT 'Database "InvoiceDB" already exists.';
END
GO

-- Use the InvoiceDB database
USE InvoiceDB;
GO

-- Create the Locations table
CREATE TABLE Locations (
    Id INT NOT NULL PRIMARY KEY,
    Address NVARCHAR(500) NULL,
    City NVARCHAR(100) NULL,
    PostalCode NVARCHAR(20) NULL
);
GO

-- Insert sample data into the Locations table
INSERT INTO Locations (Id, Address, City, PostalCode) VALUES
(1, 'Nicolae Labis 38', 'Brasov', '500171'),
(2, 'Mihai Viteazul 7', 'Bucuresti', '100345'),
(3, 'Stefan cel mare', 'Iasi', '300213');
GO

-- Create the Invoices table
CREATE TABLE Invoices (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    LocationId INT NOT NULL,
    Number NVARCHAR(50) NOT NULL,
    Date DATE NOT NULL,
    ClientName NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Invoice_Location FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);
GO

-- Insert sample data into the Invoices table
INSERT INTO Invoices (LocationId, Number, Date, ClientName) VALUES
(1, 'INV001', '2024-04-28', 'Andrei Petrescu'),
(2, 'INV002', '2024-04-29', 'Stefana Nica'),
(3, 'INV003', '2024-04-30', 'Ion Ciobanu');
GO

-- Create the InvoiceDetails table
CREATE TABLE InvoiceDetails (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    LocationId INT NOT NULL,
    InvoiceId INT NOT NULL,
    ProductName NVARCHAR(50) NOT NULL,
    Amount DECIMAL(18, 0) NOT NULL,
    Price DECIMAL(18, 0) NOT NULL,
    Value DECIMAL(18, 0) NOT NULL,
    CONSTRAINT FK_InvoiceDetails_Invoices FOREIGN KEY (InvoiceId) REFERENCES Invoices(Id) ON DELETE CASCADE,
    CONSTRAINT FK_InvoiceDetails_Locations FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);
GO

-- Insert data into the InvoiceDetails table
INSERT INTO InvoiceDetails (LocationId, InvoiceId, ProductName, Amount, Price, Value)
VALUES
    (1, 1, 'IPhone', 2, 1000, 800),
    (2, 2, 'Macbook', 1, 2000, 1750),
    (3, 3, 'Apple watch', 3, 300, 200);
GO
