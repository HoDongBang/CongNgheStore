$(document).ready(function () {
    var urlApi = 'https://localhost:44311/api/';

    //message
    function Message(value, color) {
        $('#message').html(value);
        $('#message').css('display', 'inline-block');
        $('#message').addClass(color);
        $('#message').fadeIn('slow');
        setTimeout(function () {
            $('#message').fadeOut('slow');
        }, 3000);
    }

    var message = window.sessionStorage.getItem('message');
    if (message != null) {
        Message(message, 'bg-success');
        window.sessionStorage.removeItem('message');
    }

    //order
    var order = JSON.parse(window.sessionStorage.getItem('order'));

    if (order == null) {
        window.sessionStorage.setItem('order', JSON.stringify([]));
        order = JSON.parse(window.sessionStorage.getItem('order'));
    }

    var cartTotal = order.reduce(function (accumlator, currentValue, currentIndex, arr) {
        return accumlator + currentValue.quantity;
    }, 0);

    $('#cart-total').html(cartTotal);

    //login
    function decodeJwt(token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    }
    
    
    function displayName() {
        var token = window.localStorage.getItem('token');
        if (token != null) {
            if (verifyExpires(token)) {
                var payload = decodeJwt(token);
                var lastName = payload['LastName'];

                $('.login').html(
                    '<div>' +
                    '<div class="account">' +
                    '<a href="User/Detail" style="font-size: 15px; padding-right: 5px;">' +
                    '<i class="bi bi-person-check" style="font-size: 20px; padding-right: 5px;"></i>' + lastName +
                    '</a >' +
                    '<div class="sub-login">' +
                    '<a href=""><button type="button" class="btn">Tài khoản</button></a>' +
                    '<button id="dang-xuat" type="button" class="btn">Đăng xuất</button>' +
                    '</div>' +
                    '<div>' +
                    '</div >'
                );
            }
        }
        else {
            $('.login').html(
                '<div>'+
                    '<a href="/User/SignUp"> Đăng ký</a >'+
                    '<a href="/User/SignIn">Đăng nhập</a>' +
                '</div >'
            );
        }
    };

    displayName();

    function verifyExpires(token) {
        if (token != null) {
            var payload = decodeJwt(token);
            var expires = payload['exp'];
            if (Date.now() >= expires * 1000) 
                return false;
            return true;
        }
    }
    
    setInterval(function () {
        var token = window.localStorage.getItem('token');
        if (verifyExpires(token) == false) {
            //xoa token
            window.localStorage.removeItem('token');
            //reload lai trang 
            window.location.reload();
            //hien thong bao
            $('#message').html('Đăng nhập hết hạn!');
            $('#message').css('display', 'inline-block');
            $('#message').addClass('bg-danger');
            $('#message').fadeIn('slow');
            setTimeout(function () {
                $('#message').fadeOut('slow');
            }, 3000);
        }
    }, 60000);

    //dang xuat
    $('#dang-xuat').click(async function () {
        var urlApiSignOut = urlApi + 'Account/SignOut';
        function error(value) {
            $('#message').html(value);
            $('#message').css('display', 'inline-block');
            $('#message').addClass('bg-danger');
            $('#message').fadeIn('slow');
            setTimeout(function () {
                $('#message').fadeOut('slow');
            }, 3000);
        };
        function successTrue(value) {
            //xoa token
            window.localStorage.removeItem('token');
            //reload lai trang 
            window.location.reload();
            //hien thong bao
            $('#message').html(value);
            $('#message').css('display', 'inline-block');
            $('#message').addClass('bg-success');
            $('#message').fadeIn('slow');
            setTimeout(function () {
                $('#message').fadeOut('slow');
            }, 3000);
        };

        await sendRequest(urlApiSignOut, null, 'post');

        function sendRequest(url, data, method) {
            $.ajax({
                url: url,
                async: false,
                data: JSON.stringify(data),
                error: error('Đăng xuất không thành công!'),
                success: function (response) {
                    if (response.Success == true) {
                        successTrue(response.Message);                                            
                    }
                    else error('Đăng xuất không thành công!');
                },
                type: method,
                headers: { 'Content-Type': 'application/json' },
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        }
    });


    //tim kiem
    $('#input-search').keyup(function (e) {
        var input = e.target;

        var urlApiSearch = urlApi + 'Product/GetProductsBySearch';
        var data = {
            value: input.value,
            quantity: 5
        }
        sendRequest(urlApiSearch, data, 'get', true);

        function sendRequest(url, data, method, async) {
            $.ajax({
                url: url,
                async: async,
                data: data,
                error: function (response) {
                    console.log('fail');
                    $('.header .banner .search ul').html('');
                    $('.header .banner .search ul').css('display', 'none');
                },
                success: function (response) {
                    console.log(response);
                    var products = response.data
                    if (products.length == 0) {
                        $('.header .banner .search ul').html('');
                        $('.header .banner .search ul').css('display', 'none');
                    }


                    $('.header .banner .search ul').css('display', 'block');
                    $('.header .banner .search ul').html('');
                    products.forEach(function (product, index, arr) {
                        var urlImg = `${response.Url}${product.Category.Name}/${product.Brand.Name}/${product.Name}/${product.Colors[0].Img}`;
                        var name = `${product.Name} ${product.MemoryAndStorages[0].Ram}/${product.MemoryAndStorages[0].Rom} - Chính hãng`;
                        var urlProduct = `/${product.Category.UrlHandle}/${product.Brand.UrlHandle}/${product.Id}`;

                        let formatPrice = new Intl.NumberFormat('vi-VN', {
                            style: 'currency',
                            currency: 'VND',
                        });
                        new Intl.NumberFormat('en-US').format(price)

                        var price = formatPrice.format(product.SellingPrice + product.Colors[0].Price + product.MemoryAndStorages[0].Price);
                        $('.header .banner .search ul').append(
                            '<li>' +
                                '<a href="' + urlProduct +'">' +
                                    '<div class="search-item">' +
                                    '<img  src="' + urlImg +'">' +
                                        '<div class="inf">' +
                                            '<div class="name">' + name + '</div>' +
                                            '<div class="price">' + price + '</div>' +
                                        '</div>' +
                                    '</div>' +
                                '</a>' +
                            '</li>'
                        );
                    });
                },
                type: method,
                headers: { 'Content-Type': 'application/json' },
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        }
    });

    $('#btn-search').click(function () {
        var input = document.getElementById('input-search');
        if (input.value != '') {
            window.location = "/Search?key=" + input.value;
        }
    });

    //len dau trang
    $(window).scroll(function () {
        if ($(this).scrollTop() > 20) $('#back-to-top').show();
        else $('#back-to-top').hide();
    });

    $('#back-to-top').click(function () {
        $('body,html').animate({ scrollTop: 0 }, 'slow');
    });

    

    //gach chan item menu
    var itemMenuElement = document.querySelectorAll('.header .menu > ul > li');
    itemMenuElement.forEach(function (item, index) {
        item.onmouseover = function () {
            var aElement = item.querySelector('a');
            aElement.style['border-bottom'] = '2px solid #ff6801';
        };
        item.onmouseout = function () {
            var aElement = item.querySelector('a');
            aElement.style.border = 'none';
        };
    });

    //menu
    var urlApiCategory = urlApi + 'Category/GetAllCategories';

    $.get(urlApiCategory, function (data, status) {
        for (var key in data) {
            var category = data[key];
            var lengthBrand = Object.keys(category.Brands).length;

            if (category.Name == "ĐIỆN THOẠI" && lengthBrand > 0) {
                $('#dien-thoai-di-dong').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];

                    $('#dien-thoai-di-dong .sub-menu ul').append(
                        '<li>' +
                            '<a href="/dien-thoai/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "LAPTOP" && lengthBrand > 0) {
                $('#laptop').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#laptop .sub-menu ul').append(
                        '<li>' +
                            '<a href="/laptop/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "ĐỒNG HỒ" && lengthBrand > 0) {
                $('#dong-ho').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#dong-ho .sub-menu ul').append(
                        '<li>' +
                            '<a href="/dong-ho/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "SMART TV" && lengthBrand > 0) {
                $('#smart-tv').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#smart-tv .sub-menu ul').append(
                        '<li>' +
                            '<a href="/smart-tv/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "SMART HOME" && lengthBrand > 0) {
                $('#smart-home').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#smart-home .sub-menu ul').append(
                        '<li>' +
                            '<a href="/smart-home/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "TABLET" && lengthBrand > 0) {
                $('#tablet').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#tablet .sub-menu ul').append(
                        '<li>' +
                            '<a href="/tablet/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "PHỤ KIỆN" && lengthBrand > 0) {
                $('#phu-kien').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#phu-kien .sub-menu ul').append(
                        '<li>' +
                            '<a href="/phu-kien/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "THẺ SIM" && lengthBrand > 0) {
                $('#the-sim').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#the-sim .sub-menu ul').append(
                        '<li>' +
                            '<a href="/the-sim/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "ÂM THANH" && lengthBrand > 0) {
                $('#am-thanh').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#am-thanh .sub-menu ul').append(
                        '<li>' +
                            '<a href="/am-thanh/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
            if (category.Name == "ĐỒ CHƠI CN" && lengthBrand > 0) {
                $('#do-choi-cn').append(
                    '<div class="sub-menu">' +
                        '<ul>' +
                        '</ul>' +
                    '</div>'
                );
                for (var keyBrand in category.Brands) {
                    var brand = category.Brands[keyBrand];
                    $('#do-choi-cn .sub-menu ul').append(
                        '<li>' +
                            '<a href="/do-choi-cn/' + brand.UrlHandle +'">' + brand.Name + '</a>' +
                        '</li>'
                    );
                }
            }
        }
    }, "json");
});