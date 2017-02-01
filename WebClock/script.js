function startTimer()
{
    var today = new Date();

    myClock = setInterval(tick, 1000);
    hours = today.getHours();
    minutes = today.getMinutes();
    seconds = today.getSeconds();
    isVisible = true;
}

function stopTimer()
{
    clearTimeout(myClock);
}

function tick()
{
    var maxSeconds = 60;
    var maxMinutes = 60;
    var maxHours = 24;

    seconds++;

    if(seconds >= maxSeconds)
    {
        minutes++;
        seconds = 0;
    }

    if(minutes >= maxMinutes)
    {
        hours++;
        minutes = 0;
    }

    if(hours >= maxHours)
    {
        hours = 0;
    }

    var hourString = "";
    var minuteString = "";
    var secondString = "";

    if (seconds < 10)
        secondString += "0";
    if (minutes < 10)
        minuteString += "0";
    if (hours < 10)
        hourString += "0";

    secondString += seconds;
    minuteString += minutes;
    hourString += hours;

    if (isVisible)
    {
        colon = "\xa0\xa0\xa0";
        isVisible = false;
    }
    else
    {
        colon = " : ";
        isVisible = true;
    }

    document.getElementById("time").innerHTML = hourString + colon + minuteString + colon + secondString;
}
