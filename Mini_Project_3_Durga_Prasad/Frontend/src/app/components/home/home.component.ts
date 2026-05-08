import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ProductService, Product } from '../../services/product.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  featuredProducts: Product[] = [];

  // ✅ Backend image URL (no environment)
  imageBaseUrl = 'https://localhost:7128/images/';

  constructor(
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(products => {
      this.featuredProducts = products.slice(0, 3);
    });
  }

  formatPrice(price: number): string {
    return '₹' + price.toLocaleString('en-IN');
  }

  addToCart(product: Product) {
    this.cartService.addToCart(product, 1);
    alert(`${product.name} added to cart!`);
  }

  getImage(url: string): string {
  if (!url) return 'https://via.placeholder.com/300x200';

  // Fix duplicate base URL
  return url.replace(
    'https://localhost:7128https://localhost:7128',
    'https://localhost:7128'
  );
}

  // ✅ Fallback if image fails
  onImageError(event: any) {
    event.target.src =
      'https://via.placeholder.com/300x200/6c757d/ffffff?text=Image+Not+Found';
  }
}