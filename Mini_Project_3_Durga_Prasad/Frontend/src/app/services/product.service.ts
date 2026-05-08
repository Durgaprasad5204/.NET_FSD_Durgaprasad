import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const API_URL = 'https://localhost:7128/api/products';

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  stock: number;
  imageUrl: string;
  category?: string;   // ✅ Added optional category
}

@Injectable({ providedIn: 'root' })
export class ProductService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<{ data: Product[] }>(API_URL).pipe(map(res => res.data));
  }

 getProductById(id: number): Observable<Product> {
  return this.http
    .get<{ data: Product }>(`${API_URL}/${id}`)
    .pipe(map(res => res.data));
}

  createProduct(product: Partial<Product>): Observable<Product> {
    return this.http.post<Product>(API_URL, product);
  }

  updateProduct(id: number, product: Partial<Product>): Observable<Product> {
    return this.http.put<Product>(`${API_URL}/${id}`, product);
  }

  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}