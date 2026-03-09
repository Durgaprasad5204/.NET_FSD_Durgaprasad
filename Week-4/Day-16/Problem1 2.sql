CREATE DATABASE BikestoreDb;

USE BikestoreDb;
--------------- Stores Table ---------------

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(255) NOT NULL,
    city VARCHAR(50)
);
INSERT INTO stores VALUES
(1,'Hyderabad Bikes','Hyderabad'),
(2,'Chennai Bikes','Chennai');

--------------- Categories Table ---------------

CREATE TABLE categories(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(255)
);

INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes');

--------------- Brands Table ---------------

CREATE TABLE brands(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(255)
);

INSERT INTO brands VALUES
(1,'Royal Enfield'),
(2,'Yamaha'),
(3,'Ola');

--------------- Customers Table ---------------

CREATE TABLE customers(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)

);

INSERT INTO customers VALUES
(1,'Durga','Prasad'),
(2,'Rohit','Sharma'),
(3,'Pradeep','Dirisala');

--------------- Products Table ---------------

CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255),
    model_year INT,
    list_price DECIMAL(10, 2),
    brand_id INT FOREIGN KEY REFERENCES brands(brand_id),
    category_id INT FOREIGN KEY REFERENCES categories(category_id)
    
);

INSERT INTO products VALUES
(1,'Himalayan ',2023,290000,1,1),
(2,'R15 v4 ',2022,195000,2,2),
(3,'Ola S1 pro',2024,160000,3,3);

--------------- Orders Table ---------------

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT FOREIGN KEY REFERENCES customers(customer_id),
    order_status TINYINT CHECK (order_status IN (1,2)), -- 1 is pending and 2 is completed
    order_date DATE,
    store_id INT FOREIGN KEY REFERENCES stores(store_id)
);

INSERT INTO orders VALUES
(1,1,1,'2026-03-01',1), -- 1-Pending
(2,2,2,'2026-03-02',2), -- 2-Completed
(3,3,2,'2026-03-03',1); -- 2-Completed

--------------- Order Items Table ---------------

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY,
    order_id INT FOREIGN KEY REFERENCES orders(order_id),
    product_id INT FOREIGN KEY REFERENCES products(product_id),
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2)
);

INSERT INTO order_items VALUES
(1,1,1,1,290000,0.05),
(2,2,2,2,195000,0.10),
(3,3,3,1,160000,0.00);
--------------- Stocks Table ---------------

CREATE TABLE stocks
(
    store_id INT FOREIGN KEY REFERENCES stores(store_id),
    product_id INT FOREIGN KEY REFERENCES products(product_id),
    quantity INT,
    PRIMARY KEY(store_id, product_id) -- composite key 
);

INSERT INTO stocks VALUES
(1,1,10),
(1,2,5),
(2,3,8);

--------------- Verifying the inserted values ---------------

SELECT * FROM stores;
SELECT * FROM products;
SELECT * FROM customers;
SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;


---------------Problem 1 ---------------

-- Level-1: Problem 1 - Basic Customer Order Report
-- Scenario:
-- The store manager wants a simple report showing customer orders along with their order dates and status. This report will help track pending and completed orders.
-- 📌 Requirements
-- 1. Retrieve customer first name, last name, order_id, order_date, and order_status.
-- 2. Display only orders with status Pending (1) or Completed (4).
-- 3. Sort the results by order_date in descending order. 
-- 🛠️ Technical Constraints
-- - Use SELECT statement.
-- - Use WHERE clause with logical operators (AND/OR).
-- - Use ORDER BY clause.
-- - Use INNER JOIN between customers and orders tables. 
-- Expectations:
-- Students should write a correct query using joins and filters, and properly order the result set.
-- 🎯 Learning Outcome 
-- Understand basic SELECT queries, filtering using WHERE conditions, logical operators, and sorting using ORDER BY clause with INNER JOIN. 

SELECT 
c.first_name,
c.last_name,
o.order_id,
o.order_date,
o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status IN (1,2)
ORDER BY o.order_date;

----------------Problem-2--------------
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
ORDER BY p.list_price;

----------------Problem-3--------------
SELECT 
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 2
GROUP BY s.store_name
ORDER BY total_sales;


----------------Problem-4--------------
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