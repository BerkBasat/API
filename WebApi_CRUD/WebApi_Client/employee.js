
$(function () {

    function BringData(employees) {
        $('#employeeTable').find('tr').remove();
        $.each(employees, function (index, data) {
            $('#employeeTable').append(
                `<tr>
                        <td>${data.Title}</td>
                        <td>${data.FirstName}</td>
                        <td>${data.LastName}</td>
                        <td><button class='btn btn-sm btn-danger' value='Delete' id=${data.Id}>Delete</button></td>
                        <td><button class='btn btn-sm btn-warning' value='Update' id=${data.Id}>Update</button></td>
  
</tr>`
            )
        })
    }

    //Çalışan Silme ve Güncelleme

    $("#employeeTable").on('click', 'button', function () {
        var currentValue = $(this).attr('value');
        var currentId = $(this).attr('id');
        var message=confirm('işlem yapmak istediğinize emin misiniz?')
        if (currentValue == 'Delete') {
            if (message) {
                $.ajax({
                    method: 'Delete',
                    url: 'https://localhost:44399/api/employees/DeleteEmployee/' + currentId,
                    success: function (employees) {
                        BringData(employees);
                    }
                })
            }
        }
        else if (currentValue == 'Update') {
            var updatedEmp = new Object();
            $('#title').val() = updatedEmp.Title;
            $('#firstName').val() = updatedEmp.FirstName;
            $('#lastName').val() = updatedEmp.LastName;
             $.ajax({
                 method: 'Put',
                 url: 'https://localhost:44399/api/employees/UpdateEmployee/' + currentId,
                 data: updatedEmp,
                 success: function (employees) {
                      BringData(employees)
                 },
                 error: function (msg) {
                      alert(msg.responseText);
                 }

                })
            }
        else {
            alert('İptal edildi!')
        }
    })

    //Çalışan Ekleme
    $("#addEmployee").click(function () {
        var employeeObj = new Object();
        employeeObj.Title = $('#title').val();
        employeeObj.FirstName = $('#firstName').val();
        employeeObj.LastName = $('#lastName').val();
        if (employeeObj) {
            $.ajax({
                method: "Post",
                url: 'https://localhost:44399/api/employees/AddEmployee',
                data: employeeObj,
                    success: function() {
                        alert("Data added successfully!")
                },
                error: function (msg) {
                    alert(msg.responseText);
                }
            })
        }
    })

    //Api istek
    $("#getEmployee").click(function () {
        $.ajax({
            method: 'Get',
            url: 'https://localhost:44399/api/employees/GetEmployees',
            success: function (employees) {
                BringData(employees);
            }
        })
    })



})

