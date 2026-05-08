import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from './product.service';

export interface CartItem {
  productId: number;
  name: string;
  price: number;
  quantity: number;
  imageUrl: string;
  
  description?: string; // optional for cart display
}

@Injectable({ providedIn: 'root' })
export class CartService {
  private cartKey = 'shopez_cart';
  private cartItems = new BehaviorSubject<CartItem[]>([]);
  private cartCount = new BehaviorSubject<number>(0);

  constructor() {
    this.loadCart();
  }

  private loadCart(): void {
    const stored = localStorage.getItem(this.cartKey);
    if (stored) {
      const items = JSON.parse(stored);
      this.cartItems.next(items);
      this.updateCount(items);
    }
  }
  

  private saveCart(items: CartItem[]): void {
    localStorage.setItem(this.cartKey, JSON.stringify(items));
    this.cartItems.next(items);
    this.updateCount(items);
  }

  private updateCount(items: CartItem[]): void {
    const count = items.reduce((sum, item) => sum + item.quantity, 0);
    this.cartCount.next(count);
  }

  getCartItems() {
    return this.cartItems.asObservable();
  }

  getCartCount() {
    return this.cartCount.asObservable();
  }

  addToCart(product: Product, quantity: number = 1): void {
    const current = this.cartItems.value;
    const existing = current.find(item => item.productId === product.id);
    if (existing) {
      existing.quantity += quantity;
      this.saveCart([...current]);
    } else {
      const newItem: CartItem = {
        productId: product.id,
        name: product.name,
        price: product.price,
        quantity: quantity,
        imageUrl: product.imageUrl,
        description: product.description
      };
      this.saveCart([...current, newItem]);
    }
  }

  increaseQuantity(item: CartItem): void {
    this.updateQuantity(item, item.quantity + 1);
  }

  decreaseQuantity(item: CartItem): void {
    if (item.quantity > 1) {
      this.updateQuantity(item, item.quantity - 1);
    } else {
      this.removeItem(item);
    }
  }

  updateQuantity(item: CartItem, quantity: number): void {
    const current = this.cartItems.value;
    const index = current.findIndex(i => i.productId === item.productId);
    if (index !== -1) {
      current[index].quantity = quantity;
      this.saveCart([...current]);
    }
  }

  removeItem(item: CartItem): void {
    const current = this.cartItems.value.filter(i => i.productId !== item.productId);
    this.saveCart(current);
  }

  clearCart(): void {
    this.saveCart([]);
  }

  getTotal(): number {
    return this.cartItems.value.reduce((sum, i) => sum + (i.price * i.quantity), 0);
  }
}