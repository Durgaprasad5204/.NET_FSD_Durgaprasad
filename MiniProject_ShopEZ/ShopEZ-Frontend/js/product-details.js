// Product details page functionality

$(document).ready(function() {
    const urlParams = new URLSearchParams(window.location.search);
    const productId = parseInt(urlParams.get('id'));
    
    if (productId) {
        loadProductDetails(productId);
        loadRelatedProducts(productId);
    } else {
        window.location.href = 'products.html';
    }
});

// Load product details
function loadProductDetails(productId) {
    showLoading('#productDetailsContainer');
    
    getProductById(productId, function(product) {
        if (product) {
            displayProductDetails(product);
            hideLoading('#productDetailsContainer');
        } else {
            $('#productDetailsContainer').html('<div class="col-12 text-center"><p class="lead text-danger">Product not found.</p></div>');
        }
    });
}

// Display product details
function displayProductDetails(product) {
    const html = `
        <div class="row">
            <div class="col-md-6">
                <img src="${product.image}" 
                     class="product-details-image img-fluid rounded" 
                     alt="${product.name}"
                     onerror="this.src='https://via.placeholder.com/400x400/6c757d/ffffff?text=Image+Not+Found'">
            </div>
            <div class="col-md-6">
                <h1>${product.name}</h1>
                <span class="category-badge">${product.category}</span>
                <p class="product-details-price mt-3">${formatPrice(product.price)}</p>
                <p class="lead">${product.description}</p>
                
                <h4>Specifications:</h4>
                <ul class="specs-list">
                    ${product.specs.map(spec => `<li>${spec}</li>`).join('')}
                </ul>
                
                <div class="row mt-4">
                    <div class="col-md-4">
                        <label for="quantity">Quantity:</label>
                        <input type="number" class="form-control" id="quantity" value="1" min="1" max="10">
                    </div>
                </div>
                
                <div class="mt-4">
                    <button class="btn btn-primary btn-lg" id="addToCartBtn" data-id="${product.id}">
                        <i class="fas fa-shopping-cart"></i> Add to Cart
                    </button>
                    <button class="btn btn-success btn-lg" id="buyNowBtn" data-id="${product.id}">
                        <i class="fas fa-bolt"></i> Buy Now
                    </button>
                </div>
            </div>
        </div>
    `;
    
    $('#productDetailsContainer').html(html);
    
    // Add event handlers
    $('#addToCartBtn').click(function() {
        const productId = $(this).data('id');
        const quantity = parseInt($('#quantity').val()) || 1;
        addToCartWithQuantity(productId, quantity);
    });
    
    $('#buyNowBtn').click(function() {
        const productId = $(this).data('id');
        const quantity = parseInt($('#quantity').val()) || 1;
        addToCartWithQuantity(productId, quantity);
        window.location.href = 'checkout.html';
    });
}

// Load related products
function loadRelatedProducts(currentProductId) {
    getAllProducts(function(products) {
        const related = products
            .filter(p => p.id !== currentProductId)
            .slice(0, 3);
        
        const container = $('#relatedProducts');
        container.empty();
        
        related.forEach(product => {
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
    });
}

// Add to cart with quantity
function addToCartWithQuantity(productId, quantity) {
    getProductById(productId, function(product) {
        if (product) {
            const existingItem = cart.find(item => item.id === productId);
            
            if (existingItem) {
                existingItem.quantity = (existingItem.quantity || 1) + quantity;
                showNotification('Product quantity updated in cart!');
            } else {
                product.quantity = quantity;
                cart.push(product);
                showNotification('Product added to cart successfully!');
            }
            
            saveCart();
        }
    });
}