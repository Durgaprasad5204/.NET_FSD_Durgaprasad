-- Level-1 Problem 2: Creating Views and Indexes for Performance

-- Scenario
-- The management team frequently accesses product and order summary reports. To simplify access and improve performance, they require database views and indexing.

-- 📌 Requirements 
-- - Create a view that shows product name, brand name, category name, model year and list price.
-- - Create a view that shows order details with customer name, store name and staff name.
-- - Create appropriate indexes on foreign key columns.
-- - Test performance improvement using execution plan.

-- 🛠️ Technical Constraints 
-- - Views must not duplicate data.
-- - Indexes should be created only on frequently searched columns.
-- - Do not change table definitions.
-- - Follow proper naming conventions.


-- Expectations
-- - Working views returning accurate data.
-- - Indexes improving query execution time.
-- - Proper documentation of execution plan comparison.

-- 🎯 Learning Outcome 
-- - Understand purpose of views.
-- - Learn how indexing improves performance.
-- - Gain hands-on knowledge of query optimization.
--  

USE EcommDb;

-- 1. Product Summary View
CREATE VIEW vw_ProductDetails AS
SELECT p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

-- 2. Order Details View
CREATE VIEW vw_OrderSummary AS
SELECT o.order_id, c.first_name + ' ' + c.last_name AS customer_name, 
       s.store_name, st.first_name + ' ' + st.last_name AS staff_name
FROM orders o
JOIN customers c ON o.customer_id = c.customer_id
JOIN stores s ON o.store_id = s.store_id
JOIN staffs st ON o.staff_id = st.staff_id;


-- 3. Indexing for foreign keys
CREATE INDEX idx_fk_brand ON products(brand_id);
CREATE INDEX idx_fk_category ON products(category_id);
CREATE INDEX idx_fk_customer ON orders(customer_id);
