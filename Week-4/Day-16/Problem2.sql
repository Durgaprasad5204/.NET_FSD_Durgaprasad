USE BikeStoreDb;

-- Create / Update Trigger
ALTER TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY
        
        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN orders o ON i.order_id = o.order_id
            JOIN stocks s 
                ON s.product_id = i.product_id 
                AND s.store_id = o.store_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock. Order cannot be processed.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Update stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i ON s.product_id = i.product_id
        JOIN orders o ON i.order_id = o.order_id
        WHERE s.store_id = o.store_id;

    END TRY

    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        ROLLBACK TRANSACTION;
    END CATCH
END;

-- View existing order items
SELECT * FROM order_items;

-- Find next available item_id
SELECT MAX(item_id) AS NextItemId FROM order_items;

-- View available products
SELECT product_id, product_name FROM products;

-- Check stock before inserting order
SELECT * FROM stocks WHERE product_id = 1;

-- Insert new order item 
INSERT INTO order_items
(order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1, 4, 1, 2, 500, 0);

-- Check stock after insert 
SELECT * FROM stocks WHERE product_id = 1;