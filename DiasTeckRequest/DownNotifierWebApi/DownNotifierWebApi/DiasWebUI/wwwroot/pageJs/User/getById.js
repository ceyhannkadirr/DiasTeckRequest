$('#guncelle').click(async function (id) {

    let apiUrl = "https://localhost:44355/Users//GetById?id=" + id;//TODO id nasıl gelecek
    // let apiUrl = "https://localhost:44355/Users/GetById?id=" + 1;
    await Lib.getJSON(apiUrl, userFetched);
    function userFetched(result) {
        console.log(result);
        $('#kullanici_adi').append(result.username);
        $('#kullanici_sifre').append(result.password);

    }

});