$('#guncelle').click(async function () {

    let apiUrl = "https://localhost:44355/Users/Update";
    // let apiUrl = "https://localhost:44355/Users/GetById?id=" + 1;
    await Lib.postJSON(apiUrl, { id: currentUserId, userName: $('#kullanici_adi').val(), password: $('#kullanici_sifre').val()  }, userUpdated);
    function userUpdated(result) {
        window.location.href = "/user";
    }

});

let currentUserId = 0;
let currentUserName = '';

$(document).ready(function () {
    let urlParams = new URLSearchParams(window.location.search);

    currentUserId = parseInt(urlParams.get('id'));
    currentUserName = urlParams.get('userName');

    $('#kullanici_adi').val(currentUserName);


});