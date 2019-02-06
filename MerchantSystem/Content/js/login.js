$(function () {
    $("#btnLogin").on("click", function () {
        $(this).attr("disabled", "disabled");
        $("#form").submit();
    });
});