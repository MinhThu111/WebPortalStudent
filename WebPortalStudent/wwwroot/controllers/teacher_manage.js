
$(document).ready(function () {

    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })
});

//Show panel when done
function ShowPanelWhenDone(html) {
    $(window).scrollTop();
    $('#div_view_panel').html(html);
    ShowHidePanel("#div_view_panel", "#div_main_table");
}

//Reset form
function ResetForm(formElm) {
    $(formElm).trigger('reset');
    RemoveClassValidate(formElm);
}

//Show add modal
function ShowAddModal(elm) {
    let text = $(elm).html();
    $(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
    $.get(`/Teacher/P_View`).done(function (response) {
        if (response.result === 0 || response.result === -1) {
            CheckResponseIsSuccess(response); return false;
        }
        console.log(response);
        ShowPanelWhenDone(response);
       
    }).fail(function (err) {
        $(elm).attr('disabled', false); $(elm).html(text);
        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
    });
}

