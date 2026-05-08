import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ProductService, Product } from '../../services/product.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './product-details.component.html'
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;
  quantity = 1;
  relatedProducts: Product[] = [];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productService.getProductById(id).subscribe(data => {
      this.product = data;
      this.loadRelatedProducts(id);
    });
  }

  loadRelatedProducts(currentId: number) {
    this.productService.getProducts().subscribe(products => {
      this.relatedProducts = products.filter(p => p.id !== currentId).slice(0, 3);
    });
  }

  formatPrice(price: number | undefined): string {
  if (!price) return '₹0';
  return '₹' + price.toLocaleString('en-IN');
}

  addToCart() {
    if (this.product && this.quantity <= this.product.stock) {
      this.cartService.addToCart(this.product, this.quantity);
      alert('Added to cart!');
    } else {
      alert('Invalid quantity');
    }
  }

  buyNow() {
    this.addToCart();
    setTimeout(() => {
      window.location.href = '/checkout';
    }, 300);
  }
}