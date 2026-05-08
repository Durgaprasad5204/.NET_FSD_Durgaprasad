import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminProductsComponent } from './components/admin/admin-products/admin-products.component';
import { AdminAddProductComponent } from './components/admin/admin-add-product/admin-add-product.component';
import { OrderHistoryComponent } from './components/order-history/order-history.component';
import { authGuard } from './guards/auth.guard';
import { adminGuard } from './guards/admin.guard';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'cart', component: CartComponent, canActivate: [authGuard] },
  { path: 'checkout', component: CheckoutComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'orders', component: OrderHistoryComponent, canActivate: [authGuard] },
  { path: 'admin', component: AdminProductsComponent, canActivate: [adminGuard] },
  { path: 'admin/add', component: AdminAddProductComponent, canActivate: [adminGuard] },
  { path: 'admin/add/:id', component: AdminAddProductComponent, canActivate: [adminGuard] },
  { path: '**', redirectTo: '/home' }
];