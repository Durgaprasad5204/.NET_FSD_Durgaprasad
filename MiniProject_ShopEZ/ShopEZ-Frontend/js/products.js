// Products page functionality

$(document).ready(function() {
    loadProducts();
    
    // Category filter
    $('#categoryFilter').change(function() {
        filterProducts($(this).val());
    });
    
    // Sort products
    $('#sortBy').change(function() {
        sortProducts($(this).val());
    });
});

// Load and display all products
function loadProducts() {
    showLoading('#productsContainer');
    
    getAllProducts(function(products) {
        displayProducts(products);
        hideLoading('#productsContainer');
    });
}

// Display products in grid
function displayProducts(products) {
    const container = $('#productsContainer');
    container.empty();
    
    if (products.length === 0) {
        container.html('<div class="col-12 text-center"><p class="lead">No products found.</p></div>');
        return;
    }
    
    products.forEach(product => {
        container.append(createProductCard(product));
    });
    
    // Add event handlers
    $('.view-details').click(function() {
        const productId = $(this).data('id');
        window.location.href = `product-details.html?id=${productId}`;
    });
    
    $('.add-to-cart').click(function() {
        const productId = $(this).data('id');
        addToCart(productId);
    });
}

// Filter products by category
function filterProducts(category) {
    showLoading('#productsContainer');
    
    getAllProducts(function(products) {
        let filtered = products;
        if (category !== 'all') {
            filtered = products.filter(p => p.category === category);
        }
        displayProducts(filtered);
        hideLoading('#productsContainer');
    });
}

// Sort products
function sortProducts(sortBy) {
    getAllProducts(function(products) {
        let sorted = [...products];
        
        switch(sortBy) {
            case 'price-low':
                sorted.sort((a, b) => a.price - b.price);
                break;
            case 'price-high':
                sorted.sort((a, b) => b.price - a.price);
                break;
            case 'name':
                sorted.sort((a, b) => a.name.localeCompare(b.name));
                break;
        }
        
        displayProducts(sorted);
    });
}

// Search products
function performSearch(searchTerm) {
    showLoading('#productsContainer');
    
    getAllProducts(function(products) {
        if (!searchTerm.trim()) {
            displayProducts(products);
        } else {
            const filtered = products.filter(product => 
                product.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
                product.description.toLowerCase().includes(searchTerm.toLowerCase())
            );
            displayProducts(filtered);
        }
        hideLoading('#productsContainer');
    });
}

// Add to cart function
function addToCart(productId) {
    getProductById(productId, function(product) {
        if (product) {
            const existingItem = cart.find(item => item.id === productId);
            
            if (existingItem) {
                existingItem.quantity = (existingItem.quantity || 1) + 1;
                showNotification('Product quantity updated in cart!');
            } else {
                product.quantity = 1;
                cart.push(product);
                showNotification('Product added to cart successfully!');
            }
            
            saveCart();
        }
    });
}