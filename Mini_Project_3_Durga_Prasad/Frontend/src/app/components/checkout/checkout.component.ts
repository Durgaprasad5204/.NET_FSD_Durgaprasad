import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService, CartItem } from '../../services/cart.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './checkout.component.html'
})
export class CheckoutComponent implements OnInit {
  checkoutForm;
  cartItems: CartItem[] = [];
  subtotal = 0;
  shipping = 50;
  tax = 0;
  total = 0;
  isProcessing = false;

  constructor(
    private fb: FormBuilder,
    private cartService: CartService,
    private http: HttpClient,
    private router: Router
  ) {
    this.checkoutForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      address: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      pincode: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      paymentMethod: ['card'],
      cardNumber: [''],
      cardName: [''],
      expiry: [''],
      cvv: [''],
      upiId: ['']
    });
  }

  ngOnInit() {
    if (this.cartService.getTotal() === 0) {
      this.router.navigate(['/cart']);
    }
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

  placeOrder() {
    if (this.checkoutForm.invalid) return;
    this.isProcessing = true;
    
    const orderItems = this.cartItems.map(item => ({
      productId: item.productId,
      quantity: item.quantity
    }));
    
    this.http.post('https://localhost:7128/api/orders', { items: orderItems }).subscribe({
      next: () => {
        this.cartService.clearCart();
        alert('Order placed successfully!');
        this.router.navigate(['/products']);
      },
      error: (err) => {
        console.error(err);
        alert('Order failed. Please try again.');
        this.isProcessing = false;
      }
    });
  }
}