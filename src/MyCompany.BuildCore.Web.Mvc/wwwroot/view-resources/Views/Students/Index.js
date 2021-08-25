var searchKeyPressTimer;

(function ($) {

    $('.btn-search').on('click', (e) => {
        searchStudentList(0);
    });

    $('.txt-search').on('keyup', (e) => {
        if (searchKeyPressTimer) {
            clearTimeout(searchKeyPressTimer);
            searchKeyPressTimer = null;
        }
        searchKeyPressTimer = setTimeout(searchStudentListByKeyPress, 1000);
    });

    abp.event.on('ajax-form-binded', function (data) {
        searchStudentList(0);
    });

    abp.event.on('frmSearchStudentListForm.submitted.success', function (data) {

        var _$tblTableList = $('#tblStudentList');
        var _$frmSearchList = $("#frmSearchStudentListForm");

        var initSortBy = _$frmSearchList.find('input[name="SortBy"]').val();
        var initSortColIndex = _$tblTableList.find("[data-sortby='" + initSortBy + "']").data('col-index');
        var initSortDirection = _$frmSearchList.find('input[name="SortDirection"]').val();
        var _dataTableResult = _$tblTableList.DataTable({
            paging: false,
            info: false,
            ordering: true,
            order: [[initSortColIndex, initSortDirection]],
            buttons: [],
            columnDefs: [
                {
                    targets: 2,
                    width: 62,
                    sortable: false
                }
            ]
        });
        _$tblTableList.on('order.dt', function () {
            var order = _dataTableResult.order();
            var sortBy = _$tblTableList.find("[data-col-index='" + order[0][0] + "']").data('sortby');
            _$frmSearchList.find('input[name="SortBy"]').val(sortBy);
            var sortDirection = order[0][1];
            _$frmSearchList.find('input[name="SortDirection"]').val(sortDirection);
            searchStudentList(0);
        });

    });

})(jQuery);

function searchStudentListByKeyPress() {
    searchStudentList(0);
    clearTimeout(searchKeyPressTimer);
    searchKeyPressTimer = null;
}

function searchStudentList(pageIndex) {
    $('#frmSearchStudentListForm_PageIndex').val(pageIndex);
    $('#frmSearchStudentListForm').submit();
}
