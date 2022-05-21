$(document).ready(function () {
    $('#datatable').DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Hiển thị _START_ tới _END_ trong _TOTAL_ bản ghi",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Hiển thị _MENU_",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Tìm kiếm",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Trang đầu",
                "last": "Trang cuối",
                "next": ">",
                "previous": "<"
            },
            "aria": {
                "sortAscending": "activate to sort column ascending",
                "sortDescending": "activate to sort column descending"
            }
        }
    });
});