$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});

function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}


    //var map = L.map('map').setView([51.505, -0.09], 13);
    //L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    //    maxZoom: 19,
    //    attribution: '© OpenStreetMap contributors'
    //}).addTo(map);

    //var marker = L.marker([51.5, -0.09]).addTo(map);
    //marker.bindPopup("<b>Hello world!</b><br>I am a popup.").openPopup();

    var map = L.map('map').setView([55.0427, 82.918238], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    //fetch('/api/markers')
    //    .then(response => response.json())
    //    .then(data => {
    //        data.forEach(markerData => {
    //            var marker = L.marker([markerData.latitude, markerData.longitude]).addTo(map);
    //            marker.bindPopup(markerData.description);
    //        });
    //    });

    fetch('/api/markers')
        .then(response => response.json())
        .then(data => {
            data.forEach(markerData => {
                var marker = L.marker([markerData.latitude, markerData.longitude])
                    .addTo(map)
                    .bindPopup(markerData.description);

                if (document.getElementById('latitude') !== null && document.getElementById('longitude') !== null) {
                    marker.on('click', function () {
                        fillForm(markerData.latitude, markerData.longitude, markerData.description, markerData.id);
                    });
                }
            });
        });

    var marker;

    var selectedMarkerId;

    function fillForm(lat, lng, desc, id) {
        document.getElementById('latitude').value = lat;
        document.getElementById('longitude').value = lng;
        document.getElementById('description').value = desc;
        document.getElementById('markerId').value = id;

        updateDeleteLink(id);
    }

    map.on('click', function (e) {
        if (document.getElementById('latitude') !== null && document.getElementById('longitude') !== null) {
            var lat = e.latlng.lat;
            var lng = e.latlng.lng;

            document.getElementById('latitude').value = lat;
            document.getElementById('longitude').value = lng;

            if (marker) {
                marker.setLatLng(e.latlng);
            } else {
                marker = L.marker(e.latlng).addTo(map);
            }
        }
    });

function updateDeleteLink(markerId) {
    var deleteLink = document.getElementById('deleteMarkerLink');
    if (deleteLink) {
        deleteLink.href = 'Admin/Markers/DeleteMarker/' + markerId;
    }
}