$(document).ready(function () {
    HomeScripts.GetData();
});

class HomeScripts {

    static GetData() {
        debugger;
        return $.ajax({
            type: 'GET',
            url: 'http://localhost:54691/api/Estudiante/ListarEstudiantes',
            headers: { 'Content-Type': 'application/json', 'Authorization': 'Basic YWRtaW46YWRtaW4=', 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS', 'Access-Control-Allow-Headers': '*', 'Access-Control-Allow-Origin': '*' },
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                var name = response;
                var yourTableHTML = "";
                jQuery.each(name, function (i, data) {
                    $("#DataTable").append("<tr><td>" + data + "</td></tr>");
                });
            }
        });
    }
}