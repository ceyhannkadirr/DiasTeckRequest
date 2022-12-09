$('#kaydet').click(async function (event) {
    event.preventDefault();

    let name = $('#url_name').val();
    let value = $('#url_value').val();

    let apiUrl = "https://localhost:44355/UserUrls/Add";
    await Lib.postJSON(apiUrl, { name: name, value: value }, urlFetched);
    function urlFetched(result) {
        window.location.href = "/url";
    }

});