-- Level-2: Problem 2 - Product Stock and Sales Analysis
-- Scenario:
-- The inventory manager wants to compare stock availability and total quantity sold for each product.
-- 📌 Requirements
-- 1. Display product_name, store_name, available stock quantity, and total quantity sold.
-- 2. Include products even if they have not been sold (use appropriate join).
-- 3. Group results by product_name and store_name.
-- 4. Sort results by product_name.
-- 🛠️ Technical Constraints
-- - Use LEFT JOIN between stocks and order_items.
-- - Use INNER JOIN with products and stores tables.
-- - Use GROUP BY clause.
-- - Use SUM() aggregate function.
-- - Use ORDER BY clause.
-- Expectations:
-- Students should correctly use different join types (INNER and LEFT), grouping, and aggregate functions.
-- 🎯 Learning Outcome 
-- Develop strong understanding of different JOIN types (INNER, LEFT), aggregation, grouping data, and analyzing relational datasets.

USE BikestoreDb;

SELECT 
p.product_name,
s.store_name,
st.quantity AS stock_quantity,
SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;
