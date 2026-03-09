-- DAY-1 Hands On

-- Level-2 Problem 1: Stored Procedures and User-Defined Functions
-- Scenario
-- The company requires reusable database logic to generate reports such as total sales per store and discounted order totals.

-- 📌 Requirements 
-- - Create a stored procedure to generate total sales amount per store.
-- - Create a stored procedure to retrieve orders by date range.
-- - Create a scalar function to calculate total price after discount.
-- - Create a table-valued function to return top 5 selling products.

-- 🛠️ Technical Constraints 
-- - Use input parameters in stored procedures.
-- - Handle NULL values properly.
-- - Ensure optimized queries inside procedures.
-- - Follow proper naming conventions.

-- Expectations
-- - Reusable and modular SQL code.
-- - Accurate calculations using functions.
-- - Efficient report generation using procedures.

-- 🎯 Learning Outcome 
-- - Understand encapsulation using stored procedures.
-- - Learn how to create and use user-defined functions.
-- - Develop reusable database logic.


USE BikeStoreDb;

-- stored procedure to generate total sales amount per store.
CREATE PROCEDURE sp_GetTotalSalesPerStore
AS
BEGIN
SELECT 
    s.store_id,
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - ISNULL(oi.discount,0))) AS Total_Sales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_id, s.store_name
END


----- Execution ------

EXEC sp_GetTotalSalesPerStore;


--stored procedure to retrieve orders by date range.

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_status,
        order_date,
        store_id
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END

------------Execute------
EXEC sp_GetOrdersByDateRange '2025-01-01', '2026-12-31';


-------scalar function to calculate total price after discount.

CREATE FUNCTION fn_CalculatePriceAfterDiscount
(
    @Price DECIMAL(10,2),
    @Discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @FinalPrice DECIMAL(10,2)

    SET @FinalPrice = @Price * (1 - ISNULL(@Discount,0))

    RETURN @FinalPrice
END

-----Example-----

SELECT 
    product_id,
    list_price,
    discount,
    dbo.fn_CalculatePriceAfterDiscount(list_price, discount) AS FinalPrice
FROM order_items;

---------table-valued function to return top 5 selling products.----

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS Total_Sold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY Total_Sold DESC
)


-----Execution-----

SELECT * FROM dbo.fn_Top5SellingProducts();