$('#guncelle').click(async function (id) {

    let apiUrl = "https://localhost:44355/UserUrls//GetById?id=" + id;//TODO id nasıl gelecek
    // let apiUrl = "https://localhost:44355/Users/GetById?id=" + 1;
    await Lib.getJSON(apiUrl, urlFetched);
    function urlFetched(result) {
        console.log(result);
        $('#url_name').append(result.username);////BURA KONTROL EDİLECEK
        $('#url_value').append(result.password);

    }

});