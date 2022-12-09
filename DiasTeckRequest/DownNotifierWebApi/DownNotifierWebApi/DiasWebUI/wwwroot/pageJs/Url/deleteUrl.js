async function deleteUrl(id) {

    let apiUrl = "https://localhost:44355/UserUrls/Delete?id=" + id;//TODO id nasıl gelecek
    await Lib.deleteJSON(apiUrl, urlFetched);
    function urlFetched(result) {
        window.location.reload();
    }

};