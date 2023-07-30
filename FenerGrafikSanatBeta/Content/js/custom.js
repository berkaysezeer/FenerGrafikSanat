$('table[data-table="true"]').DataTable({
    language: {
        url: "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    },

    columnDefs: [
        { type: 'turkish', targets: 'turkce' }
    ]
});

$(document).ready(function () {
    // Show or hide the sticky footer button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $('#goTop').fadeIn(200);
        } else {
            $('#goTop').fadeOut(200);
        }
    });

    // Animate the scroll to top
    $('#goTop').click(function (event) {
        event.preventDefault();

        $('html, body').animate({ scrollTop: 0 }, 300);
    })
});

$(document).ready(function () {
    // Add smooth scrolling to all links
    $("a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 800, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
});

$(".navbarYonetimClick").click(function () {
    $(".dmYonetim").toggleClass("navbarEdit");
    $(".dmKullanici").removeClass("navbarEdit");
});

$(".navbarKullaniciClick").click(function () {
    $(".dmKullanici").toggleClass("navbarEdit");
    $(".dmYonetim").removeClass("navbarEdit");
});