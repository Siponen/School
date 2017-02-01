function BishBosh()
{
    document.getElementById("BishBosh").innerHTML = "";

    var form = document.forms["BishBoshForm"];
    var bishNumber = Math.floor(form["bishNumber"].value);
    var boshNumber = Math.floor(form["boshNumber"].value);
    var numberOfIterations = Math.floor(form["numberOfIterations"].value);

    if (numberOfIterations == 0) {
        alert("Error! Number of iterations should be higher than 0");
        return;
    }

    if (bishNumber > 0 && boshNumber > 0)
    {
        document.getElementById("BishBosh").innerHTML = ("BishNumber: " + bishNumber + ", " +
            "BoshNumber: " + boshNumber + "<br/><br/>");

        var output = "";
        var isBishNumber, isBoshNumber;
        for (var i = 1; i <= numberOfIterations; i++)
        {
           isBishNumber = (i % bishNumber === 0);
           isBoshNumber = (i % boshNumber === 0);

           if (isBishNumber && isBoshNumber)
               output += "BishBosh (" + i + ")";
           else if (isBishNumber)
               output += "Bish (" + i + ")";
           else if (isBoshNumber)
               output += "Bosh (" + i + ")";
           else
               output += i;

            output += "<br>";
           
        }
        document.getElementById("BishBosh").innerHTML += output;
    }
}