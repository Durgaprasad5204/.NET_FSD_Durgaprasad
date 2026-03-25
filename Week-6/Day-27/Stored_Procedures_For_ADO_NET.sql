CREATE database InventoryDB;

USE InventoryDB;

/*Creating Table*/
CREATE TABLE Products
(
	ProductId INT IDENTITY(1,1) PRIMARY KEY,
	ProductName VARCHAR(50),
	Category VARCHAR(50),
	Price DECIMAL(10,2)

	);

/*Creating Procedure for Insert*/

CREATE PROCEDURE sp_InsertProduct
	@ProductName VARCHAR(50),
	@Category VARCHAR(50),
	@Price DECIMAL(10,2)
	AS
	BEGIN 
	INSERT INTO Products(ProductName,Category,Price)
	VALUES(@ProductName,@Category,@Price)
END

/*Creating Procedure To get all Products*/


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
	SELECT*FROM Products
END

/*Creating Procedure for Update Product*/

CREATE PROCEDURE sp_UpdateProduct
@ProductId INT,
@ProductName VARCHAR(50),
@Category VARCHAR(50),
@Price DECIMAL(10,2)
AS
BEGIN
UPDATE Products
SET ProductName = @ProductName,
Category = @Category,
Price = @Price
WHERE ProductId = @ProductId
END

/*Creating Procedure for Deletion*/

CREATE PROCEDURE sp_DeleteProduct
@ProductId INT
AS
BEGIN
DELETE FROM Products WHERE ProductId = @ProductId
END



