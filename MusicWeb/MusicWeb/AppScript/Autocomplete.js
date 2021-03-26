function Search() {
    document.getElementById('formSearch').submit();
}


$("#txtSerach").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/BaiHatController/Search",
            dataType: "json",
            data: {
                term: request.term
            },
            success: function (rs) {
                response(rs.data);
            }
        });
    },
    focus: function (event, ui) {
        $("#txtSerach").val(ui.item.label);
        return false;
    },
    select: function (event, ui) {
        $("#txtSerach").val(ui.item.label);
        return false;
    }
});
