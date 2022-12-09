async function deleteUser(id) {
    let apiUrl = "https://localhost:44355/Users/Delete?id=" + id;//TODO id nasıl gelecek
    await Lib.deleteJSON(apiUrl, userFetched);
    function userFetched(result) {
        window.location.reload();
    }
}