
    $(document).ready(function () {
            var location = window.location.pathname;
        $("a[href='" + location + "']").addClass("active");
     
    });

var x = 1;
function ReadMore() {
    if (x == 1) {
        x = 2;
        $('.hide-text').show();
        $('.about_artist a').text('Thu gọn');
    } else {
        x = 1;
        $('.hide-text').hide();
        $('.about_artist a').text('Xem thêm');
    }
}

   
