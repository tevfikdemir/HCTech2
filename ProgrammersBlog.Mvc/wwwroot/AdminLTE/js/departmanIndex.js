$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#departmentsTable').DataTable({
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
                        url: '/Admin/Departman/GetAllDepartmans/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#departmentsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const departmentListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(departmentListDto);
                            if (departmentListDto.ResultStatus === 0) {
                                $.each(departmentListDto.Departments.$values,
                                    function (index, department) {
                                        const newTableRow = dataTable.row.add([
                                            department.Id,
                                            department.Name,
                                            department.Description,
                                             
                                            
                                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${department.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${department.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${department.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#departmentsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${departmentListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#departmentsTable').fadeIn(1000);
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
        const url = '/Admin/Departman/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _DepartmanAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as DepartmanAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-department-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const departmentAddAjaxModel = jQuery.parseJSON(data);
                    console.log(departmentAddAjaxModel);
                    const newFormBody = $('.modal-body', departmentAddAjaxModel.DepartmentAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            departmentAddAjaxModel.DepartmentDto.Department.Id,
                            departmentAddAjaxModel.DepartmentDto.Department.Name,
                            departmentAddAjaxModel.DepartmentDto.Department.Description,
                             
                                    `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${departmentAddAjaxModel.DepartmentDto.Department.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${departmentAddAjaxModel.DepartmentDto.Department.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                ]).node();
                                const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${departmentAddAjaxModel.DepartmentDto.Department.Id}`);
                        dataTable.draw();
                        toastr.success(`${departmentAddAjaxModel.DepartmentDto.Message}`, 'Başarılı İşlem!');
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
            const departmentName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${departmentName} adlı departman silinicektir!`,
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
                        data: { departmentId: id },
                        url: '/Admin/Departman/Delete/',
                        success: function (data) {
                            const departmentDto = jQuery.parseJSON(data);
                            if (departmentDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${departmentDto.Department.Name} adlı departman başarıyla silinmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${departmentDto.Message}`,
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
        const url = '/Admin/Departman/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { departmentId: id }).done(function(data) {
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

            const form = $('#form-department-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const departmentUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(departmentUpdateAjaxModel);
                const newFormBody = $('.modal-body', departmentUpdateAjaxModel.DepartmentUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = departmentUpdateAjaxModel.DepartmentDto.Department.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        departmentUpdateAjaxModel.DepartmentDto.Department.Id,
                        departmentUpdateAjaxModel.DepartmentDto.Department.Name,
                        departmentUpdateAjaxModel.DepartmentDto.Department.Description,
                          
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${departmentUpdateAjaxModel
                            .DepartmentDto.Department.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${departmentUpdateAjaxModel
                            .DepartmentDto.Department.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${departmentUpdateAjaxModel.DepartmentDto.Message}`, "Başarılı İşlem!");
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