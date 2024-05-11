function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-bottom-right',
        showDuration: 4000,
        theme: theme !== '' ? theme : 'success'
    })({
        title: title !== '' ? title : 'اعلان',
        message: decodeURI(text)
    });
 
}


function FillPageId(pageId) {
    $('#PageId').val(pageId);
    $('#filter-form').submit();
}

function onlyNumberKey(evt) {
    // Only ASCII character in that range allowed
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode;
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
}

$('[ajax-url-button]').on('click', function (e) {

    e.preventDefault();//توقف حالت پیش فرض 
    var url = $(this).attr('href');

    var textmessage = 'آیا از انجام عملیات مورد نظر اطمینان دارید؟';
    if ($(this).attr('ajax-url-allremove') !== 'undefined') {
        if ($(this).attr('ajax-url-allremove') === '1')
            textmessage = 'آیا از انجام عملیات مورد نظر اطمینان دارید؟ باحذف سرشاخه تمام زیرشاخه ها هم حذف می شوند.';
    }
    var itemId = $(this).attr('ajax-url-button');

    swal({
        title: 'اخطار',
        text: textmessage,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((result) => {

        if (result.value) {
            $.get(url).then(result => {  //  $.post(url).then(result => {
                if (result.status === 'Success') {
                    ShowMessage('موفقیت', result.message);
                    $('#ajax-url-item-' + itemId).hide(1500);
                    if ($(this).attr('ajax-url-refresh') !== 'undefined') {
                        if ($(this).attr('ajax-url-refresh') === '1')
                            window.location.reload();
                    }
                }
            });
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('اعلام', 'عملیات لغو شد', 'error');
        }
    });
});

function open_waiting(selector = 'body') {
    $(selector).waitMe({
        effect: 'ios',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255,255,255,0.7)',
        color: '#000'
    });
}
function close_waiting(selector = 'body') {
    $(selector).waitMe('hide');
}
$(function () {

    $("#loaderBody2").addClass('hide');

    $(document).bind('ajaxStart',
        function () {
            $("#loaderBody2").removeClass('hide');
        }).bind('ajaxStop',
            function () {
                $("#loaderBody2").addClass('hide');
            });
});


function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}
var imageupload = new Object();
imageupload.OneImageUpload = function (inputId) {
    $("#" + inputId).fileinput({
        maxFileCount: 1,
        previewFileType: "image",
        browseClass: "btn btn-primary",
        browseLabel: "انتخاب عکس",
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        removeClass: "btn  btn-danger",
        removeLabel: "حذف",
        maxFileSize: 1000,
        removeIcon: '<i class="glyphicon glyphicon-trash"></i>',
        uploadClass: "btn btn-dark",
        uploadLabel: "آپلود عکس پرسنلی",
        allowedFileExtensions: ['jpg', 'gif', 'png', 'jpeg'],
        msgInvalidFileType: "از تصاویر فقط استفاده کنید",
        msgInvalidFileExtension: "از فایل های مجاز استفاده کنید[jpg,jpeg,png,gif]",
        msgFilesTooMany: "شما قادر به ارسال 10 عدد فایل میباشید",
        msgSizeTooLarge: "شما قادر به ارسال 1 مگابایت فایل میباشید",
        uploadIcon: '<i class="glyphicon glyphicon-upload"></i>'

    });
};

var imagePdfupload = new Object();
imagePdfupload.OneImageUpload = function (inputId) {
    $("#" + inputId).fileinput({
        maxFileCount: 1,
        previewFileType: "image",
        browseClass: "btn btn-primary",
        browseLabel: "انتخاب عکس",
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        removeClass: "btn  btn-danger",
        removeLabel: "حذف",
        maxFileSize: 1000,
        removeIcon: '<i class="glyphicon glyphicon-trash"></i>',
        uploadClass: "btn btn-dark",
        uploadLabel: "آپلود عکس پرسنلی",
        allowedFileExtensions: ['jpg', 'gif', 'png', 'jpeg'],
        msgInvalidFileType: "از تصاویر فقط استفاده کنید",
        msgInvalidFileExtension: "از فایل های مجاز استفاده کنید[jpg,jpeg,png,gif,pdf]",
        msgFilesTooMany: "شما قادر به ارسال 10 عدد فایل میباشید",
        msgSizeTooLarge: "شما قادر به ارسال 1 مگابایت فایل میباشید",
        uploadIcon: '<i class="glyphicon glyphicon-upload"></i>'

    });
};

var fileupload = new Object();
fileupload.OneFileUpload = function (inputId) {
    $("#" + inputId).fileinput({
        maxFileCount: 1,
        previewFileType: "application/pdf",
        browseClass: "btn btn-primary",
        browseLabel: "آپلود فایل رزومه",
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        removeClass: "btn  btn-danger",
        removeLabel: "حذف",
        maxFileSize: 10000,
        removeIcon: '<i class="glyphicon glyphicon-trash"></i>',
       // uploadClass: "btn btn-success",
       // uploadLabel: "ارسال به سرور",
        allowedFileExtensions: ['pdf'],
        msgInvalidFileType: "از فایل pdf فقط استفاده کنید",
        msgInvalidFileExtension: "از فایل های مجاز استفاده کنید[pdf]",
        msgFilesTooMany: "شما قادر به ارسال 1 عدد فایل میباشید",
        msgSizeTooLarge: "شما قادر به ارسال 10 مگابایت فایل میباشید",
        uploadIcon: '<i class="glyphicon glyphicon-upload"></i>'

    });
};


function GetCitys (event) {
    
    var vm = this;
    vm.Citys = [];
    $.ajax({
        url: "/Home/GetCity/" + event,
        method: "GET",
    }).done(function (data) {
       // var select = document.getElementById('SpecificationsDto.CityId');
       // alert(data.length + ' ' + select.length)
        //vm.Citys = data;
    }).fail(function () {
    });
}
