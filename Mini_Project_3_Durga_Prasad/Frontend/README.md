# ShopezFrontend 🛍️

## 🔐 Admin Login Credentials

```bash
Admin Username : admin
Admin Email    : admin@admin.com
Admin Password : Admin@123
```

> Change these credentials in production for security purposes.

---

ShopezFrontend is a modern **Angular 19 E-Commerce Web Application** built as part of a **.NET Full Stack Development** project.  
This frontend application provides a complete shopping experience including:

- User Authentication
- Product Listing
- Product Details
- Shopping Cart
- Responsive UI
- Image Handling from Frontend Assets
- API Integration with .NET Backend Microservices
- Admin Product Management Features

The project is developed using **Angular Standalone Components**, modern Angular practices, and a clean responsive UI.

---

# 🚀 Technologies Used

- Angular 19
- TypeScript
- HTML5
- CSS3
- RxJS
- Angular Router
- HTTP Client
- Bootstrap / Custom CSS
- REST APIs
- .NET Backend APIs

---

# 📂 Project Structure

```bash
src/
 ├── app/
 │    ├── components/
 │    ├── services/
 │    ├── models/
 │    ├── pages/
 │    ├── guards/
 │    ├── interceptors/
 │    └── shared/
 │
 ├── assets/
 │    └── images/
 │         └── products/
 │
 ├── environments/
 └── styles.css
```

---

# ✨ Features

## 👤 Authentication
- User Registration
- User Login
- JWT Token Handling
- Protected Routes

## 🛒 Shopping Features
- View Products
- Product Details Page
- Add to Cart
- Remove from Cart
- Quantity Management
- Cart Total Calculation

## 🖼️ Frontend Image Management
- Product images stored inside Angular assets folder
- Images displayed dynamically across:
  - Home Page
  - Products Page
  - Product Details Page
  - Cart Page

## 📱 Responsive Design
- Mobile Friendly UI
- Tablet Responsive Layout
- Desktop Optimized Experience

## ⚙️ API Integration
- Connected with .NET Backend APIs
- Dynamic Product Fetching
- Real-time Data Rendering

## 🔐 Admin Features
- Add Products
- Update Products
- Delete Products
- Product Image Preview Support

---

# 📦 Installation

## Clone the Repository

```bash
git clone <your-repository-url>
```

## Navigate to Project Folder

```bash
cd ShopezFrontend
```

## Install Dependencies

```bash
npm install
```

---

# ▶️ Development Server

Run the following command:

```bash
ng serve
```

Open your browser and navigate to:

```bash
http://localhost:4200/
```

The application will automatically reload whenever changes are made.

---

# 🏗️ Build Project

To build the application:

```bash
ng build
```

Build files will be generated inside:

```bash
dist/
```

---

# 🧪 Running Tests

## Unit Tests

```bash
ng test
```

## End-to-End Tests

```bash
ng e2e
```

---

# 🖼️ Product Images Setup

Store all product images inside:

```bash
src/assets/images/products/
```

Example:

```bash
src/assets/images/products/laptop.jpg
```

Use image paths like:

```typescript
imageUrl: 'assets/images/products/laptop.jpg'
```

---

# 🔗 Backend Connection

Make sure your .NET Backend APIs are running before starting the frontend.

Example API:

```bash
https://localhost:7128/api/products
```

Update API URLs inside your Angular services if required.

---

# 📌 Angular CLI Commands

## Generate Component

```bash
ng generate component component-name
```

## Generate Service

```bash
ng generate service service-name
```

## Generate Guard

```bash
ng generate guard guard-name
```

---

# 📖 Additional Resources

- Angular Documentation → https://angular.dev/
- Angular CLI Documentation → https://angular.dev/tools/cli
- .NET Documentation → https://learn.microsoft.com/en-us/dotnet/

---

# 👨‍💻 Developer

Developed by **Durgaprasad** as part of a **.NET Full Stack Development** learning project.