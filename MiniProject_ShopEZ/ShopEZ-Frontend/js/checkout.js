// Checkout page functionality

$(document).ready(function() {
    // Redirect if cart is empty
    if (cart.length === 0) {
        window.location.href = 'cart.html';
        return;
    }
    
    loadOrderSummary();
    
    // Handle form submission
    $('#checkoutForm').submit(function(e) {
        e.preventDefault();
        processOrder();
    });
    
    // Handle payment method change
    $('input[name="paymentMethod"]').change(function() {
        const method = $(this).val();
        $('#cardDetails').toggle(method === 'card');
        $('#upiDetails').toggle(method === 'upi');
    });
});

// Load order summary
function loadOrderSummary() {
    const container = $('#orderItems');
    container.empty();
    
    cart.forEach(item => {
        const itemTotal = item.price * (item.quantity || 1);
        const row = `
            <tr>
                <td>${item.name} x ${item.quantity || 1}</td>
                <td class="text-end">${formatPrice(itemTotal)}</td>
            </tr>
        `;
        container.append(row);
    });
    
    updateOrderTotal();
}

// Update order total
function updateOrderTotal() {
    const subtotal = cart.reduce((total, item) => total + (item.price * (item.quantity || 1)), 0);
    const shipping = 50;
    const tax = subtotal * 0.18;
    const total = subtotal + shipping + tax;
    
    $('#orderSubtotal').text(formatPrice(subtotal));
    $('#orderShipping').text(formatPrice(shipping));
    $('#orderTax').text(formatPrice(tax));
    $('#orderTotal').text(formatPrice(total));
}

// Process order
function processOrder() {
    if (!validateForm()) return;
    
    // Simulate order processing
    showLoading('#checkoutForm');
    
    setTimeout(function() {
        hideLoading('#checkoutForm');
        
        // Clear cart
        cart = [];
        saveCart();
        
        // Show success message
        showOrderSuccess();
    }, 2000);
}

// Validate form
function validateForm() {
    let isValid = true;
    const required = ['fullName', 'email', 'phone', 'address', 'city', 'state', 'pincode'];
    
    required.forEach(field => {
        const value = $(`#${field}`).val();
        if (!value || !value.trim()) {
            $(`#${field}`).addClass('is-invalid');
            isValid = false;
        } else {
            $(`#${field}`).removeClass('is-invalid');
        }
    });
    
    // Email validation
    const email = $('#email').val();
    if (email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
        $('#email').addClass('is-invalid');
        isValid = false;
    }
    
    // Phone validation
    const phone = $('#phone').val();
    if (phone && !/^\d{10}$/.test(phone)) {
        $('#phone').addClass('is-invalid');
        isValid = false;
    }
    
    // Pincode validation
    const pincode = $('#pincode').val();
    if (pincode && !/^\d{6}$/.test(pincode)) {
        $('#pincode').addClass('is-invalid');
        isValid = false;
    }
    
    if (!isValid) {
        showNotification('Please fill all required fields correctly', 'danger');
    }
    
    return isValid;
}

// Show order success
function showOrderSuccess() {
    const orderId = 'ORD' + Date.now();
    
    const html = `
        <div class="alert alert-success text-center">
            <h4 class="alert-heading">Order Placed Successfully!</h4>
            <p>Your order ID is: <strong>${orderId}</strong></p>
            <p>Thank you for shopping with ShopEZ!</p>
            <p>Redirecting to home page...</p>
        </div>
    `;
    
    $('#checkoutForm').html(html);
    
    setTimeout(function() {
        window.location.href = 'index.html';
    }, 3000);
}