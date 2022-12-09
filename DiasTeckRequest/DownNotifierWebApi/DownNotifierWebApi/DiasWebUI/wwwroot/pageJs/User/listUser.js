$(document).ready(async function () {

    let apiUrl = "https://localhost:44355/Users/GetList";
    // let apiUrl = "https://localhost:44355/Users/GetById?id=" + 1;
    await Lib.getJSON(apiUrl, userFetched);
    function userFetched(result) {
        console.log(result);

        result.map((x) => {

            let trHtml = `<tr> <td>${x?.id}</td> <td>${x.userName}</td>  <td> <a href='/User/EditUser?id=${x?.id}&userName=${x?.userName}' class ='btn btn-success' >Güncelle</a></td> <td> <a href='javascript:void(0)' onclick='deleteUser(${x?.id})' class ='btn btn-danger' >Sil</a></td></tr>`;
            //var js = {
            //    username: $('#userInou').val()""
            //};
            $('#userList').append(trHtml);

        });

    }

});