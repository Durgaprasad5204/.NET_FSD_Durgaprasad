BEGIN TRY

BEGIN TRANSACTION;

-- Temporary table to store revenue
CREATE TABLE #RevenueTemp
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(10,2)
);

-- Variables
DECLARE @order_id INT;
DECLARE @store_id INT;
DECLARE @revenue DECIMAL(10,2);

-- Cursor to select completed orders
DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

OPEN order_cursor;

FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT @revenue = SUM(quantity * list_price * (1 - discount))
    FROM order_items
    WHERE order_id = @order_id;

    -- Insert into temporary table
    INSERT INTO #RevenueTemp(order_id, store_id, revenue)
    VALUES(@order_id, @store_id, @revenue);

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

END

CLOSE order_cursor;
DEALLOCATE order_cursor;

-- Store wise revenue summary
SELECT store_id, SUM(revenue) AS Total_Revenue
FROM #RevenueTemp
GROUP BY store_id;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Error occurred: ' + ERROR_MESSAGE();

END CATCH;