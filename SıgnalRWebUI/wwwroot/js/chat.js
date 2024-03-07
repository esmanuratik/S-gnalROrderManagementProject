var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7001/SignalRHub").build(); //bağlantıyı bu şekilde sağlıyorum
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date(); //Mesajı hangi tarihte ve saatte attığına bakıyorum
    var currentHour = currentTime.getHours();  //aktif saat bilgisi
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li"); //Her bir alana bir satır listele anlamına geliyor.
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});