$(document).ready(function () {

    /* DataTables start here. */

    const dataTable =  $('#ordersTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[5, "desc"]],
        buttons: [
             
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    refreshTable();
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }

    });

    function refreshTable() {
        $.ajax({
            type: 'GET',
            url: '/Admin/Rapor/GetAllOrdPersSizeOpr/',
            contentType: "application/json",
            beforeSend: function () {
                $('#ordersTable').hide();
                $('.spinner-border').show();
            },
            success: function (data) {
                const orderListDto = jQuery.parseJSON(data);
                dataTable.clear();
                console.log(orderListDto);
                if (orderListDto.ResultStatus === 0) {
                    $.each(orderListDto.$values,
                        function (index, order) {
                            const newTableRow = dataTable.row.add([
                                order.Id,
                                order.OrderId,
                                order.PersonName,
                                order.SizeName,
                                order.OperationName,
                                order.SizeId,
                                order.SizeId,
                               
                                `
                            <button class="btn btn-primary btn-sm btn-update" data-id="${order.Id}"><span class="fas fa-edit"></span></button>
                            <button class="btn btn-danger btn-sm btn-delete" data-id="${order.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${order.Id}`);
                        });
                    dataTable.draw();
                    $('.spinner-border').hide();
                    $('#ordersTable').fadeIn(1400);
                } else {
                    toastr.error(`${orderListDto.Message}`, 'İşlem Başarısız!');
                }
            },
            error: function (err) {
                console.log(err);
                $('.spinner-border').hide();
                $('#ordersTable').fadeIn(1000);
                toastr.error(`${err.responseText}`, 'Hata!');
            }
        });
    }

    // Run the refreshTable function every 30 seconds
    setInterval(refreshTable, 30000);





    /* DataTables end here */

 

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */








    


/* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

});