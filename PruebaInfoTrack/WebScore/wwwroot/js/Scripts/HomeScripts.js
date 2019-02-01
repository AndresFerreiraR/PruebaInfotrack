$(document).ready(function () {
    HomeScripts.GetData();
});

class HomeScripts {

    static GetData() {
        var Students_List = '';
        return $.ajax({
            type: 'GET',
            url: 'http://localhost:6813/Home/getEstudents',
            contentType: 'application/json utf-8',
            dataType: 'json',
            success: function (response) {
                var JSONRespuesta = response.Descripcion;
                for (var i = 0; i < JSONRespuesta.length; i++) {
                    Students_List = Students_List +
                        '<tr>' +
                        '<td nowrap data-column-id="Check" value="' + JSONRespuesta[i].IdAlumno + '</td>' +
                        '<td nowrap data-column-id="studentName" value="' + JSONRespuesta[i].Nombres + '</td>' +
                        '<td nowrap data-column-id="studentSurname">' + JSONRespuesta[i].Apellidos + '</td>' +
                        '<td nowrap data-column-id="studentNIT" class="Nombre">' + JSONRespuesta[i].Identificacion + '</td>' +
                        '<td nowrap data-column-id="studentPhoneNumber">' + JSONRespuesta[i].Telefono + '</td>' +
                        '<td nowrap data-column-id="studentEmail">' + JSONRespuesta[i].Correo + '</td>' +
                        '</tr>';
                }
                $("#Students_List").html(Students_List);
            }
        });
    }
}