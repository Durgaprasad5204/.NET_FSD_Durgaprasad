import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-admin-add-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './admin-add-product.component.html'
})
export class AdminAddProductComponent implements OnInit {
  isEdit = false;
  productId?: number;
  productForm;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      stock: [0, [Validators.required, Validators.min(0)]],
      imageUrl: [''],
      category: ['electronics']
    });
  }

  ngOnInit() {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.productId) {
      this.isEdit = true;
      this.productService.getProductById(this.productId).subscribe(product => {
        this.productForm.patchValue(product);
      });
    }
  }

  saveProduct() {
    // Get raw form value (may contain nulls)
    const rawValue = this.productForm.value;
    
    // Sanitize: convert null/undefined to appropriate defaults
    const product = {
      name: rawValue.name || '',
      description: rawValue.description || '',
      price: rawValue.price ?? 0,
      stock: rawValue.stock ?? 0,
      imageUrl: rawValue.imageUrl || '',
      category: rawValue.category || 'electronics'
    };
    
    if (this.isEdit && this.productId) {
      this.productService.updateProduct(this.productId, product).subscribe(() => this.router.navigate(['/admin']));
    } else {
      this.productService.createProduct(product).subscribe(() => this.router.navigate(['/admin']));
    }
  }
}