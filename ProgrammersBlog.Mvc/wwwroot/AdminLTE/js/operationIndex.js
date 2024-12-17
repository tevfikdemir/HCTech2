$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#operationsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[1, "desc"]],
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
                        url: '/Admin/Operation/GetAllOperations/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#operationsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const operationListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(operationListDto);
                            if (operationListDto.ResultStatus === 0) {
                                $.each(operationListDto.Operations.$values,
                                    function (index, operation) {
                                        const newTableRow = dataTable.row.add([
                                            operation.Id,
                                            operation.OperationName,
                                            operation.MakinaTipi,
                                             
                                           
                                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${operation.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${operation.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${operation.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#operationsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${operationListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
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
        const url = '/Admin/Operation/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-operation-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const operationAddAjaxModel = jQuery.parseJSON(data);
                    console.log(operationAddAjaxModel);
                    const newFormBody = $('.modal-body', operationAddAjaxModel.OperationAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            operationAddAjaxModel.OperationDto.Operation.Id,
                            operationAddAjaxModel.OperationDto.Operation.OperationName,
                            operationAddAjaxModel.OperationDto.Operation.MakinaTipi,
                            
                           
                                    `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${operationAddAjaxModel.OperationDto.Operation.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${operationAddAjaxModel.OperationDto.Operation.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                ]).node();
                                const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${operationAddAjaxModel.OperationDto.Operation.Id}`);
                        dataTable.draw();
                        toastr.success(`${operationAddAjaxModel.OperationDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText += `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const operationName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${operationName} adlı kategori silinicektir!`,
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
                        data: { operationId: id },
                        url: '/Admin/Operation/Delete/',
                        success: function (data) {
                            const operationDto = jQuery.parseJSON(data);
                            if (operationDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${operationDto.Operation.Name} adlı operasyon başarıyla silinmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${operationDto.Message}`,
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
        const url = '/Admin/Operation/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { operationId: id }).done(function(data) {
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

            const form = $('#form-operation-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const operationUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(operationUpdateAjaxModel);
                const newFormBody = $('.modal-body', operationUpdateAjaxModel.OperationUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = operationUpdateAjaxModel.OperationDto.Operation.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        operationUpdateAjaxModel.OperationDto.Operation.Id,
                        operationUpdateAjaxModel.OperationDto.Operation.OperationName,
                        operationUpdateAjaxModel.OperationDto.Operation.MakinaTipi,
                         
                        
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${operationUpdateAjaxModel
                            .OperationDto.Operation.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${operationUpdateAjaxModel
                            .OperationDto.Operation.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${operationUpdateAjaxModel.OperationDto.Message}`, "Başarılı İşlem!");
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