/// <reference path="../lib/jquery-v3.3.1.dev.js" />

$(function () {
    let $ddlMerchantStatus = $("#ddlMerchantStatus"),
        $txtKeyword = $("#txtKeyword"),
        $btnSearch = $("#btnSearch");

    $("#lv").on("click", 'a[data-active-no]', function () {
        let $this = $(this);
        let merchantNo = $this.attr("data-active-no");
        $this.addClass("mer-activing").attr("title", "正在激活...").html('');
        $.ajax({
            url: '/merchant/active',
            method: 'POST',
            data: {
                merchantNo: merchantNo
            },
            success: function (data) {
                $this.removeClass("mer-activing").removeAttr("title").html("激活");
                if (data) {
                    if (data.error) {
                        showErrorNotice("激活失败：" + data.error);
                        return;
                    }
                    showSuccessNotice("激活成功：" + merchantNo);
                    $this.parentsUntil('tr').parent().find('td:eq(3) span').removeClass('mer-status-waitforactive').addClass('mer-status-normal').html('正常');
                    $this.remove();
                } else {
                    showErrorNotice("激活失败：远程未返回任何数据");
                }
            },
            error: function (a, b, c) {
                $this.removeClass("mer-activing").removeAttr("title").html("激活");
                showErrorNotice("激活失败：" + c);
            }
        });
    });

    $ddlMerchantStatus.on("change", function () {
        q();
    });

    $txtKeyword.on("keyup", function (e) {
        if (e.keyCode == 13) {
            q();
        }
    });

    $btnSearch.on("click", function () {
        q();
    });

    function showErrorNotice(msg) {
        new jBox('Notice', {
            theme: 'NoticeFancy',
            attributes: {
                x: 'right',
                y: 'top'
            },
            color: 'red',
            content: msg,
            animation: { open: 'slide:right', close: 'slide:left' }
        });
    }

    function showSuccessNotice(msg) {
        new jBox('Notice', {
            theme: 'NoticeFancy',
            attributes: {
                x: 'right',
                y: 'top'
            },
            color: 'green',
            content: msg,
            animation: { open: 'slide:right', close: 'slide:left' }
        });
    }

    function q() {
        let status = $.trim($ddlMerchantStatus.val()),
            keyword = $.trim($txtKeyword.val());
        var qs = '?page=1';
        if (status && status.length > 0) {
            qs += '&merchant_status=' + status;
        }
        if (keyword && keyword.length > 0) {
            qs += '&keyword=' + keyword;
        }
        location.href = '/merchant/list' + qs;
    }
});