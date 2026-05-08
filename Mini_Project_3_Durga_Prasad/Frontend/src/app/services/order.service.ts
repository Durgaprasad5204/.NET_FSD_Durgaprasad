import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = 'https://localhost:7128/api/orders';

export interface OrderItem {
  productId: number;
  quantity: number;
  productName?: string;
  price?: number;
}

export interface Order {
  id: number;
  orderDate: string;
  items: OrderItem[];
  totalAmount: number;
  status: string;
}

@Injectable({ providedIn: 'root' })
export class OrderService {
  constructor(private http: HttpClient) {}

  // Get all orders for the logged-in user
  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(API_URL);
  }

  // Get single order by ID
  getOrderById(id: number): Observable<Order> {
    return this.http.get<Order>(`${API_URL}/${id}`);
  }
}