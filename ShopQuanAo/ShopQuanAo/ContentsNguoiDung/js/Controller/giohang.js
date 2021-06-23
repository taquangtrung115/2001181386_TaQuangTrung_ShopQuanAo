var giohang = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#muatiep').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#thanhtoan').off('click').on('click', function () {
            window.location.href = "/ThanhToan";
        });
        $('#capnhat').off('click').on('click', function () {
            var listProduct = $('.txttrangthai');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('MaSP')
                    }
                });
            });

            $.ajax({
                url: '/GioHang/CapNhat',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Index";
                    }
                }
            })
        });

        $('#xoa').off('click').on('click', function () {


            $.ajax({
                url: '/GioHang/XoaTatCa',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Index";
                    }
                }
            })
        });

        $('.btn-xoa').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('MaSP') },
                url: '/GioHang/Xoa',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Index";
                    }
                }
            })
        });
    }
}
giohang.init();