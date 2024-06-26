﻿(function () {

    function prepareStripeButton() {
        var handler = StripeCheckout.configure({
            key: $('#stripePublishableKey').val(),
            locale: 'auto',
            currency: $('input[name=currency]').val(),
            token: function (token) {
                abp.ui.setBusy();
                $('input[name=stripeToken]').val(token.id);
                $('#stripeCheckoutForm').submit();
            }
        });

        document.getElementById('stripe-checkout').addEventListener('click', function (e) {
            var price = $('input[name=amount]').val();
            handler.open({
                name: 'Api',
                description: $('input[name=description]').val(),
                amount: price.replace('.', '')
            });
            e.preventDefault();
        });

        window.addEventListener('popstate', function () {
            handler.close();
        });
    }

    prepareStripeButton();

})();