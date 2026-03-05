-- Level-2: Problem 3 – Store Performance and Stock Validation
--  Scenario:
-- Management wants to evaluate store performance by identifying stores that have sold products but currently have zero stock for those products.
--  📌 Requirements
-- 1. Identify products sold in each store using nested queries.
-- 2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
-- 3. Display store_name, product_name, total quantity sold.
-- 4. Calculate total revenue per product (quantity × list_price – discount).
-- 5. Update stock quantity to 0 for discontinued products (simulation).
--  🛠️ Technical Constraints
-- • Use INTERSECT and EXCEPT operators.
-- • Use subqueries in FROM clause.
-- • Use arithmetic expressions for revenue calculation.
-- • Use UPDATE statement for stock modification.
--  Expectations:
-- • Correct application of set operators.
-- • Accurate revenue calculations.
-- • Proper JOIN between order_items, orders, stores, and stocks tables.
--  🎯 Learning Outcome
-- • Master set operators (INTERSECT, EXCEPT).
-- • Perform advanced nested queries.
-- • Apply UPDATE statements with conditions.


-- Identify sold products with 0 stock

USE AutoDb;

SELECT 
s.store_name, 
p.product_name, 
SUM(oi.quantity) AS Total_Sold,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS Total_Revenue
FROM Orders o
JOIN Order_Items oi ON o.order_id = oi.order_id
JOIN Products p ON oi.product_id = p.product_id
JOIN Stores s ON o.store_id = s.store_id
WHERE p.product_id IN (
    SELECT product_id FROM Order_Items
    INTERSECT
    SELECT product_id FROM Stocks WHERE quantity = 0
)
GROUP BY s.store_name, p.product_name;

-- Update stock to 0 for discontinued products (e.g., models before 2022)
UPDATE Stocks
SET quantity = 0
WHERE product_id IN (SELECT product_id FROM Products WHERE model_year < 2022);
