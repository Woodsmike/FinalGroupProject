//Populate map
var map;
var infowindow;

function initMap() {
    var pyrmont = { lat: 41.4993, lng: -81.6944 };

    map = new google.maps.Map(document.getElementById('map'), {
        center: pyrmont,
        zoom: 14
    });

    infowindow = new google.maps.InfoWindow();
    var service = new google.maps.places.PlacesService(map);
    service.nearbySearch({
        location: pyrmont,
        radius: 5000,
        type: ['gym']
    }, callback);
}

function callback(results, status) {
    if (status === google.maps.places.PlacesServiceStatus.OK) {
        for (var i = 0; i < results.length; i++) {
            createMarker(results[i]);
        }
    }
}

function createMarker(place) {
    var placeLoc = place.geometry.location;
    var marker = new google.maps.Marker({
        map: map,
        position: place.geometry.location
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(place.name);
        infowindow.open(map, this);
    });
}


//display legs div
function openWindow() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('legs');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}

//display legs div
function closeWindow() {
    var x = document.getElementById('legs');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}

//display arms div
function openWindowOne() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('arms');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//close arms div
function closeWindowOne() {

    var x = document.getElementById('arms');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//display back div
function openWindowTwo() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('back');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//close back div
function closeWindowTwo() {

    var x = document.getElementById('back');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//display chest div
function openWindowThree() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('chest');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//close chest div
function closeWindowThree() {

    var x = document.getElementById('chest');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//display abs div
function openWindowFour() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('abs');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//close abs div
function closeWindowFour() {

    var x = document.getElementById('abs');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//display cardio div
function openWindowFive() {

    var x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    x = document.getElementById('cardio');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
//close cardio div
function closeWindowFive() {

    var x = document.getElementById('cardio');
    if (x.style.display === 'none') {
        x.style.display = "display";
    }
    else {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}


//UPPERCASE ids of Arms, Legs, etc. is for the Activity log page....lowercase for home page
function openArmsDiv() {

    var x = document.getElementById('armsActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openLegsDiv() {

    var x = document.getElementById('legsActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openChestDiv() {

    var x = document.getElementById('chestActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openBackDiv() {

    var x = document.getElementById('backActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openAbsDiv() {

    var x = document.getElementById('absActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openCardioDiv() {

    var x = document.getElementById('cardioActivity');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function openFilterDiv() {

    var x = document.getElementById('filter');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    } else {
        x.style.display = 'block';
    }
}
function divSwitch() {

    var x = document.getElementById('legs');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
    x = document.getElementById('divContainer');
    if (x.style.display === 'none') {
        x.style.display = 'Block';
    }
    x = document.getElementById('arms');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
    x = document.getElementById('back');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
    x = document.getElementById('chest');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
    x = document.getElementById('abs');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
    x = document.getElementById('cardio');
    if (x.style.display === 'block') {
        x.style.display = 'none';
    }
}



function openAllActivityDivs() {
    document.getElementById('Arms').click();
    document.getElementById('Back').click();
    document.getElementById('Cardio').click();
    document.getElementById('Chest').click();
    document.getElementById('Legs').click();
    document.getElementById('Abs').click();
}

function selectDiv() {
    var x = window.location.href;
    if (x.includes('armsActivity')) {
        document.getElementById('Arms').click();
    }
    else if (x.includes('chestActivity')) {
        document.getElementById('Chest').click();
    }
    else if (x.includes('backActivity')) {
        document.getElementById('Back').click();
    }
    else if (x.includes('legsActivity')) {
        document.getElementById('Legs').click();
    }
    else if (x.includes('absActivity')) {
        document.getElementById('Abs').click();
    }
    else if (x.includes('cardioActivity')) {
        document.getElementById('Cardio').click();
    }
}

