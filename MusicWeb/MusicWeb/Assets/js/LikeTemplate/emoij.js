$(document).ready(function(){
    $("#btn-like").click(function(){
        $("#emoij").hide();
        var des = $("#btn-like").html();
        var position = des.indexOf('span'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(32, 120, 244)");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> <span>Thích</span>");
        }
        else { //Nếu tìm thấy
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#emoij-area").mouseleave(function() {
        setTimeout(function(){ $("#emoij").hide(); }, 1500);
    });

    $("#btn-like").mouseenter(function(){
        var myVar = setTimeout(function(){ $("#emoij").show(); }, 700);
        $("#btn-like").click(function() {
            clearTimeout(myVar);
        });
        $("#btn-like").mouseleave(function() {
            clearTimeout(myVar);
        });
    });

    $("img").click(function(){
        $("#emoij").hide();
    });

    $("#like").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('<span>Thích</span>'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(32, 120, 244)");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> <span>Thích</span> ");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#haha").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('haha'); //Tìm trong chuỗi từ khóa span
        // $("#btn-like").css("color", "rgb(247, 177, 37)");
        // $("#btn-like").html("<img id='haha' src='haha.png'> <span>Haha</span>");
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(247, 177, 37)");
            $("#btn-like").html("<img id='haha' src='/Assets/images/LikeIcon/haha.png'> <span>Haha</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#heart").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('Yêu'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(243, 62, 88)");
            $("#btn-like").html("<img id='heart' src='/Assets/images/LikeIcon/heart.png'> <span>Yêu thích</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
        
    });

    $("#love").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('Thương'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(247, 177, 37)");
            $("#btn-like").html("<img id='love' src='/Assets/images/LikeIcon/love.png'> <span>Thương thương</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#wow").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('Wow'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(247, 177, 37)");
            $("#btn-like").html("<img id='wow' src='/Assets/images/LikeIcon/wow.png'> <span>Wow</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#sad").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('Buồn'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(247, 177, 37)");
            $("#btn-like").html("<img id='sad' src='/Assets/images/LikeIcon/sad.png'> <span>Buồn</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });

    $("#angry").click(function(){
        var des = $("#btn-like").html();
        var position = des.indexOf('Phẫn'); //Tìm trong chuỗi từ khóa span
        if(position == -1) { //Nếu không tìm thấy
            $("#btn-like").css("color", "rgb(233, 113, 15)");
            $("#btn-like").html("<img id='angry' src='/Assets/images/LikeIcon/angry.png'> <span>Phẫn nộ</span>");
        }
        else {
            $("#btn-like").css("color", "gray");
            $("#btn-like").html("<i class='far fa-thumbs-up' style='font-size:17px'></i> Thích");
        }
    });


});



function AddTrangThai(x) {
    var tt = 'thích';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });
}


$("#like").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'thích';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
           
        },
        error() {
            alert('Lỗi');
        }
    });
});

$("#haha").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'haha';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });
});

$("#heart").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'yêu';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });

});

$("#love").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'thương';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });
});

$("#wow").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'wow';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });
});

$("#sad").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'buồn';
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
            
        },
        error() {
            alert('Lỗi');
        }
    });
});

$("#angry").click(function () {
    var id = window.location.search.split('?id=');
    var x = id[1];
    var tt = 'phẫn'
    $.ajax({
        url: '/BaiHatController/AddTrangThaiBaiHat',
        type: 'GET',
        dataType: 'json',
        data: { id: x, tt: tt },
        success: function (rs) {
           
        },
        error() {
            alert('Lỗi');
        }
    });
});

