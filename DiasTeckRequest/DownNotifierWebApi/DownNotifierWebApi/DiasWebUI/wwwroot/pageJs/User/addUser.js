$('#kaydet').click(async function (event) {
    event.preventDefault();
    let userName = $('#kullanici_adi').val();
    let password = $('#kullanici_sifre').val();

    let apiUrl = "https://localhost:44355/Users/Add";
    // let apiUrl = "https://localhost:44355/Users/GetById?id=" + 1;
    await Lib.postJSON(apiUrl, { userName: userName, password: password }, userCreated);
    function userCreated(result) {
        window.location.href = "/user";
    }

});