-- Level-2: Problem 4 – Order Cleanup and Data Maintenance
--  Scenario:
-- The database contains outdated and rejected orders. Management wants to clean up and archive data while maintaining consistency.
--  📌 Requirements 
-- 1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
-- 2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
-- 3. Use nested query to identify customers whose all orders are completed.
-- 4. Display order processing delay (DATEDIFF between shipped_date and order_date).
-- 5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.
--  🛠️ Technical Constraints 
-- • Use INSERT statement with SELECT.
-- • Use DELETE with nested query.
-- • Use DATE functions and conditional logic.
-- • Maintain referential integrity constraints.
--  Expectations:
-- • Proper handling of DELETE and INSERT operations.
-- • Correct usage of subqueries for validation.
-- • Accurate date calculations and CASE logic.
--   🎯 Learning Outcome
-- • Perform data modification operations safely.
-- • Implement business logic using SQL expressions.
-- • Understand real-world database maintenance scenarios.


USE AutoDb;

-- 1. Create archive table with same structure as orders
CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT
);

-- 2. First, identify the orders to archive (rejected orders older than 1 year)
-- Let's see which orders will be affected
SELECT * FROM orders 
WHERE order_status = 3 
AND order_date < DATEADD(YEAR, -1, GETDATE());

-- 3. Insert into archive
INSERT INTO archived_orders
SELECT order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id
FROM orders 
WHERE order_status = 3 
AND order_date < DATEADD(YEAR, -1, GETDATE());

-- 4. Delete from order_items first (child table)
DELETE FROM order_items
WHERE order_id IN (
    SELECT order_id 
    FROM orders 
    WHERE order_status = 3 
    AND order_date < DATEADD(YEAR, -1, GETDATE())
);

-- 5. Now delete from orders (parent table)
DELETE FROM orders 
WHERE order_status = 3 
AND order_date < DATEADD(YEAR, -1, GETDATE());

-- 6. Customers whose all orders are completed
SELECT DISTINCT CONCAT(c.first_name, ' ', c.last_name) AS customer_name
FROM customers c
WHERE c.customer_id IN (
    SELECT customer_id 
    FROM orders 
    GROUP BY customer_id
    HAVING MIN(order_status) = 4 AND MAX(order_status) = 4
);

-- 7. Order processing delay and status
SELECT 
    order_id,
    DATEDIFF(DAY, order_date, shipped_date) AS processing_delay,
    CASE 
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS order_status
FROM orders
WHERE shipped_date IS NOT NULL;