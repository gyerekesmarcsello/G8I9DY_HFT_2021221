let artists = [];

fetch('http://localhost:53910/artist')
    .then(x => x.json())
    .then(y => {
        artists = y;
        console.log(artists);
        display();
    });

function display() {
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.ArtistID + "</td><td>"
            + t.Name + "</td></tr>";
    });
}