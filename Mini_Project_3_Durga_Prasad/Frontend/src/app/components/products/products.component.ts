import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ProductService, Product } from '../../services/product.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],  
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {
  allProducts: Product[] = [];
  filteredProducts: Product[] = [];
  categoryFilter = 'all';
  sortBy = 'name';
  searchTerm = '';

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(products => {
      this.allProducts = products;
      this.applyFilters();
    });
    this.route.queryParams.subscribe(params => {
      this.searchTerm = params['search'] || '';
      this.applyFilters();
    });
  }

  applyFilters() {
    let filtered = [...this.allProducts];
    if (this.searchTerm) {
      filtered = filtered.filter(p => 
        p.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        p.description.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
    if (this.categoryFilter !== 'all') {
      filtered = filtered.filter(p => (p.category || 'electronics') === this.categoryFilter);
    }
    this.filteredProducts = filtered;
    this.sortProducts();
  }

  filterProducts() {
    this.applyFilters();
  }

  sortProducts() {
    switch (this.sortBy) {
      case 'price-low':
        this.filteredProducts.sort((a, b) => a.price - b.price);
        break;
      case 'price-high':
        this.filteredProducts.sort((a, b) => b.price - a.price);
        break;
      case 'name':
        this.filteredProducts.sort((a, b) => a.name.localeCompare(b.name));
        break;
    }
  }

  formatPrice(price: number): string {
    return '₹' + price.toLocaleString('en-IN');
  }

  addToCart(product: Product) {
    this.cartService.addToCart(product, 1);
    alert(`${product.name} added to cart!`);
  }
}