function GetJson() {
    $.getJSON("http://localhost:63478/contact.aspx")
        .done(function (data) {

            $("#myBody").children().remove();

            var newBody = "";

            for (var i = 0; i < data.length; i++) {
                newBody += "<tr><td>" + data[i].ID + "</td>";
                newBody += "<td>" + data[i].FirstName + "</td>";
                newBody += "<td>" + data[i].LastName + "</td></tr>";
            }

            $("#myBody").append(newBody);
        });

}