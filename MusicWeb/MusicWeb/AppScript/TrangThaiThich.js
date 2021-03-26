$.ajax({
    url: '/NguoiDung/ListBaiHatYeuThich',
    type: 'GET',
    dataType: 'json',
    cache: false,
    success: function (rs) {
        var id = window.location.search.split('?id=');

        $.each(rs, function (index, values) {
            if (values.IdBaiHat == id[1]) {
                if (values.TrangThaiThich == 'thích') {
                    $("#btn-like").css("color", "rgb(32, 120, 244)");
                    $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
                }
                if (values.TrangThaiThich == 'phẫn') {
                    $("#btn-like").css("color", "rgb(233, 113, 15)");
                    $("#btn-like").html("<img id='angry' src='/Assets/images/LikeIcon/angry.png'> <span>Phẫn nộ</span>");
                }
                if (values.TrangThaiThich == 'haha') {
                    $("#btn-like").css("color", "rgb(247, 177, 37)");
                    $("#btn-like").html("<img id='haha' src='/Assets/images/LikeIcon/haha.png'> <span>Haha</span>");
                }
                if (values.TrangThaiThich == 'yêu') {
                    $("#btn-like").css("color", "rgb(243, 62, 88)");
                    $("#btn-like").html("<img id='heart' src='/Assets/images/LikeIcon/heart.png'> <span>Yêu thích</span>");
                }
                if (values.TrangThaiThich == 'thương') {
                    $("#btn-like").css("color", "rgb(247, 177, 37)");
                    $("#btn-like").html("<img id='love' src='/Assets/images/LikeIcon/love.png'> <span>Thương thương</span>");
                }
                if (values.TrangThaiThich == 'wow') {
                    $("#btn-like").css("color", "rgb(247, 177, 37)");
                    $("#btn-like").html("<img id='wow' src='/Assets/images/LikeIcon/wow.png'> <span>Wow</span>");
                }
                if (values.TrangThaiThich == 'buồn') {
                    $("#btn-like").css("color", "rgb(247, 177, 37)");
                    $("#btn-like").html("<img id='sad' src='/Assets/images/LikeIcon/sad.png'> <span>Buồn</span>");
                }
            }
        });
    },
    error() {

    }
});