$(function () {
    let $form = $("#merchantEditForm");
    $form.on("click", '#showMore', function () {
        let $a = $(this);
        let state = $a.attr("data-state");
        if (state == "close") {
            $form.find('table tr[data-optional]').fadeIn(200);
            $a.attr("data-state", "open").html('隐藏选填项');
        } else {
            $form.find('table tr[data-optional]').fadeOut(200);
            $a.attr("data-state", "close").html('显示选填项');
        }
    }).on("click", '#btnSubmit', function () {
        $(this).attr("disabled", "disabled");
        $("#form").submit();
    });
});