// Common functions

// Global cart variable
let cart = [];

// Initialize application
$(document).ready(function() {
    // Load cart from localStorage
    loadCart();
    
    // Update cart count
    updateCartCount();
    
    // Handle search if on products page
    if ($('#searchInput').length) {
        setupSearch();
    }
});

// Load cart from localStorage
function loadCart() {
    const savedCart = localStorage.getItem('shopEZCart');
    cart = savedCart ? JSON.parse(savedCart) : [];
}

// Save cart to localStorage
function saveCart() {
    localStorage.setItem('shopEZCart', JSON.stringify(cart));
    updateCartCount();
}

// Update cart count in navbar
function updateCartCount() {
    const count = cart.reduce((total, item) => total + (item.quantity || 1), 0);
    $('.cart-count').text(count);
}

// Format price in Indian Rupees
function formatPrice(price) {
    return '₹' + price.toLocaleString('en-IN');
}

// Show loading spinner
function showLoading(container) {
    $(container).html('<div class="spinner"></div>');
}

// Hide loading spinner
function hideLoading(container) {
    $(container).find('.spinner').remove();
}

// Show notification
function showNotification(message, type = 'success') {
    const notification = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    
    $('#notificationArea').html(notification);
    
    // Auto dismiss after 3 seconds
    setTimeout(() => {
        $('.alert').alert('close');
    }, 3000);
}

// Get all products
function getAllProducts(callback) {
    $.getJSON('data/products.json', function(products) {
        callback(products);
    }).fail(function() {
        console.error('Error loading products');
        callback([]);
    });
}

// Get product by ID
function getProductById(productId, callback) {
    getAllProducts(function(products) {
        const product = products.find(p => p.id === productId);
        callback(product);
    });
}

// Setup search functionality
function setupSearch() {
    let searchTimeout;
    $('#searchInput').on('input', function() {
        clearTimeout(searchTimeout);
        const searchTerm = $(this).val();
        
        searchTimeout = setTimeout(function() {
            if (searchTerm.length >= 2 || searchTerm.length === 0) {
                if (typeof performSearch === 'function') {
                    performSearch(searchTerm);
                }
            }
        }, 500);
    });
}

// Create product card (used across multiple pages)
function createProductCard(product) {
    return `
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card product-card">
                <img src="${product.image}" 
                     class="card-img-top" 
                     alt="${product.name}"
                     onerror="this.src='https://via.placeholder.com/300x200/6c757d/ffffff?text=Image+Not+Found'">
                <div class="card-body">
                    <span class="category-badge">${product.category}</span>
                    <h5 class="card-title">${product.name}</h5>
                    <p class="card-text">${product.description.substring(0, 100)}...</p>
                    <p class="product-price">${formatPrice(product.price)}</p>
                    <div class="d-flex justify-content-between">
                        <button class="btn btn-outline-primary view-details" data-id="${product.id}">
                            View Details
                        </button>
                        <button class="btn btn-primary add-to-cart" data-id="${product.id}">
                            Add to Cart
                        </button>
                    </div>
                </div>
            </div>
        </div>
    `;
}