$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#ordersTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[5, "desc"]],
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Order/GetAllOrders/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#ordersTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const orderListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            if (orderListDto.ResultStatus === 0) {
                                $.each(orderListDto.Orders.$values,
                                    function (index, order) {
                                        const newTableRow = dataTable.row.add([
                                            order.Id,
                                            order.OrderNumber,
                                            order.Thumbnail,
                                             
                                            order.OrderType,
                                            convertToShortDate(order.OrderDate),
                                            order.OrderName,
                                            order.OrderQuantity,
                                            order.DayTarget,
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

    /* DataTables end here */

    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Order/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            window.location.href = url;
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */

         
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const orderName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${orderName} adlı sipariş ve varsa yapılan işler silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { orderId: id },
                        url: '/Admin/Order/Delete/',
                        success: function (data) {
                            const orderDto = jQuery.parseJSON(data);
                            if (orderDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${orderDto.Order.SiparisName} adlı sipariş ve yapılan işlemleri başarıyla silinmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${orderDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });

/* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

    $(function() {
        const url = '/Admin/Order/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { orderId: id }).done(function(data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function() {
                    toastr.error("Bir hata oluştu.");
                });
            });

    /* Ajax POST / Updating a Category starts from here */

    placeHolderDiv.on('click',
        '#btnUpdate',
        function(event) {
            event.preventDefault();

            const form = $('#form-order-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const orderUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(orderUpdateAjaxModel);
                const newFormBody = $('.modal-body', orderUpdateAjaxModel.OrderUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = orderUpdateAjaxModel.OrderDto.Order.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        orderUpdateAjaxModel.OrderDto.Order.Id,
                        orderUpdateAjaxModel.OrderDto.Order.SiparisNumara,
                        orderUpdateAjaxModel.OrderDto.Order.Thumbnail,
                         
                        orderUpdateAjaxModel.OrderDto.Order.SiparisType,
                        convertToShortDate(orderUpdateAjaxModel.OrderDto.Order.SiparisDate),
                        orderUpdateAjaxModel.OrderDto.Order.SiparisName,
                        orderUpdateAjaxModel.OrderDto.Order.SiparisAdet,
                        orderUpdateAjaxModel.OrderDto.Order.GunlukHedef,
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${orderUpdateAjaxModel
                            .OrderDto.Order.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${orderUpdateAjaxModel
                            .OrderDto.Order.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${orderUpdateAjaxModel.OrderDto.Message}`, "Başarılı İşlem!");
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function(response) {
                console.log(response);
            });
        });

    });
});