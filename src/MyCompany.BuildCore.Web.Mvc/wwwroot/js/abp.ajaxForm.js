(function (abp, $) {
    function bindAjax() {

        $('.ajax-form').each(function () {

            var l = abp.localization.getSource('CMS');

            var _$this = $(this);

            if (_$this.is('form')) {
                _$this.submit(function (e) {

                    e.preventDefault();

                    _$this.find('.is-invalid').removeClass('is-invalid');
                    _$this.find('span[class="error invalid-feedback"]').remove();

                    var formId = _$this.attr('id');
                    var frmFormElement = document.getElementById(formId);

                    var fdata = new FormData(frmFormElement);
                    
                    var _$blockPlaceHolder = _$this;
                    var ajaxBlockPlaceHolder = _$this.data('ajax-block-placeholder');
                    if (ajaxBlockPlaceHolder != null && ajaxBlockPlaceHolder != undefined && ajaxBlockPlaceHolder != '') {
                        _$blockPlaceHolder = $(ajaxBlockPlaceHolder);
                    }

                    abp.ui.setBusy(_$blockPlaceHolder);
                    abp.ajax({
                        url: abp.appPath + _$this.attr('action'),
                        type: _$this.attr('method'),
                        data: fdata,
                        contentType: false,
                        processData: false,
                        cache: false,
                        success: function (result) {
                            if (result && result.errors && result.errors.length > 0) {
                                $.each(result.errors, function () {
                                    var inputElement = _$this.find('[name="' + this.key + '"]');
                                    if (inputElement != null && inputElement != undefined && inputElement.length > 0) {
                                        var insertErrorAfter = inputElement.data('insert-error-after');
                                        if (insertErrorAfter == null || insertErrorAfter == undefined || insertErrorAfter == '') {
                                            if (!inputElement.is(':visible') || (inputElement.is('select') && (inputElement.hasClass('selectpicker') || inputElement.hasClass('select2-message-error')))) {
                                                $.each(this.messages, function () {
                                                    $('<span data-errorfor="' + inputElement.attr('id') + '" class="error invalid-feedback">' + this + '</span>').insertAfter(inputElement.parent()).show();
                                                });
                                            }
                                            else {
                                                inputElement.addClass('is-invalid');
                                                $.each(this.messages, function () {
                                                    $('<span data-errorfor="' + inputElement.attr('id') + '" class="error invalid-feedback">' + this + '</span>').insertAfter(inputElement);
                                                });
                                            }
                                        }
                                        else {
                                            $.each(this.messages, function () {
                                                $('<span data-errorfor="' + inputElement.attr('id') + '" class="error invalid-feedback">' + this + '</span>').insertAfter($('#' + insertErrorAfter)).show();
                                            });
                                        }
                                    }
                                    else {
                                        $.each(this.messages, function () {
                                            abp.notify.error(this);
                                        });
                                    }
                                });
                            }
                            else if (result && result.resultHtml) {
                                var ajaxPlaceholder = _$this.data('ajax-placeholder');
                                if (ajaxPlaceholder != null && ajaxPlaceholder != undefined && ajaxPlaceholder != '') {
                                    $(ajaxPlaceholder).html(result.resultHtml);
                                }
                                if (_$this.hasClass('dirty-form-checked')) {
                                    $("#" + formId).dirty("setAsClean")
                                }
                                abp.event.trigger(formId + '.submitted.success', null);
                            }
                            else {
                                var successMessage = l('SavedSuccessfully');
                                if ($('#' + formId).data('success-message') != null && $('#' + formId).data('success-message') != undefined && $('#' + formId).data('success-message') != '') {
                                    successMessage = $('#' + formId).data('success-message');
                                }
                                abp.notify.info(successMessage);
                                if (_$this.hasClass('dirty-form-checked')) {
                                    $("#" + formId).dirty("setAsClean")
                                }
                                abp.event.trigger(formId + '.submitted.success', null);
                            }
                        }
                    }).always(function () {
                        abp.ui.clearBusy(_$blockPlaceHolder);
                    });
                });
            }
        });
    }

    var ajaxForm = {
        bindAjax: bindAjax
    };

    function bindDirtyForm() {
        $('.dirty-form-checked').each(function () {
            var _$this = $(this);
            if (_$this.is('form')) {
                var formId = _$this.attr('id');
                $("#" + formId).dirty();
            }
        });
    }

    $(function () {
        bindAjax();
        abp.event.trigger('ajax-form-binded', null);
        bindDirtyForm();
    });

    abp.ajaxForm = ajaxForm;

    window.addEventListener('beforeunload', function (e) {
        var l = abp.localization.getSource('CMS');
        var isDirtyFormExisted = false;
        $('.dirty-form-checked').each(function () {
            var _$this = $(this);
            if (_$this.is('form')) {
                var formId = _$this.attr('id');
                isDirtyFormExisted = $("#" + formId).dirty("isDirty");
            }
        });
        if (isDirtyFormExisted) {
            e.returnValue = l("Data has been not saved yet. Are you sure want to leave?");
        }
    });

})(abp, window.jQuery);