$(document).ready(function () {
    $(document).on("click", "#youtubeSearchBtn", function () {
        var searchQuery = $("#youtubeSearchInput").val();
        if (typeof searchQuery != "undefined" && searchQuery != "") {
            $.ajax({
                url: "/api/YoutubeApi/Search?queryStr=" + searchQuery,
                dataType:"json",
                beforeSend: function (xhr, data) {
                    $("#youtubeSearchResults").html("Searching please wait...");
                    $("#youtubeSearchInput").attr("disabled", true);
                    $("#youtubeSearchBtn").attr("disabled", true);
                },
                success: function (data) {
                    if (data != null) {
                        console.log(data);
                    }
                },
                complete: function (xht, data) {
                    $("#youtubeSearchInput").attr("disabled", false);
                    $("#youtubeSearchBtn").attr("disabled", false);
                }
            });
        }
    });
});