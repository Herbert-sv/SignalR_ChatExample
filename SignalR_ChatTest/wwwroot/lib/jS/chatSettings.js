
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub").withAutomaticReconnect().build();


document.getElementById("buttonsend").disabled = true;


// message js block//

connection.on("ReceivedMessage", function (UserName, Message) {
    const r_msg = UserName + ":"
    const rtwo_msg = Message;
    const li = document.createElement("li");
    const li_two = document.createElement("p");
    li.textContent = r_msg;
    li_two.textContent = rtwo_msg;
    document.getElementById("messageList").appendChild(li);
    document.getElementById("messageList").appendChild(li_two);

});
connection.start().then(function () {
    document.getElementById("buttonsend").disabled = false;

}).catch(error => console.error(error.toString()));
    

// Invoke Message//

document.getElementById("buttonsend").addEventListener("click", event => {
    const usernam = document.getElementById("username").value;
    const usermessa = document.getElementById("message").value;

    connection.invoke("SendMessage", usernam, usermessa).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("message").value = " ";
   
    event.preventDefault();
    document.getElementById("message").focus();
});


