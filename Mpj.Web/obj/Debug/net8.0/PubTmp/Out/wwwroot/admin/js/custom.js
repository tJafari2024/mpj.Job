
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

$(document).ready(function () {


    var editors = $("[ckeditor]");
    //editors.editorConfig = function (config) {
    //    // Define changes to default configuration here. For example:
    //    // config.uiColor = '#AADC6E';
    //    config.contentsLangDirection = 'rtl';
    //    config.language = 'fa';
    //    config.filebrowserImageUploadUrl = '/file-upload';
    //    config.toolbar = 'MyToolbar';

    //    config.toolbar_MyToolbar =
    //    [
    //        { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'] },
    //        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
    //        { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'] },
    //        { name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
    //        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
    //        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
    //        { name: 'colors', items: ['TextColor', 'BGColor'] },
    //        '/',
    //        { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
    //        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
    //        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] }

    //    ];
    //};
    if (editors.length > 0) {

        $.getScript('/js/ckeditor.js', function () {
            $(editors).each(function (index, value) {
                var id = $(value).attr('ckeditor');
                ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                    {
                        // plugins: [HtmlEmbed ],
                        //toolbar: ['htmlEmbed' ],
                        toolbar: {
                            items: [
                                'heading',
                                '|',
                                'bold',
                                'italic',
                                'link',
                                '|',
                                'fontSize',
                                'fontColor',
                                '|',
                                'imageUpload',
                                'blockQuote',
                                'insertTable',
                                'undo',
                                'redo',
                                'codeBlock'
                            ]
                        },
                        allowedContent: true,
                        language: 'fa',
                        enenterMode: 'CKEDITOR.ENTER_BR',
                        // enterMode: editors.ENTER_BR,
                        table: {
                            contentToolbar: [
                                'tableColumn',
                                'tableRow',
                                'mergeTableCells'
                            ]
                        },
                        licenseKey: '',
                        simpleUpload: {
                            // The URL that the images are uploaded to.
                            uploadUrl: '/Uploader/UploadImage'
                        }

                    })
                    .then(editor => {
                        window.editor = editor;
                    }).catch(err => {
                        console.error(err);
                    });
            });
        });
    }

    $("#Title").val($("#PublicInfoId option:selected").text());

});


function FillPageId(pageId) {

   // alert(pageId);
    $("#PageId").val(pageId);
    $("#filter-form").submit();
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
                        if($(this).attr('ajax-url-refresh') === '1')
                        window.location.reload();
                    }
                }
            });
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('اعلام', 'عملیات لغو شد', 'error');
        }
    });
});

$('[ajax-url-button-post]').on('click', function (e) {

    e.preventDefault();//توقف حالت پیش فرض 
    var url = $(this).attr('href');

    var itemId = $(this).attr('ajax-url-button-post');
    // alert(url + ' ' + itemId)
    swal({
        title: 'اخطار',
        text: "آیا از انجام عملیات مورد نظر اطمینان دارید؟",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((result) => {

        if (result.value) {

            $.post(url).then(result => {  //  $.post(url).then(result => {
                if (result.status === 'Success') {
                    ShowMessage('موفقیت', result.message);
                    $('#ajax-url-item-post-' + itemId).hide(1500);
                }
            });
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('اعلام', 'عملیات لغو شد', 'error');
        }
    });
});

function OnSuccessRejectItem(res) {
    if (res.status === 'Success') {
        ShowMessage('اعلان موفقیت', res.message);
        $('#ajax-url-item-' + res.data.id).hide(300);
        $('#reject-modal-' + res.data.id).modal('toggle');
        $('#reject-modal-' + res.data.id).modal().hide();
        $('.close').click();
    }
}

function deleteItem(form) {
    $(form).parents('li').remove();
}

var imageupload = new Object();
imageupload.OneImageUpload = function (inputId) {
    $("#" + inputId).fileinput({
        maxFileCount: 10,
        previewFileType: "image",
        browseClass: "btn btn-primary",
        browseLabel: "انتخاب",
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        removeClass: "btn  btn-danger",
        removeLabel: "حذف",
        maxFileSize: 10000,
        removeIcon: '<i class="glyphicon glyphicon-trash"></i>',
        uploadClass: "btn btn-success",
        uploadLabel: "ارسال به سرور",
        allowedFileExtensions: ['jpg', 'gif', 'png', 'jpeg'],
        msgInvalidFileType: "از تصاویر فقط استفاده کنید",
        msgInvalidFileExtension: "از فایل های مجاز استفاده کنید[jpg,jpeg,png,gif]",
        msgFilesTooMany: "شما قادر به ارسال 10 عدد فایل میباشید",
        msgSizeTooLarge: "شما قادر به ارسال 10 مگا بایت فایل میباشید",
        uploadIcon: '<i class="glyphicon glyphicon-upload"></i>'

    });
};
var LightBox = new Object();

LightBox.onSuccess = function () {
    $('#lightBox').modal('show');
}

$(document).on('click', 'img', function (e) {


    $('img').removeClass("borderPictureLightBox");
    var $img = $(this);
    $($img).addClass("borderPictureLightBox");
    $('#ImageName').val($img.attr('id'));
    $(".img-set").attr("src", $img.attr('id'));


});


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


showInPopup = (url, title) => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    });
}
jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {

                if (res.isValid) {

                    $('#' + res.location).html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $('#lightBox').modal('hide');

                    if (res.messageStatus === "success")
                        ShowMessage('پیغام موفقیت', res.message, res.messageStatus);
                    else
                        ShowMessage('پیغام اخطار', res.message, res.messageStatus);
                } else {
                    $('#form-modal .modal-body').html(res.html);
                    ShowMessage('پیغام خطا', "لطفا مقدار خواسته را وارد کنید", "error");
                }

            },
            error: function (err) {
                alert(err.message);
            }
        });
        //to prevent default form submit event

    }

    catch (ex) {
        alert(ex);
    }
    return false;
}

function onlyNumberKey(evt) {

    // Only ASCII character in that range allowed
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
}


$("#PublicInfoId").on('change', function (e) {
    var optionsText = this.options[this.selectedIndex].text;
    $("#Title").val(optionsText);
});

//$("#ImageTypeId").on('change', function (e) {
//    var optionsText = this.options[this.selectedIndex].value;
//    alert('n')
//    try {

//        $.ajax({
//            type: "POST",
//            url: url,
//            data: '{id: "' + id + '"}',
//            contentType: "application/json; charset=utf-8",
//            success: function (res) {


//            },
//            error: function (err) {
//                alert(err.message);
//            }
//        });


//    }

//    catch (ex) {
//        alert(ex);
//    }

//    $("#spnImageSize").html(optionsText);
//});

OnChangeTypeImage = (url) => {
    
    var optionsValue = $("#ImageTypeId option:selected").val();
   // alert(url.replace("0", optionsValue));
    try {

        $.ajax({
            type: "POST",
            url: url.replace("0", optionsValue),
            data: '{typeid: "' + optionsValue + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                $("#divimgSize").removeClass("d-none");
                $("#spnImageSize").text(res);
               

            },
            error: function (err) {
                alert(err.message);
            }
        });


    }

    catch (ex) {
        alert(ex);
    }
}


$('input:radio[name=PaymentWayId]').change(function () {
    if (this.checked) {
        if (this.value === '2')
            $('#showBankList').show();
        else if (this.value === '1')
            $('#showBankList').hide();

    }
    else if ((!this.checked) && (this.value === '2'))
        $('#showBankList').hide();
});

OnChangeCheckBox = (url, id) => {
   
    try {

        $.ajax({
            type: "POST",
            url: url,
            data: '{id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (res) {


            },
            error: function (err) {
                alert(err.message);
            }
        });


    }

    catch (ex) {
        alert(ex);
    }
}
