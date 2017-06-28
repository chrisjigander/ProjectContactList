function GetJson() {
    $.getJSON("http://localhost:63478/contact.aspx")
        .done(function (data) {

            $("#myBody").children().remove();

            var newBody = "";

            for (var i = 0; i < data.length; i++) {
                newBody += "<tr><td>" + data[i].ID + "</td>";
                newBody += "<td>" + data[i].FirstName + "</td>";
                newBody += "<td>" + data[i].LastName + "</td>";
                newBody += "<td>" + data[i].Address.Street + "</td>";
                newBody += "<td>" + data[i].Address.City + "</td>";
                newBody += "<td>" + data[i].PhoneNumber + "</td></tr>";
            }

            $("#myBody").append(newBody);
        });

}

function AddContact()
{
    var fName = document.getElementById("firstName").value;
    var lName = document.getElementById("lastName").value;
    var street = document.getElementById("street").value;
    var city = document.getElementById("city").value;

    $.getJSON("http://localhost:63478/contact.aspx?action=create&firstName=" + fName + "&lastName=" + lName + "&street=" + street + "&city=" + city)
        .done(function (data) {
            $("#myBody").children().remove();

            var newBody = "";

            for (var i = 0; i < data.length; i++) {
                newBody += "<tr><td>" + data[i].ID + "</td>";
                newBody += "<td>" + data[i].FirstName + "</td>";
                newBody += "<td>" + data[i].LastName + "</td>";
                newBody += "<td>" + data[i].Address.Street + "</td>";
                newBody += "<td>" + data[i].Address.City + "</td>";
                newBody += "<td>" + data[i].PhoneNumber + "</td></tr>";
            }

            $("#myBody").append(newBody);
        });
}