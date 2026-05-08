import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CartService, CartItem } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './cart.component.html'
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = [];
  subtotal = 0;
  shipping = 50;
  tax = 0;
  total = 0;

  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.cartService.getCartItems().subscribe(items => {
      this.cartItems = items;
      this.calculateTotals();
    });
  }

  calculateTotals() {
    this.subtotal = this.cartService.getTotal();
    this.tax = this.subtotal * 0.18;
    this.total = this.subtotal + this.shipping + this.tax;
  }

  formatPrice(price: number): string {
    return '₹' + price.toLocaleString('en-IN');
  }

  increase(item: CartItem) {
    this.cartService.increaseQuantity(item);
    this.calculateTotals();
  }

  decrease(item: CartItem) {
    this.cartService.decreaseQuantity(item);
    this.calculateTotals();
  }

  remove(item: CartItem) {
    this.cartService.removeItem(item);
    this.calculateTotals();
  }

  clearCart() {
    if (confirm('Are you sure you want to clear your cart?')) {
      this.cartService.clearCart();
    }
  }
}