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
    var phoneNumber = document.getElementById("phoneNumber").value;

    $.getJSON("http://localhost:63478/contact.aspx?action=create&firstName=" + fName + "&lastName=" + lName + "&street=" + street + "&city=" + city + "&phoneNumber=" + phoneNumber)
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
function UpdateContact()
{
    
}

function DeleteContact()
{

}

function SortContacts(sortBy)
{
    var myTableBody = document.getElementById("myBody");

    var myRows = myTableBody.children;

    for (var i = 0; i < myRows.length; i++) {

        for (var j = i + 1; j < myRows.length; j++) {

            var iName = myRows[i].children[sortBy].innerHTML;

            var jName = myRows[j].children[sortBy].innerHTML;

            if (iName.localeCompare(jName) > 0) {
                myTableBody.insertBefore(myRows[j], myRows[i]);
            }
        }
    }
}