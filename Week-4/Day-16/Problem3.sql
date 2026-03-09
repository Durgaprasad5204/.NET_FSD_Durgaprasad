 -- Level-2 Problem 3: Order Status Validation Trigger
-- Scenario
-- Before updating order_status in orders table, ensure that shipped_date is not NULL when status is set to Completed (4).
-- 📌 Requirements 
-- - Create an AFTER UPDATE trigger on orders.
-- - Validate that shipped_date is NOT NULL when order_status = 4.
-- - Prevent update if condition fails. 
-- 🛠️ Technical Constraints 
-- - Use AFTER UPDATE trigger.
-- - Use inserted logical table for validation.
-- - Use TRY…CATCH with custom error message.
-- - Rollback transaction if validation fails. 
-- Expectations
-- - Accurate validation logic.
-- - Proper rollback handling.
-- - Clean and readable SQL implementation. 


-- 🎯 Learning Outcome 
-- - Understand validation using triggers.
-- - Work with inserted table.
-- - Enforce business rules at database level.

USE BikeStoreDb;


-- Add shipped_date column
ALTER TABLE orders
ADD shipped_date DATE;

--Create / Update Trigger
ALTER TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        
-- Check if order_status = Completed (2) but shipped_date is NULL
        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 2
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Cannot set order status to Completed without shipped_date.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

    END TRY

    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        ROLLBACK TRANSACTION;
    END CATCH
END;

-- View orders
SELECT * FROM orders;

-- Test case (should fail) before getting date
UPDATE orders
SET order_status = 2
WHERE order_id = 1;

-- Correct update
UPDATE orders
SET shipped_date = GETDATE()
WHERE order_id = 1;

UPDATE orders
SET order_status = 2
WHERE order_id = 1;

-- Verify result
SELECT order_id, order_status, shipped_date
FROM orders;
