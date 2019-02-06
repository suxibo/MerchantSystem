$(function () {
    $("#btnLogin").on("click", function () {
        $(this).attr("disabled", "disabled");
        $("#form").submit();
    });
    $('input[name="Password"]').on("keyup", function (e) {
        if (e.keyCode == 13) {
            $("#btnLogin").click();
        }
    });
});