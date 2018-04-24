$(document).ready(function () {
    var thumbnailUrl;
    var thumbnailDefaultImage;
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
                    if (data.videos != null) {
                        thumbnailUrl = data.thumbnailUrl;
                        thumbnailDefaultImage = data.thumbnailDefaultImage;
                        
                        $("#youtubeSearchResults").html("");
                        $.each(data.videos, function (index, obj) {
                            $("#youtubeSearchResults").append(getVideoStruct(obj.Id, obj.Title, obj.Description));
                        });
                    }
                },
                complete: function (xht, data) {
                    $("#youtubeSearchInput").attr("disabled", false);
                    $("#youtubeSearchBtn").attr("disabled", false);
                }
            });
        }
    });
    function getVideoStruct(videoId, videoTitle, videoDescription) {
        var struct = '';
        struct += '<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 youtubeThumbnailImageContainer">';
        struct += '<div class="youtubeThumbnailImageHolder">';
        struct += '<img src="' + thumbnailUrl + '/' + videoId + '/' + thumbnailDefaultImage + '" class="youtubeThumbnailImage"/>';
        struct += '<div class="youtubeVideoTitle" title="' + videoTitle+'">' + videoTitle + '</div>';
        struct += '</div>';
        struct += '</div>';
        console.log(struct);
        return struct;
    }
});