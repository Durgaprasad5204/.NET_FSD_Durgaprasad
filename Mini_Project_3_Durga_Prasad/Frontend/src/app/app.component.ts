import { Component, OnInit } from '@angular/core';
import { RouterOutlet, RouterLink, Router, NavigationEnd } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { CartService } from './services/cart.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoggedIn = false;
  isAdmin = false;
  cartCount = 0;
  showSearch = false;
  searchTerm = '';
  notificationMessage = '';
  notificationType = 'success';

  constructor(
    private authService: AuthService,
    private cartService: CartService,
    private router: Router
  ) {}

  ngOnInit() {
    this.authService.getAuthStatus().subscribe(status => {
      this.isLoggedIn = status;
      this.isAdmin = this.authService.isAdmin();
    });
    this.cartService.getCartCount().subscribe(count => this.cartCount = count);
    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
      this.showSearch = this.router.url.includes('/products');
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  onSearch() {
    if (this.searchTerm.trim()) {
      this.router.navigate(['/products'], { queryParams: { search: this.searchTerm } });
      this.searchTerm = '';
    }
  }

  clearNotification() {
    this.notificationMessage = '';
  }
}