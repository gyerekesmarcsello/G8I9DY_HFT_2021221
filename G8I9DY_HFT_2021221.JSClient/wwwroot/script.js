let tracks = [];
let connection = null;
let trackIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:2509/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TrackCreated", (user, message) => {
        getdata();
    });

    connection.on("TrackDeleted", (user, message) => {
        getdata();
    });

    connection.on("TrackUpdated", (user, message) => {
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
    await fetch('http://localhost:2509/track')
        .then(x => x.json())
        .then(y => {
            tracks = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    tracks.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.TrackID + "</td><td>"
            + t.Title + "</td><td>"
            + t.AlbumID + "</td><td>"
            + t.Plays + "</td><td>"
            + t.Duration + "</td><td>"
            + t.ArtistID + "</td><td>"
            + t.IsExplicit + "</td><td>"
            + `<button type="button" onclick="showupdate(${t.TrackID})">Update</button>`
            + `<button type="button" onclick="remove(${t.TrackID})">Delete</button>` +
            "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('trackName').value;
    let name2 = document.getElementById('trackAlbumID').value;
    let name3 = document.getElementById('trackPlays').value;
    let name4 = document.getElementById('trackDuration').value;
    let name5 = document.getElementById('trackArtistID').value;
    let name6 = document.getElementById('trackExplicit').value;
    fetch('http://localhost:2509/track', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                trackName: name,
                trackAlbumID: name2,
                trackPlays: name3,
                trackDuration: name4,
                trackArtistID: name5,
                trackExplicit: name6

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
    document.getElementById('trackNameToUpdate').value = track.find(t => t['TrackID'] == id)['Title'];
    document.getElementById('trackAlbumIDToUpdate').value = track.find(t => t['TrackID'] == id)['AlbumID'];
    document.getElementById('trackPlaysToUpdate').value = track.find(t => t['TrackID'] == id)['Plays'];
    document.getElementById('trackDurationToUpdate').value = track.find(t => t['TrackID'] == id)['Duration'];
    document.getElementById('trackArtistIDToUpdate').value = track.find(t => t['TrackID'] == id)['ArtistID'];
    document.getElementById('trackExplicitToUpdate').value = track.find(t => t['TrackID'] == id)['IsExplicit'];
    document.getElementById('updateformdiv').style.display = 'flex';
    trackIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('trackNameToUpdate').value;
    let name2 = document.getElementById('trackAlbumIDToUpdate').value;
    let name3 = document.getElementById('trackPlaysToUpdate').value;
    let name4 = document.getElementById('trackDurationToUpdate').value;
    let name5 = document.getElementById('trackArtistIDToUpdate').value;
    let name6 = document.getElementById('trackExplicitToUpdate').value;

    fetch('http://localhost:2509/track', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                trackID: trackIdToUpdate,
                trackName: name,
                trackAlbumID: name2,
                trackPlays: name3,
                trackDuration: name4,
                trackArtistID: name5,
                trackExplicit: name6
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
    fetch('http://localhost:2509/track' + id, {
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