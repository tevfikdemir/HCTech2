$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#gorevsTable').DataTable({
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
                        url: '/Admin/Gorevler/GetAllGorevs/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#gorevsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const gorevlerListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(gorevlerListDto);
                            if (gorevlerListDto.ResultStatus === 0) {
                                $.each(gorevlerListDto.Gorevlers.$values,
                                    function (index, gorevler) {
                                        const newTableRow = dataTable.row.add([
                                            gorevler.Id,
                                            gorevler.Name,
                                            gorevler.Description,
                                             
                                             
                                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${gorevler.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${gorevler.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${gorevler.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#gorevsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${gorevlerListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#gorevsTable').fadeIn(1000);
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
        const url = '/Admin/Gorevler/Add/';
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
                const form = $('#form-gorevler-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const gorevlerAddAjaxModel = jQuery.parseJSON(data);
                    console.log(gorevlerAddAjaxModel);
                    const newFormBody = $('.modal-body', gorevlerAddAjaxModel.GorevlerAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            gorevlerAddAjaxModel.GorevlerDto.Gorevler.Id,
                            gorevlerAddAjaxModel.GorevlerDto.Gorevler.Name,
                            gorevlerAddAjaxModel.GorevlerDto.Gorevler.Description,
                             
                                    `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${gorevlerAddAjaxModel.GorevlerDto.Gorevler.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${gorevlerAddAjaxModel.GorevlerDto.Gorevler.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                ]).node();
                                const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${gorevlerAddAjaxModel.GorevlerDto.Gorevler.Id}`);
                        dataTable.draw();
                        toastr.success(`${gorevlerAddAjaxModel.GorevlerDto.Message}`, 'Başarılı İşlem!');
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
            const gorevlerName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${gorevlerName} adlı gorev silinicektir!`,
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
                        data: { gorevlerId: id },
                        url: '/Admin/Gorevler/Delete/',
                        success: function (data) {
                            const gorevlerDto = jQuery.parseJSON(data);
                            if (gorevlerDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${gorevlerDto.Gorevler.Name} adlı görev başarıyla silinmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${gorevlerDto.Message}`,
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
        const url = '/Admin/Gorevler/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { gorevlerId: id }).done(function(data) {
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

            const form = $('#form-gorevler-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const gorevlerUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(gorevlerUpdateAjaxModel);
                const newFormBody = $('.modal-body', gorevlerUpdateAjaxModel.GorevlerUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = gorevlerUpdateAjaxModel.GorevlerDto.Gorevler.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        gorevlerUpdateAjaxModel.GorevlerDto.Gorevler.Id,
                        gorevlerUpdateAjaxModel.GorevlerDto.Gorevler.Name,
                        gorevlerUpdateAjaxModel.GorevlerDto.Gorevler.Description,
                         
                       
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${gorevlerUpdateAjaxModel
                            .GorevlerDto.Gorevler.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${gorevlerUpdateAjaxModel
                            .GorevlerDto.Gorevler.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${gorevlerUpdateAjaxModel.GorevlerDto.Message}`, "Başarılı İşlem!");
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