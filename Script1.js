var BaseURL = "http://4dapps.net/KAShabakAPI/api/";
;
var GetProjectTBLs = function (serviceURL, parmtes, Sucsses, Erorr) {
    var URL = BaseURL + serviceURL;
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URL,
        "method": "GET",
        "headers": {
            "cache-control": "no-cache"
        }
    };

    $.ajax(settings).done(function (response) {
        Sucsses(response);
        console.log(response);
    })
        .fail(function (data) {
            Erorr(response);
        });
};
//----------------------------------------------------------------------------------------------


var parmtes = {
    id: 0,
    name: ""

};

GetProjectTBLs("ProjectTBLs/GetProjectTBLs", parmtes, sFun, errorfun);
var sFun = function (data) {


};
var errorfun = function (erorrdata) {


};