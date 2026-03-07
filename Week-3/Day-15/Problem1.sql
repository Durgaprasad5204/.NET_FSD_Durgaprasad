

CREATE DATABASE EcommDb;

USE EcommDb;


CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(255) NOT NULL
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(255) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(255) NOT NULL,
    brand_id INT FOREIGN KEY REFERENCES brands(brand_id),
    category_id INT FOREIGN KEY REFERENCES categories(category_id),
    model_year SMALLINT NOT NULL,
    list_price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    city VARCHAR(100),
    email VARCHAR(255) UNIQUE
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(255) NOT NULL,
    city VARCHAR(100)
);

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    store_id INT FOREIGN KEY REFERENCES stores(store_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT FOREIGN KEY REFERENCES customers(customer_id),
    store_id INT FOREIGN KEY REFERENCES stores(store_id),
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    order_date DATE NOT NULL
);



-- Inserting records into table
INSERT INTO categories VALUES ('Sedan'), ('SUV'), ('Hatchback'), ('Truck'), ('Electric');
INSERT INTO brands VALUES ('Toyota'), ('Ford'), ('Tesla'), ('Honda'), ('BMW');

INSERT INTO products VALUES 
('Camry', 1, 1, 2023, 25000),
('F-150', 2, 4, 2022, 35000),
('Model 3', 3, 5, 2023, 40000), 
('Civic', 4, 1, 2021, 22000), 
('X5', 5, 2, 2023, 60000);

INSERT INTO customers VALUES 
('John', 'Doe', 'New York', 'j.doe@email.com'), 
('Jane', 'Smith', 'Chicago', 'j.smith@email.com'),
('Alice', 'Brown', 'New York', 'a.brown@email.com'), 
('Bob', 'Johnson', 'Miami', 'b.johnson@email.com'),
('Charlie', 'Davis', 'Chicago', 'c.davis@email.com');

INSERT INTO stores VALUES ('Downtown Auto', 'New York'), 
('Windy City Cars', 'Chicago');



-- DAY-4 Hands On
-- Pre-Requisites: Before starting with problem solving, please make sure that you have created a database and restored data  
-- Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb

-- Scenario
-- You are assigned as a database developer to set up the EcommDb database for an automobile retail company. The company wants to verify basic operations such as inserting data and retrieving product and customer information.

-- 📌 Requirements 
-- - Create EcommDb and all tables using the provided schema.
-- - Insert at least 5 records in categories, brands, products, customers, and stores.
-- - Write SELECT queries to retrieve all products with their brand and category names.
-- - Retrieve all customers from a specific city.
-- - Display total number of products available in each category.

-- 🛠️ Technical Constraints 
-- - Use SQL Server.
-- - Use ANSI SQL queries wherever applicable.
-- - Do not modify the existing table structure.
-- - Ensure foreign key constraints are satisfied while inserting data.

-- Expectations
-- - Successful creation of database and tables.
-- - Accurate data insertion without constraint violations.
-- - Correct JOIN queries to retrieve relational data.

-- 🎯 Learning Outcome 
-- - Understand database setup process.
-- - Learn basic SELECT, INSERT and JOIN operations.
-- - Gain understanding of relational data retrieval.


USE EcommDb;

-- 1. All products with Brand and Category
SELECT p.product_name, b.brand_name, c.category_name 
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

-- 2. Customers from a specific city
SELECT * FROM customers WHERE city = 'New York';

-- 3. Total products per category
SELECT category_name, COUNT(product_id) AS total_products
FROM categories c
LEFT JOIN products p ON c.category_id = p.category_id
GROUP BY category_name;

