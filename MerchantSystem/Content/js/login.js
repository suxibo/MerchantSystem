$(function () {
    $("#btnLogin").on("click", function () {
        let uname = $.trim($('input[name=UserName]').val());
        let pass = $.trim($('input[name=Password]').val());
        if (uname.length == 0 || pass.length == 0) {
            $.alert("用户名和密码不可为空");
            return;
        }
        $("#form").submit();
    });
});