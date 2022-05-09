let artists = [];
let connection = null;
let artistIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:2509/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });

    connection.on("ArtistUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
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

async function getdata() {
    await fetch('http://localhost:2509/artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.artistID + "</td><td>"
            + t.name + "</td><td>"
            + t.birthday + "</td><td>"
            + t.nationality + "</td><td>"
            + t.grammyWinner + "</td><td>"
            + `<button type="button" onclick="showupdate(${t.artistID})">Update</button>`
            + `<button type="button" onclick="remove(${t.artistID})">Delete</button>` +
            "</td></tr>";
    });
}


function create() {
    let name = document.getElementById('nameToCreate').value;
    let name2 = document.getElementById('birthdayToCreate').value;
    let name3 = document.getElementById('nationalityToCreate').value;
    let name4 = (document.getElementById('grammyWinnerToCreate').value === 'true');
    console.log(name4);
    fetch('http://localhost:2509/artist/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(
            {
                name: name,
                birthday: name2,
                nationality: name3,
                grammyWinner: name4
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showupdate(id) {
    document.getElementById('nameToUpdate').value = artists.find(t => t['artistID'] == id)['name'];
    document.getElementById('birthdayToUpdate').value = artists.find(t => t['artistID'] == id)['birthday'];
    document.getElementById('nationalityToUpdate').value = artists.find(t => t['artistID'] == id)['nationality'];
    document.getElementById('grammyToUpdate').value = artists.find(t => t['artistID'] == id)['grammyWinner'];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name =  document.getElementById('nameToUpdate').value;
    let name2 = document.getElementById('birthdayToUpdate').value;
    let name3 = document.getElementById('nationalityToUpdate').value;
    let name4 = (document.getElementById('grammyToUpdate').value === 'false');
    console.log(name4);

    fetch('http://localhost:2509/artist/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(
            {
                artistID: artistIdToUpdate,
                name: name,
                birthday: name2,
                nationality: name3,
                grammyWinner: name4
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:2509/artist/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}