var userdk = document.getElementById('userdk');
var passdk = document.getElementById('passdk');
var repassdk = document.getElementById('repassdk');
var emaildk = document.getElementById('emaildk');
var flag = true;
function DangKy() {
    if (userdk.value == "") {
        $('#text-error-userdk').text("Vui lòng nhập tài khoản của bạn");
        return false;
    } else {
        $('#text-error-userdk').text("");
    }

    if (passdk.value == "") {
        $('#text-error-passdk').text("Vui lòng nhập mật khẩu");
        return false;
    } else {
        $('#text-error-passdk').text("");
    }

    if (passdk.value.length < 5) {
        $('#text-error-passdk').text("Mật khẩu phải lớn hơn 5 ký tự");
        return false;
    } else {
        $('#text-error-passdk').text("");
    }

    if (emaildk.value == "") {
        $('#text-error-emaildk').text("Vui lòng nhập email");
        return false;
    } else {
        $('#text-error-emaildk').text("");
    }

    var atposition = emaildk.value.indexOf("@");
    var dotposition = emaildk.value .lastIndexOf(".");
    if (atposition < 1 || dotposition < (atposition + 2)
        || (dotposition + 2) >= x.length) {
        $('#text-error-emaildk').text("Địa chỉ email không chính xác");
        return false;
    }

if (repassdk.value == "") {
    $('#text-error-dk').text("Vui lòng nhập lại mật khẩu");
    return false;
} else {
    $('#text-error-dk').text("");
}

if (passdk.value != repassdk.value) {
    $('#text-error-dk').text("Mật khẩu nhập lại không đúng");
    return false;
} else {
    $('#text-error-dk').text("");
}

$.ajax({
    url: "/NguoiDung/ListTaiKhoan",
    type: "GET",
    dataType: "json",
    cache: false,
    success: function (rs) {
        $.each(rs, function (index, values) {
            if (emaildk.value == values.Email) {
                $('#text-error-dk').text('Email đã tồn tại');
                flag = false;
                return false;
            }
            else {
                $('#text-error-dk').text('');
                flag = true;
            }
        });
        if (flag == true) {
            document.getElementById('DangKySubmit').submit();
        }
        else {
            return false;
        }      
    },
    error: function () {

    }
});
}

var sd = true;
var user = document.getElementById('user');
var pass = document.getElementById('pass');
function Login() {
    if (user.value == "") {
        $('#text-error-user').text("Vui lòng nhập tài khoản của bạn");
        return false;
    } else {
        $('#text-error-user').text("");
    }
    if (pass.value == "") {
        $('#text-error-pass').text("Vui lòng nhập mật khẩu");
        return false;
    } else {
        $('#text-error-pass').text("");
    }

    $.ajax({
        url: '/NguoiDung/ListTaiKhoan',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (rs) {
            $.each(rs, function (index, values) {
                if (user.value == values.Email && pass.value == values.MatKhau) {
                    sd = true;
                    $('#text-error').text('');
                    return false;
                } else {
                    $('#text-error').text('Tài khoản hoặc mật khẩu không đúng');
                    sd = false;                   
                }
            });

            if (sd == false) {
                return false;
            } else {
                document.getElementById('LoginSubmit').submit();
            }
        },
        error: function () {

        }
    });

}