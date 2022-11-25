

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Resource/GetAll"
        },
        "columns": [
            { "data": "JobTitle", "width": "15%" },
            { "data": "SkillSet", "width": "15%" },
            { "data": "Experience", "width": "15%" },
            { "data": "StartDateOfJob", "width": "15%" },
            { "data": "EndDateOfJob", "width": "15%" },
            { "data": "NumberOfResources", "width": "15%" },
            { "data": "customer.CustName", "width": "15%" },
            { "data": "ProjectId", "width": "15%" },
            {
                "data": "jobId",
                "render": function (data) {
                    return `
                       <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Resource/Upsert?jobId=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/Admin/Resource/Delete/${data}')
                      class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					//</div>
                      `
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}