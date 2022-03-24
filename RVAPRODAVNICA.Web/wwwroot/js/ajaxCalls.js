function TableSearch(dataObject, url, pageNumber, rowsPerPage) {

    var data = { "pageNumber": pageNumber, "rowsPerPage": rowsPerPage }

    $.ajax({

        method: "GET",
        url: url,
        data: data,
        success: function (response) {
            var len = $(response).find('.counter-rows').length;
            //alert(len)
            if (len != null && len > 0) {
                dataObject.append(response);
                $(".row-helper").fadeIn("slow");
            }
        },
        error: function () {
            //alert(errorText)
        }
    })
}