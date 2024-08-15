$(document).ready(function () {
    $('.fa-bars').click(function () {
        $(this).toggleClass('fa-times');
        $('.navbar').toggleClass('nav-toggle');
    });
    $(window).on('load scroll', function () {
        if ($(window).width() <= 768) {
            $('.fa-bars').removeClass('fa-times');
            $('.navbar').removeClass('nav-toggle');
            $('.navbar').hide();
        }

        if ($(window).scrollTop() > 30) {
            $('.header').css({ 'background': '#FAEDCB', 'box-shadow': '0 .2rem .5rem rgba(0,0,0,.3)' });
        } else {
            $('.header').css({ 'background': 'none', 'box-shadow': 'none' });
        }
    });

    $('.fa-bars').click(function () {
        if ($('.navbar').hasClass('nav-toggle')) {
            $('.navbar').show();
        } else {
            $('.navbar').hide();
        }
    });
});
