-- Level-1: Problem 2 – Customer Activity Classification
--  Scenario:
-- The company wants to classify customers based on their total order value and identify customers who have placed orders versus those who have not.
--  📌 Requirements
-- 1. Use nested query to calculate total order value per customer.
-- 2. Classify customers using conditional logic:
--    - 'Premium' if total order value > 10000
--    - 'Regular' if total order value between 5000 and 10000
--    - 'Basic' if total order value < 5000
-- 3. Use UNION to display customers with orders and customers without orders.
-- 4. Display full name using string concatenation.
-- 5. Handle NULL cases appropriately.

--  🛠️ Technical Constraints
-- • Use CASE statement for classification.
-- • Use UNION operator.
-- • Use subquery for total calculation.
-- • Use JOIN between customers and orders tables.
--  Expectations:
-- • Proper implementation of UNION.
-- • Correct usage of CASE expression.
-- • Accurate total value calculation.
--  🎯 Learning Outcome 
-- • Apply conditional logic in SQL.
-- • Combine results using set operators.
-- • Work with nested aggregation queries.


-- Part 1: Customers with orders based on their total value 

USE AutoDb;

SELECT CONCAT(c.first_name, ' ', c.last_name) AS FullName,'Has Orders' AS ActivityStatus,
    CASE 
        WHEN SUM(oi.quantity * oi.list_price * (1 - oi.discount)) > 10000 THEN 'Premium'
        WHEN SUM(oi.quantity * oi.list_price * (1 - oi.discount)) BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS CustomerCategory
FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
JOIN order_items oi ON o.order_id = oi.order_id
GROUP BY c.customer_id, c.first_name, c.last_name

UNION

-- Part 2: Customers without orders
SELECT CONCAT(c.first_name, ' ', c.last_name) AS FullName,'No Orders' AS ActivityStatus,
'None' AS CustomerCategory
FROM customers c
WHERE c.customer_id NOT IN (SELECT DISTINCT customer_id FROM orders);
