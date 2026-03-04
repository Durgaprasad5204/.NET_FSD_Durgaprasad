-- Level-1: Problem 2 - Product Price Listing by Category
-- Scenario:
-- The sales team wants a product listing categorized by product category along with brand details to understand product distribution.
-- 📌 Requirements
-- 1. Display product_name, brand_name, category_name, model_year, and list_price.
-- 2. Filter products with list_price greater than 500.
-- 3. Sort results by list_price in ascending order. 
-- 🛠️ Technical Constraints
-- - Use SELECT statement.
-- - Use WHERE clause.
-- - Use ORDER BY clause.
-- - Use INNER JOIN between products, brands, and categories tables. 
-- Expectations:
-- Students should correctly join multiple tables and apply filtering and sorting logic.
-- 🎯 Learning Outcome 
-- Learn multi-table joins, filtering numeric conditions, and sorting query results. 

USE BikestoreDb;

SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;