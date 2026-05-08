import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderService, Order } from '../../services/order.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-order-history',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="container mt-4">
      <h2 class="mb-4">My Orders</h2>
      
      <div *ngIf="loading" class="text-center">
        <div class="spinner"></div>
      </div>

      <div *ngIf="!loading && orders.length === 0" class="alert alert-info">
        You have no orders yet. <a routerLink="/products">Start shopping</a>
      </div>

      <div *ngFor="let order of orders" class="card mb-3">
        <div class="card-header d-flex justify-content-between align-items-center">
          <span>Order #{{order.id}}</span>
          <span class="badge bg-secondary">{{order.status || 'Delivered'}}</span>
        </div>
        <div class="card-body">
          <p class="mb-2"><strong>Order Date:</strong> {{order.orderDate | date:'medium'}}</p>
          <p class="mb-2"><strong>Total Amount:</strong> {{formatPrice(order.totalAmount)}}</p>
          <hr>
          <h6>Items:</h6>
          <ul class="list-group">
            <li *ngFor="let item of order.items" class="list-group-item d-flex justify-content-between align-items-center">
              <div>
                <strong>{{item.productName || 'Product ID: ' + item.productId}}</strong>
                <span class="badge bg-secondary ms-2">Qty: {{item.quantity}}</span>
              </div>
              <span>{{formatPrice(item.price || 0)}}</span>
            </li>
          </ul>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .spinner {
      width: 40px;
      height: 40px;
      border: 3px solid #f3f3f3;
      border-top: 3px solid #3498db;
      border-radius: 50%;
      animation: spin 1s linear infinite;
      margin: 20px auto;
    }
    @keyframes spin {
      0% { transform: rotate(0deg); }
      100% { transform: rotate(360deg); }
    }
  `]
})
export class OrderHistoryComponent implements OnInit {
  orders: Order[] = [];
  loading = true;

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.orderService.getOrders().subscribe({
      next: (data) => {
        this.orders = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load orders', err);
        this.loading = false;
        // If API returns 404 or not implemented, show empty
        this.orders = [];
      }
    });
  }

  formatPrice(price: number): string {
    return '₹' + price.toLocaleString('en-IN');
  }
}