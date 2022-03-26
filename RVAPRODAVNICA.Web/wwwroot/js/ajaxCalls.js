function TableSearch(dataObject, url, pageNumber, rowsPerPage, search) {

    var data = { "pageNumber": pageNumber, "rowsPerPage": rowsPerPage, "search": search }

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
            
            if (pageNumber > 0) {

                $("#load-older").html("LOAD OLDER");
                $("#load-older").prop('disabled', false);
            } else {
                $("#load-older").html("NO MORE DATA");
                $("#load-older").prop('disabled', true);
            }

            if (len < 5) {

                $("#load-more").html("NO MORE DATA");
                $("#load-more").prop('disabled', true);
            } else {    
                $("#load-more").html("LOAD MORE");
                $("#load-more").prop('disabled', false);
            }



        },
        error: function () {
            //alert(errorText)
        }
    })
}