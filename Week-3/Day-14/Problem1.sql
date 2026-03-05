-- Create the database
CREATE DATABASE AutoDb;
USE AutoDb;

-- Create Categories table
CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL,
    description TEXT
);

-- Create Products table
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(200) NOT NULL,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

-- Create Customers table
CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(200) UNIQUE,
    phone VARCHAR(20),
    address TEXT,
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(20)
);

-- Create Stores table
CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(200) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(200),
    address TEXT,
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(20)
);

-- Create Orders table
CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_status INT DEFAULT 1, -- 1: Pending, 2: Processing, 3: Rejected, 4: Completed
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

-- Create Order Items table
CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT NOT NULL,
    list_price DECIMAL(10, 2) NOT NULL,
    discount DECIMAL(4, 2) DEFAULT 0,
    PRIMARY KEY (order_id, item_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- Create Stocks table
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT DEFAULT 0,
    PRIMARY KEY (store_id, product_id), ----Composite Key-----
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- Insert Categories
INSERT INTO categories (category_name, description) VALUES
('Sedan', 'Four-door passenger cars'),
('SUV', 'Sports Utility Vehicles'),
('Hatchback', 'Compact cars with rear door'),
('Luxury', 'Premium luxury vehicles'),
('Electric', 'Electric and hybrid vehicles');

-- Insert Products
INSERT INTO products (product_name, category_id, model_year, list_price) VALUES
('Toyota Camry', 1, 2022, 28000.00),
('Honda Accord', 1, 2022, 29500.00),
('BMW X5', 2, 2023, 62000.00),
('Tesla Model 3', 5, 2023, 55000.00),
('Mercedes C-Class', 4, 2022, 48000.00),
('Ford Focus', 3, 2021, 22000.00),
('Audi Q7', 2, 2023, 68000.00),
('Nissan Leaf', 5, 2022, 32000.00),
('Hyundai Elantra', 1, 2021, 21000.00),
('Chevrolet Spark', 3, 2022, 16000.00);

-- Insert Customers
INSERT INTO customers (first_name, last_name, email, phone, city) VALUES
('John', 'Smith', 'john.smith@email.com', '555-0101', 'New York'),
('Mary', 'Johnson', 'mary.j@email.com', '555-0102', 'Los Angeles'),
('Robert', 'Williams', 'robert.w@email.com', '555-0103', 'Chicago'),
('Patricia', 'Brown', 'patricia.b@email.com', '555-0104', 'Houston'),
('Michael', 'Jones', 'michael.j@email.com', '555-0105', 'Phoenix');

-- Insert Stores
INSERT INTO stores (store_name, phone, email, city, state) VALUES
('Downtown Auto', '555-1001', 'downtown@auto.com', 'New York', 'NY'),
('Westside Motors', '555-1002', 'westside@auto.com', 'Los Angeles', 'CA'),
('Midtown Cars', '555-1003', 'midtown@auto.com', 'Chicago', 'IL');

-- Insert Orders
INSERT INTO orders (customer_id, order_status, order_date, required_date, shipped_date, store_id) VALUES
(1, 4, '2023-01-15', '2023-01-25', '2023-01-20', 1),
(2, 4, '2023-02-10', '2023-02-20', '2023-02-18', 2),
(3, 3, '2022-12-05', '2022-12-15', NULL, 1),  -- Rejected order older than 1 year
(4, 4, '2023-03-20', '2023-03-30', '2023-03-28', 3),
(5, 1, '2024-01-10', '2024-01-20', NULL, 2),
(1, 4, '2023-04-05', '2023-04-15', '2023-04-12', 1),
(2, 3, '2022-11-15', '2022-11-25', NULL, 2);  -- Rejected order older than 1 year

-- Insert Order Items
INSERT INTO order_items (order_id, item_id, product_id, quantity, list_price, discount) VALUES
(1, 1, 1, 1, 28000.00, 0.05),
(1, 2, 5, 1, 48000.00, 0.10),
(2, 1, 3, 1, 62000.00, 0.05),
(3, 1, 2, 1, 29500.00, 0.00),
(4, 1, 4, 2, 55000.00, 0.07),
(4, 2, 8, 1, 32000.00, 0.05),
(5, 1, 6, 1, 22000.00, 0.00),
(6, 1, 7, 1, 68000.00, 0.08),
(7, 1, 9, 1, 21000.00, 0.00);

-- Insert Stocks
INSERT INTO stocks (store_id, product_id, quantity) VALUES
(1, 1, 5),
(1, 2, 0),  -- Zero stock
(1, 5, 2),
(2, 3, 0),  -- Zero stock
(2, 4, 3),
(2, 8, 1),
(3, 6, 4),
(3, 7, 0),  -- Zero stock
(3, 9, 2),
(3, 10, 0); -- Zero stock

-------------------Problem 1 ------------------

-- Level-1: Problem 1 – Product Analysis Using Nested Queries
--  Scenario:
-- You are working as a database developer for an automobile retail company. Management wants to identify products that are priced higher than the average price of products in their respective categories.
--  📌 Requirements
-- 1. Retrieve product details (product_name, model_year, list_price).
-- 2. Compare each product’s price with the average price of products in the same category using a nested query.
-- 3. Display only those products whose price is greater than the category average.
-- 4. Show calculated difference between product price and category average.
-- 5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').
--  🛠️ Technical Constraints
-- • Use subquery in WHERE clause.
-- • Use aggregate function (AVG).
-- • Use string manipulation functions.
-- • Use arithmetic expressions for price difference calculation.

--  Expectations:
-- • Proper use of nested query.
-- • Correct calculation of average and difference.
-- • Clean and readable SQL query.
--  🎯 Learning Outcome
-- • Understand nested queries with aggregate functions.
-- • Perform calculations inside SELECT statement.
-- • Apply string concatenation in SQL.


SELECT 
CONCAT(p.product_name,' (',p.model_year,')') AS product_details,
p.product_name,
p.model_year,
p.list_price,

p.list_price-(                    
SELECT AVG(p2.list_price)              --Corelated Queries
FROM products p2
WHERE p2.category_id = p.category_id)
AS price_difference 

FROM products p

WHERE p.list_price >
(
    SELECT AVG(p2.list_price)
    FROM products p2
    WHERE p2.category_id = p.category_id
);

