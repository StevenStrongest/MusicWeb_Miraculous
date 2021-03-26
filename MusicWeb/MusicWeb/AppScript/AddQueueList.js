


$.ajax({
    url: '/DanhSachPhat/Index',
    type: 'GET',
    dataType: 'json',
    cache: false,
    success: function (rs) {
        var dsbh = '';
        $.each(rs, function (index, values) {

            dsbh += '<li class="id' + values.BaiHat.IdBaiHat + '">' +
                '<div class="jp-track-name">' +
                '<span class="que_img">' +
                '<img style="width: 100%" src="/Assets/images/ImagesOutSource/ImagesSong/' + values.BaiHat.AnhBaiHat + '" />' +
                '</span >' +
                '<div style="cursor: pointer" class="que_data ' + values.BaiHat.IdBaiHat + '">' +
                values.BaiHat.TenBaiHat +
                '<div class="jp-artist-name"></div>' + '</div>' +
                '</div>' +
                '<div class="action">' + 
                '<span onclick="RemoveQueue(' + values.BaiHat.IdBaiHat+')" class="que_close"><img src="/Assets/images/svg/close.svg"></span>' +
                    '</div>' +
                '</li>';
        });
        $('#list-queue').html(dsbh);
    },
    error() {
        alert('Lỗi');
    }
});


function AddQueue(x) {
    $.ajax({
        url: '/DanhSachPhat/AddDanhSachPhat?id=' + x,
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (rs) {
            location.reload();
        },
        error() {
            alert('Lỗi');
        }
    });
}

function RemoveQueue(x) {
    $.ajax({
        url: '/DanhSachPhat/RemoveQueue?id=' + x,
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (rs) {
            $('li.id'+x).remove();
        },
        error() {
            alert('Lỗi');
        }
    });
}









