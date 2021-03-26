//Add Bai Hat
function AddBaiHatFavorit(x) {
    $.ajax({
        url: "/BaiHatController/AddBaiHatYeuThich?id=" + x,
        type: "GET",
        dataType: 'json',
        cache: false,
        success: function (rs) {
            if(rs != 'error')
                Notification("success", "Bài hát đã được thêm vào mục yêu thích");
            else
                Notification("warning", "Bài hát đã xóa khỏi mục yêu thích");
        },
        error() {
            alert('Lỗi');
        }
    });
}
//List Bài Hát Yêu Thích
$.ajax({
    url: '/NguoiDung/ListBaiHatYeuThich',
    type: 'GET',
    dataType: 'json',
    cache: false,
    success: function (rs) {
        if (rs != "") {
            var dsbh = '';
            $.each(rs, function (index, values) {

                dsbh += '<div style="width: 170px; padding: 0px 10px;display: inline-block" class="ms_rcnt_box">' +
                    '<div class="ms_rcnt_box_img">' +
                    '<img src="/Assets/images/ImagesOutSource/ImagesSong/' + values.AnhBaiHat + '">' +
                    '<div class="ms_main_overlay">' +
                    '<div class="ms_box_overlay"></div>' +
                    '<div class="ms_more_icon">' +
                    '<img src="/Assets/images/svg/more.svg">' +
                    '</div>' +
                    '<ul style="right: 9px" class="more_option">' +
                    '<li><a href="#"><span class="opt_icon"><span class="icon icon_fav"></span></span>Add To Favourites</a></li>' +
                    '<li><a onclick="AddQueue(' + values.IdBaiHat + ')" href="javascript:0"><span class="opt_icon"><span class="icon icon_queue"></span></span>Add To Queue</a></li>' +
                    '<li><a href="/Home/Dowload?id=' + values.IdBaiHat + '"><span class="opt_icon"><span class="icon icon_dwn"></span></span>Download Now</a></li>' +
                    '<li>' +
                    '<div class="fb-share-button fb_iframe_widget" data-href="https://zingmp3.vn/bai-hat/Hoa-Hai-Duong-Jack/ZWDAAU8Z.html" data-layout="button_count" data-size="small" fb-xfbml-state="rendered" fb-iframe-plugin-query="app_id=&amp;container_width=123&amp;href=https%3A%2F%2Fzingmp3.vn%2Fbai-hat%2FHoa-Hai-Duong-Jack%2FZWDAAU8Z.html&amp;layout=button_count&amp;locale=vi_VN&amp;sdk=joey&amp;size=small"><span style="vertical-align: bottom; width: 99px; height: 20px;"><iframe name="f2ce63e12fc8a0c" width="1000px" height="1000px" data-testid="fb:share_button Facebook Social Plugin" title="fb:share_button Facebook Social Plugin" frameborder="0" allowtransparency="true" allowfullscreen="true" scrolling="no" allow="encrypted-media" src="https://www.facebook.com/v8.0/plugins/share_button.php?app_id=&amp;channel=https%3A%2F%2Fstaticxx.facebook.com%2Fx%2Fconnect%2Fxd_arbiter%2F%3Fversion%3D46%23cb%3Df23f534d05822c4%26domain%3Dlocalhost%26origin%3Dhttps%253A%252F%252Flocalhost%253A44374%252Ff7f986a001d584%26relation%3Dparent.parent&amp;container_width=123&amp;href=https%3A%2F%2Fzingmp3.vn%2Fbai-hat%2FHoa-Hai-Duong-Jack%2FZWDAAU8Z.html&amp;layout=button_count&amp;locale=vi_VN&amp;sdk=joey&amp;size=small" style="border: none; visibility: visible; width: 99px; height: 20px;" class=""></iframe></span></div>' +
                    '</li>' +
                    '</ul>' +

                    '<div class="ms_play_icon ' + values.IdBaiHat + '">' +
                    '<img src="/Assets/images/svg/play.svg">' +
                    '</div>' +

                    '</div>' +
                    '</div>' +
                    '<div style="margin: 0px;" class="ms_rcnt_box_text">' +
                    '<h3 style="margin: 0px;padding: 10px 0px"><a href="/BaiHatController/ChiTietBaiHat?id=' + values.IdBaiHat + '">' + values.TenBaiHat + '</a></h3>' +
                    '</div>' +
                    '</div>';
            });
            $('.BaiHatYeuThich').html(dsbh);
        }

    },
    error() {

    }
});
//Add Mv
function AddMv(x) {
    $.ajax({
        url: "/NguoiDung/AddVideoYeuThich?id=" + x,
        type: "GET",
        dataType: 'json',
        cache: false,
        success: function (rs) {
            if (rs == 'delete') {
                Notification("warning", "Đã xóa MV khỏi mục yêu thích");
            } else {
                Notification("success", "MV đã được thêm vào mục yêu thích");
            }
        },
        error() {
            alert('Lỗi');
        }
    });
}
//List Mv Yêu Thích
$.ajax({
    url: '/NguoiDung/ListVideoYeuThich',
    type: 'GET',
    dataType: 'json',
    cache: false,
    success: function (rs) {
        if (rs != "") {
            var dsbh = '';
            $.each(rs, function (index, values) {

                dsbh += '<div style="width: 170px; padding: 0px 10px;display: inline-block" class="ms_rcnt_box">' +
                    '<div class="ms_rcnt_box_img">' +
                    '<img src="/Assets/images/PosterVideo/' + values.Poster + '">' +
                    '<div class="ms_main_overlay">' +
                    '<div class="ms_box_overlay"></div>' +
                    '<div class="ms_play_icon">' +
                    '<a href="/Video/PlayVideo?id=' + values.IdVideo + '"><img src="/Assets/images/svg/play.svg"></a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div style="margin: 0px;" class="ms_rcnt_box_text">' +
                    '<h3 style="margin: 0px;padding: 10px 0px"><a href="/Video/PlayVideo?id=' + values.IdVideo + '">' + values.TieuDe + '</a></h3>' +
                    '</div>' +
                    '</div>';
            });
            $('.MVYeuThich').html(dsbh);
        }

    },
    error() {

    }
});
//Add Nghệ sĩ
function AddNgheSiYeuThich(x) {
    $.ajax({
        url: "/NguoiDung/AddNgheSiYeuThich?id=" + x,
        type: "GET",
        dataType: 'json',
        cache: false,
        success: function (rs) {
            if (rs != 'error')
                Notification("success", "Nghệ Sĩ đã được thêm vào mục yêu thích");
            else
                Notification("warning", "Nghệ Sĩ đã xóa khỏi mục yêu thích");
        },
        error() {
            alert('Lỗi');
        }
    });
}

//List nghệ sĩ yêu thích

$.ajax({
    url: '/NguoiDung/ListNgheSiYeuThich',
    type: 'GET',
    dataType: 'json',
    cache: false,
    success: function (rs) {
        if (rs != "") {
            var dsbh = '';
            $.each(rs, function (index, values) {

                dsbh += '<div style="width: 170px; padding: 0px 10px;display: inline-block" class="ms_rcnt_box">' +
                    '<div class="ms_rcnt_box_img">' +
                    '<img src="/Assets/images/ImagesOutSource/ImagesSing/' + values.AnhNgheSi + '">' +
                    '<div class="ms_main_overlay">' +
                    '<div class="ms_box_overlay"></div>' +
                    '</div>' +
                    '</div>' +
                    '<div style="margin: 0px;" class="ms_rcnt_box_text">' +
                    '<h3 style="margin: 0px;padding: 10px 0px"><a href="/ThongTinNgheSi/ThongTin?idNgheSi=' + values.IdNgheSi + '">' + values.TenNgheSi + '</a></h3>' +
                    '</div>' +
                    '</div>';
            });
            $('.NgheSiYeuThich').html(dsbh);
        }

    },
    error() {

    }
});