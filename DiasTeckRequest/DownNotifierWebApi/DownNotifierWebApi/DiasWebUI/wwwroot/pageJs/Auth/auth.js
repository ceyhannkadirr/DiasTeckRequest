$('#loginBtn').click(async function (event) {
    event.preventDefault();

    let name = $('#kullanici_adi').val();
    let value = $('#kullanici_sifre').val();

    let apiUrl = `https://localhost:44355/Authentication/Login?userName=${name}&password=${value}`;
    await Lib.postJSON(apiUrl, { }, urlFetched);
    function urlFetched(result) {

        localStorage.setItem('userValue', JSON.stringify(result));

        window.location.href = "/url";
    }

});