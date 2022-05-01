let artists = [];

let connection = null;

getData();
setup();

function setup() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:2509/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => { getData(); });
    connection.on("ArtistDeleted", (user, message) => { getData(); });
    connection.on("ArtistUpdated", (user, message) => { getData(); });

    connection.onclose
        (async () => {
            await start();
        });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData() {
    await fetch("http://localhost:2509/artist")
        .then(x => x.json())
        .then(y => {
            blogs = y;
            display();
        });
}

function display() {
    document.getElementById("results").innerHTML = "";
    blogs.forEach(t => {
        document.getElementById("results").innerHTML += "<tr><td>" + t.ArtistID + " </td><td>" + t.Name + "<td>" + t.ArtistID + " </td>"`</td><td>'<button class="btn btn-danger" onclick="remove(${t.ArtistID})">Delete</button></td><td> <button class="btn btn-success" onclick="setUpdate('${String(t.Name)}', ${t.ArtistID})">Update</button></td></tr>`;
    });
}


function create() {
    let name = document.getElementById("artistName").value;
    let birthday = document.getElementById('artisBirthday').value;
    let nationality = document.getElementById('artistNationality').value;
    let grammywinner = document.getElementById('artistGrammyWinner').value;
    fetch("http://localhost:2509/artist", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: name }),
    })
        .then(response => response)
        .then(data => {
            getData();
        })
        .catch((error) => { console.log('Error: ', error) });
    document.getElementById("artistName").value = "";
    document.getElementById('artisBirthday').value = "";
    document.getElementById('artistNationality').value = "";
    document.getElementById('artistGrammyWinner').value = "";
}

function remove(id) {
    fetch("http://localhost:2509/artist" + id, {
        method: "DELETE",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: name }),
    })
        .then(response => response)
        .then(data => {
            getData();
        })
        .catch((error) => { console.log('Error: ', error) });
}

function setUpdate(title, id) {
    document.getElementById('edit-ArtistID').value = ArtistID;
    document.getElementById('edit-Name').value = Name;
    document.getElementById('edit-Birthday').value = Birthday;
    document.getElementById('edit-Nationality').value = Nationality;
    document.getElementById('edit-GrammyWinner').value = GrammyWinner;
}

function Update() {
    ArtistID = document.getElementById('edit-ArtistID').value;
    Name = document.getElementById('edit-Name').value;
    Birthday = document.getElementById('edit-Birthday').value;
    Nationality = document.getElementById('edit-Nationality').value;
    GrammyWinner = document.getElementById('edit-GrammyWinner').value;

    fetch("http://localhost:2509/artist", {
        method: "PUT",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id: id, title: title }),
    })
        .then(response => response)
        .then(data => {
            getData();
        })
        .catch((error) => { console.log('Error: ', error) });

    document.getElementById('edit-ArtistID').value = "";
    document.getElementById('edit-Name').value = "";
    document.getElementById('edit-Birthday').value = "";
    document.getElementById('edit-Nationality').value = "";
    document.getElementById('edit-GrammyWinner').value = "";

}