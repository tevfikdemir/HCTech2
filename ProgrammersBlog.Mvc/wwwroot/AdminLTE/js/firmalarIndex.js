$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#companiesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[2, "desc"]],
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
                        url: '/Admin/Firmalar/GetAllFirmalars/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#companiesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const companyListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(companyListDto);
                            if (companyListDto.ResultStatus === 0) {
                                $.each(companyListDto.Companies.$values,
                                    function (index, company) {
                                        const newTableRow = dataTable.row.add([
                                            company.Id,
                                            company.Name,
                                            company.VergiNo,
                                             
                                             
                                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${company.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${company.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${company.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#companiesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${companyListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#companiesTable').fadeIn(1000);
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
        const url = '/Admin/Firmalar/Add/';
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
                const form = $('#form-company-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const companyAddAjaxModel = jQuery.parseJSON(data);
                    console.log(companyAddAjaxModel);
                    const newFormBody = $('.modal-body', companyAddAjaxModel.CompanyAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            companyAddAjaxModel.CompanyDto.Company.Id,
                            companyAddAjaxModel.CompanyDto.Company.Name,
                            companyAddAjaxModel.CompanyDto.Company.VergiNo,
                            
                             
                                    `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${companyAddAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${companyAddAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                ]).node();
                                const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${companyAddAjaxModel.CompanyDto.Company.Id}`);
                        dataTable.draw();
                        toastr.success(`${companyAddAjaxModel.CompanyDto.Message}`, 'Başarılı İşlem!');
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
            const companyName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${companyName} adlı firma silinicektir!`,
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
                        data: { companyId: id },
                        url: '/Admin/Firmalar/Delete/',
                        success: function (data) {
                            const companyDto = jQuery.parseJSON(data);
                            if (companyDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${companyDto.Company.Name} adlı firma başarıyla silinmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${companyDto.Message}`,
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
        const url = '/Admin/Firmalar/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { companyId: id }).done(function(data) {
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

            const form = $('#form-company-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const companyUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(companyUpdateAjaxModel);
                const newFormBody = $('.modal-body', companyUpdateAjaxModel.CompanyUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = companyUpdateAjaxModel.CompanyDto.Company.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        companyUpdateAjaxModel.CompanyDto.Company.Id,
                        companyUpdateAjaxModel.CompanyDto.Company.Name,
                        companyUpdateAjaxModel.CompanyDto.Company.VergiNo,
                         
                         
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${companyUpdateAjaxModel
                            .CompanyDto.Company.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${companyUpdateAjaxModel
                            .CompanyDto.Company.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${companyUpdateAjaxModel.CompanyDto.Message}`, "Başarılı İşlem!");
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