let currentId = 0;


$(document).ready(async function () {

    let urlParam = new URLSearchParams(window.location.search)

    currentId = parseInt(urlParam.get('id'));

    let apiUrl = "https://localhost:44355/UserUrls/GetById?id=" + currentId;
    await Lib.getJSON(apiUrl, urlFetched);
    function urlFetched(result) {

        $('#url_name').val(result?.name);
        $('#url_value').val(result?.value);
    }

});

$('#kaydet').click(async function (event) {
    event.preventDefault();

    var obj = {
        name: $('#url_name').val(),
        value: $('#url_value').val(),
        id: currentId
    };

    let apiUrl = "https://localhost:44355/UserUrls/Update";
    // let apiUrl = "https://localhost:44355/UserUrls/GetById?id=" + 1;
    await Lib.postJSON(apiUrl, obj, urlFetched);
    function urlFetched(result) {
        window.location.href = "/url";
    }

});