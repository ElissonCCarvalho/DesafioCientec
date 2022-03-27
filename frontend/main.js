const baseURL = 'http://localhost:5257';

var id = -1;
const name = document.getElementById('Name')
const cnpj = document.getElementById('Cnpj')
const email = document.getElementById('Email')
const phoneNumber = document.getElementById('PhoneNumber')
const supportedInstitution = document.getElementById('SupportedInstitution')

document.addEventListener('keypress', function (e) {
    if (e.which == 13) {
        if ($("#search-input").is(":focus")) {
            const cnpj = document.getElementById('search-input').value

            if (cnpj != "") {
                $.ajax({
                    url: baseURL + '/api/Foundation/search/' + cnpj,
                    type: "get",
                    contentType: "application/json",
                    data: { cnpj },
                    success: function (foundation) {
                        var row = '<tr id="' + 0 + '">' +
                            "<td>" + foundation.id + "</td>" +
                            "<td>" + foundation.name + "</td>" +
                            "<td>" + foundation.cnpj + "</td>" +
                            "<td>" + foundation.email + "</td>" +
                            "<td>" + foundation.phoneNumber + "</td>" +
                            "<td>" + foundation.supportedInstitution + "</td>" +


                            '<td>' +
                            '<a class="edit" onClick="edit_onClick(' + 0 + ')"><i class="material-icons" title="Edit">&#xE254;</i></a>' +
                            '<a class="delete" onClick="delete_onClick(' + 0 + ')"><i class="material-icons" title="Delete">&#xE872;</i></a>' +
                            '</td>' +

                            "</tr>"

                        $('#table-content').html(row);
                    },
                    error: function (xhr, status, error) {
                        alert(xhr.responseText);
                    }
                });
            } else {
                loadTable();
            }
        }
    }
}, false);



$('#cancel').on('click', function () {
    id = -1;
    document.getElementById('list-tab').click();
})

$("#foundation-form").on("submit", function (event) {
    event.preventDefault();

    if (id == -1) {
        $.ajax({
            url: baseURL + '/api/Foundation',
            type: "post",
            contentType: "application/json",
            data: JSON.stringify({
                Name: $("#Name").val(),
                Cnpj: $("#Cnpj").val(),
                Email: $("#Email").val(),
                PhoneNumber: $("#PhoneNumber").val(),
                SupportedInstitution: $("#SupportedInstitution").val()
            }),
            success: function () {
                alert("Fundação cadastrada com sucesso!")
                document.getElementById('list-tab').click();
                resetForm();
                loadTable();
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    } else {
        $.ajax({
            url: baseURL + '/api/Foundation/' + id,
            type: "put",
            contentType: "application/json",
            data: JSON.stringify({
                Name: $("#Name").val(),
                Cnpj: $("#Cnpj").val(),
                Email: $("#Email").val(),
                PhoneNumber: $("#PhoneNumber").val(),
                SupportedInstitution: $("#SupportedInstitution").val()
            }),
            success: function () {
                alert("Fundação editada com sucesso!")
                document.getElementById('list-tab').click();
                resetForm();
                loadTable();
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
        id = -1;
    }

});

function edit_onClick(index) {
    document.getElementById('form-tab').click();

    const tbl = $('#table-content tr:has(td)').map(function (i, v) {
        var $td = $('td', this);
        return {
            id: $td.eq(0).text(),
            name: $td.eq(1).text(),
            cnpj: $td.eq(2).text(),
            email: $td.eq(3).text(),
            phoneNumber: $td.eq(4).text(),
            supportedInstitution: $td.eq(5).text()
        }
    }).get(index);

    id = tbl.id;
    name.value = tbl.name;
    cnpj.value = tbl.cnpj;
    email.value = tbl.email;
    phoneNumber.value = tbl.phoneNumber;
    supportedInstitution.value = tbl.supportedInstitution;
}

function delete_onClick(index) {
    if (confirm("Deseja realmente excluir?")) {
        const id = $('#table-content tr:has(td)').map(function (i, v) {
            var $td = $('td', this);
            return {
                id: $td.eq(0).text(),
            }
        }).get(index).id;

        $.ajax({
            url: baseURL + '/api/Foundation/' + id,
            type: "delete",
            contentType: "application/json",
            data: { id },
            success: function () {
                alert("Fundação deletada com sucesso!")
                document.getElementById('list-tab').click();
                resetForm();
                loadTable();

            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    }
}

function resetForm() {
    name.value = "";
    cnpj.value = "";
    email.value = "";
    phoneNumber.value = "";
    supportedInstitution.value = "";

    document.getElementById('search-input').value = "";
}


$(document).ready(function () {
    loadTable();
});

function loadTable() {
    $.ajax({
        url: baseURL + '/api/Foundation',
        type: 'GET',
        success: function (foundations) {
            var row = '';

            for (var i = 0; i < foundations.length; i++) {
                row += '<tr id="' + i + '">' +
                    "<td>" + foundations[i].id + "</td>" +
                    "<td>" + foundations[i].name + "</td>" +
                    "<td>" + foundations[i].cnpj + "</td>" +
                    "<td>" + foundations[i].email + "</td>" +
                    "<td>" + foundations[i].phoneNumber + "</td>" +
                    "<td>" + foundations[i].supportedInstitution + "</td>" +


                    '<td>' +
                    '<a class="edit" onClick="edit_onClick(' + i + ')"><i class="material-icons" title="Edit">&#xE254;</i></a>' +
                    '<a class="delete" onClick="delete_onClick(' + i + ')"><i class="material-icons" title="Delete">&#xE872;</i></a>' +
                    '</td>' +

                    "</tr>"
            }
            $('#table-content').html(row);
        }
    })
}
