$(document).ready(function () {
    var urlApi = 'https://localhost:44311/api/';
    //get slide
    var urlApiSlide = urlApi + 'Slide/GetAllSlides';

    $.get(urlApiSlide, function (data, status) {

        var lengthSlides = data.slides.length;

        if (lengthSlides == 1) {
            //inner
            $('.carousel-inner').append(
                '<div class="carousel-item">' +
                    '<img class="d-block w-100" src="' + data.Url + data.slides[0] + '">' +
                '</div>'
            );
        }

        if (lengthSlides > 1) {
            for (var i = 0; i < lengthSlides; i++) {

                var urlImg = data.Url + data.slides[i].Img;
                //indicators
                $('.carousel-indicators').append('<li data-target="#carouselControls" data-slide-to="' + i + '"></li>');

                //inner
                $('.carousel-inner').append(
                    '<div class="carousel-item">' +
                        '<img class="d-block w-100" src="' + urlImg + '">' +
                    '</div>'
                );

                //add class active cho item first
                if (i == 0) {
                    //indicators
                    $('.carousel-indicators li').addClass('active');

                    //inner
                    $('.carousel-item').addClass('active');
                }

            }

            $('.carousel-control-prev, .carousel-control-next').css('display', 'flex');
        }

        $('.carousel').carousel({
            interval: 5000
        });
    }, "json");

    var urlApiProduct = urlApi + 'Product/GetProductsByBrandCategoty';
    //điện thoại
    $.get(urlApiProduct, { categoryUrlHandle: 'dien-thoai', quantity: 10 }, function (response, status) {
        var lengthProducts = response.data.length;

        if (lengthProducts > 0) {
            $('.render-product .product').append(
                '<div class="category category-dien-thoai">' +
                    '<div class="title">' +
                        '<h4>' +
                            '<a href="dien-thoai">ĐIỆN THOẠI NỔI BẬC</a>' +
                        '</h4>' +
                    '</div>' +
                    '<div class="list-item">' +
                    '</div>' +
                '</div>'
            );

            for (var key in response.data) {
                var product = response.data[key];
                var urlImg = `${response.Url}${product.Category.Name}/${product.Brand.Name}/${product.Name}/${product.Colors[0].Img}`;
                var name = `${product.Name} ${product.MemoryAndStorages[0].Ram}/${product.MemoryAndStorages[0].Rom} - Chính hãng`;
                var urlProduct = `/${product.Category.UrlHandle}/${product.Brand.UrlHandle}/${product.Id}`;

                let formatPrice = new Intl.NumberFormat('vi-VN', {
                    style: 'currency',
                    currency: 'VND',
                });
                new Intl.NumberFormat('en-US').format(price)

                var price = formatPrice.format(product.SellingPrice + product.Colors[0].Price + product.MemoryAndStorages[0].Price);

                $('.category-dien-thoai .list-item').append(
                    '<div class="item">' +
                        '<a href="' + urlProduct +'">' +
                            '<img src="' + urlImg + '">' +
                            '<div class="info">' +
                                '<span class="name">' + name + '</span>' +
                                '<span class="price">' + price + '</span>' +
                            '</div>' +
                        '</a>' +
                    '</div>'
                );
            }
        }

    }, "json");
});