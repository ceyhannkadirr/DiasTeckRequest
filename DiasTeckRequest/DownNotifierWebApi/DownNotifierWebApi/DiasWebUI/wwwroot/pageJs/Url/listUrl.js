$(document).ready(async function () {

    let apiUrl = "https://localhost:44355/UserUrls/GetList";
    // let apiUrl = "https://localhost:44355/UserUrls/GetById?id=" + 1;
    await Lib.getJSON(apiUrl, urlFetched);
    function urlFetched(result) {
        console.log(result);

        result.map((x) => {

            let trHtml = `<tr> <td>${x?.id}</td> <td>${x.name}</td><td>${x?.value}</td>  <td> <a href='/Url/EditUrl?id=${x?.id}' class ='btn btn-success' >Güncelle</a></td> <td> <a href='javascript:void(0)' onclick='deleteUrl(${x?.id})' class ='btn btn-danger' >Sil</a></td></tr>`;
            
            $('#urlList').append(trHtml);

        });

    }

});