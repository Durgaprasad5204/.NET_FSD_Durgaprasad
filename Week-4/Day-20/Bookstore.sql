USE OnlineBookStore;

CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

CREATE OR ALTER PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);

        PRINT 'Book added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) 
              + ': ' + ERROR_MESSAGE();
    END CATCH
END;


EXEC sp_AddNewBook 'C# Basics', 10, 500;
EXEC sp_AddNewBook 'SQL Server Guide', 5, 650;
EXEC sp_AddNewBook 'ASP.NET Core', 2, 800;
EXEC sp_AddNewBook 'JavaScript Essentials', 8, 450;

SELECT * FROM Books;

CREATE OR ALTER PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check Book Exists & Stock Available
        IF NOT EXISTS (
            SELECT 1 FROM Books 
            WHERE BookID = @BookID AND Stock >= @Quantity
        )
        BEGIN
            RAISERROR('Not enough stock or book not found.', 16, 1);
        END

        -- Reduce Stock
        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

        -- Insert Order
        INSERT INTO Orders (BookID, Quantity)
        VALUES (@BookID, @Quantity);

        COMMIT TRANSACTION;

        PRINT 'Order placed successfully.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR)
              + ': ' + ERROR_MESSAGE();
    END CATCH
END;

EXEC sp_PlaceOrder 1, 3;

SELECT * FROM Books WHERE BookID = 1;
SELECT * FROM Orders;

EXEC sp_PlaceOrder 3, 10;

SELECT * FROM Books WHERE BookID = 3;
SELECT * FROM Orders;

EXEC sp_PlaceOrder 99, 2;

SELECT * FROM Orders;