// Cart page functionality

$(document).ready(function() {
    loadCartItems();
    
    $('#clearCartBtn').click(clearCart);
    $('#continueShoppingBtn').click(function() {
        window.location.href = 'products.html';
    });
    $('#checkoutBtn').click(function() {
        if (cart.length > 0) {
            window.location.href = 'checkout.html';
        } else {
            alert('Your cart is empty!');
        }
    });
});

// Load and display cart items
function loadCartItems() {
    if (cart.length === 0) {
        $('#cartItems').hide();
        $('#cartSummary').hide();
        $('#emptyCartMessage').show();
        return;
    }
    
    $('#cartItems').show();
    $('#cartSummary').show();
    $('#emptyCartMessage').hide();
    
    displayCartItems();
}

// Display cart items
function displayCartItems() {
    const container = $('#cartItems');
    container.empty();
    
    cart.forEach((item, index) => {
        const itemTotal = item.price * (item.quantity || 1);
        
        const row = `
            <div class="cart-item row align-items-center">
                <div class="col-md-2">
                    <img src="${item.image}" 
                         alt="${item.name}"
                         onerror="this.src='https://via.placeholder.com/80x80/6c757d/ffffff?text=No+Image'"
                         class="img-fluid rounded">
                </div>
                <div class="col-md-4">
                    <h5 class="cart-item-title">${item.name}</h5>
                    <p class="text-muted small">${item.description.substring(0, 50)}...</p>
                </div>
                <div class="col-md-2">
                    <p class="cart-item-price">${formatPrice(item.price)}</p>
                </div>
                <div class="col-md-2">
                    <input type="number" class="form-control quantity-input" 
                           value="${item.quantity || 1}" min="1" max="10" 
                           data-index="${index}">
                </div>
                <div class="col-md-1">
                    <p class="cart-item-price">${formatPrice(itemTotal)}</p>
                </div>
                <div class="col-md-1">
                    <button class="btn btn-link text-danger remove-item" data-index="${index}">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
        
        container.append(row);
    });
    
    // Update summary
    updateCartSummary();
    
    // Add event handlers
    $('.quantity-input').change(function() {
        const index = $(this).data('index');
        const newQuantity = parseInt($(this).val());
        updateQuantity(index, newQuantity);
    });
    
    $('.remove-item').click(function() {
        const index = $(this).data('index');
        removeFromCart(index);
    });
}

// Update cart summary
function updateCartSummary() {
    const subtotal = cart.reduce((total, item) => total + (item.price * (item.quantity || 1)), 0);
    const shipping = subtotal > 0 ? 50 : 0;
    const tax = subtotal * 0.18;
    const total = subtotal + shipping + tax;
    
    $('#subtotal').text(formatPrice(subtotal));
    $('#shipping').text(formatPrice(shipping));
    $('#tax').text(formatPrice(tax));
    $('#total').text(formatPrice(total));
}

// Update item quantity
function updateQuantity(index, newQuantity) {
    if (newQuantity < 1) newQuantity = 1;
    if (newQuantity > 10) newQuantity = 10;
    
    cart[index].quantity = newQuantity;
    saveCart();
    displayCartItems();
    showNotification('Cart updated successfully!');
}

// Remove item from cart
function removeFromCart(index) {
    cart.splice(index, 1);
    saveCart();
    loadCartItems();
    showNotification('Item removed from cart!');
}

// Clear entire cart
function clearCart() {
    if (cart.length > 0 && confirm('Are you sure you want to clear your cart?')) {
        cart = [];
        saveCart();
        loadCartItems();
        showNotification('Cart cleared successfully!');
    }
}