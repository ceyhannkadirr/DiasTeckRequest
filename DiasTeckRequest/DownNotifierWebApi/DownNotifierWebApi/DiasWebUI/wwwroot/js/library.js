class Lib {


    /**
     * 
     * @param {any} url post edilecek URL
     * @param {any} dataObj javascript objesi, data içinde api nin istediği parametreler olmalıdır.
     * @param {any} callback success callback işlemi varsa yapılsın
     * @param {any} failcallback error callback işlemi varsa yapılsın
     * @param {any} isAsync Asenkron mu ? varsayılan true
     */
    static postJSON(url, dataObj, callback, failcallback = null) {
        var getRequiredHeaders = {
            'Access-Control-Allow-Origin': 'http://localhost:5000/',
            'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
            'Access-Control-Allow-Headers': 'X-Foo',
            'Access-Control-Max-Age': '3600',
            'Accept': 'application/json', 'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem('token') ?? '',
        };
        debugger;
        try {

            return $.ajax({
                headers: getRequiredHeaders,
                method: 'POST',
                dataType: 'json',
                url: url,
                async: true,
                data: JSON.stringify(dataObj),
                complete: function (result) {

                    if (result.status == 200) {
                        if (callback != null) {
                            callback(result);
                            return;
                        }
                        if (failcallback != null) {
                            failcallback(result);
                            return;
                        }
                    } else {
                        alert('Error Code = ' + result.status);
                    }
                },
                error: function (err) {
                    if (failcallback) failcallback(err);
                }
            });
        } catch (e) {
            console.log(e);
        }
    }

    static getJSON(url, callback, failcallback = null) {
        var getRequiredHeaders = {
            'Access-Control-Allow-Origin': 'http://localhost:5000/',
            'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
            'Access-Control-Allow-Headers': 'X-Foo',
            'Access-Control-Max-Age': '3600',
            'Accept': 'application/json', 'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem('token') ?? '',
        };
        return $.ajax({
            headers: getRequiredHeaders,
            method: 'GET',
            url: url,
            dataType: 'json',
            async: false,
            success: function (result) {


                if (callback != null) {
                    callback(result);
                    return;
                }

                if (failcallback != null) {
                    failcallback(result);
                    return;
                }
            },
            error: function (err) {
                if (failcallback) failcallback(err);
            }
        });

    }

    static deleteJSON(url, callback, failcallback = null, isAsync = true) {

        var getRequiredHeaders = {
            'Access-Control-Allow-Origin': 'http://localhost:5000/',
            'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
            'Access-Control-Allow-Headers': 'X-Foo',
            'Access-Control-Max-Age': '3600',
            'Accept': '*/*',
            'Authorization': 'Bearer ' + localStorage.getItem('token') ?? '',
        };

        return $.ajax({
            headers: this.getRequiredHeaders,
            method: 'DELETE',
            url: url,
            contentType: 'application/json',
            async: isAsync,
            complete: function (result) {

                if (callback != null) {
                    callback(result);
                    return;
                }
                if (failcallback != null) {
                    failcallback(result);
                    return;
                }
            },
            fail: function (err) {

                if (failcallback) failcallback(err);
            }
        });

    }

}