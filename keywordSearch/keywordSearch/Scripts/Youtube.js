$(document).ready(function () {
    var baseUrl;
    var thumbnailUrl;
    var thumbnailDefaultImage;
    $(document).on("click", "#youtubeSearchBtn", function () {
        searchYoutubeVideo();
    });
    $(document).on("keyup", function (event) {
        if (event.keyCode == 13) {
            searchYoutubeVideo();
        }
    });
    $(document).on("mouseenter", ".youtubeThumbnailImageHolder", function () {
        $(".youtubeThumbnailImageBlanker").hide();
        $(this).find(".youtubeThumbnailImageBlanker").show();
    });
    $(document).on("mouseleave", ".youtubeThumbnailImageHolder", function () {
        $(".youtubeThumbnailImageBlanker").hide();
    });
    $(document).on("click", ".youtubeThumbnailImageBlanker", function () {
        var videoId = $(this).data("video-id");
        if (typeof videoId != "undefined" && videoId != "") {
            showVideoModal(videoId);
        }
    });
    $(document).on("hidden.bs.modal", function (event) {
        if (event.target.id == "youtubeVideoModal") {
            $("#youtubeVideoFrame").attr("src", "");
        }
    });
    function searchYoutubeVideo() {
        var keyword = $("#youtubeSearchInput").val();
        if (typeof keyword != "undefined" && keyword != "") {
            var dataToSend = { "Keyword": keyword, "NamespaceName": "keywordSearchService", "ClassName": "YoutubeSearchLogService", "MethodName": "AddLog" };
            $.ajax({
                url: "/api/YoutubeApi/SearchAsyncPost",
                type: "POST",
                data: JSON.stringify(dataToSend),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function (xhr, data) {
                    $("#youtubeSearchResults").html("Searching please wait...");
                    $("#youtubeSearchInput").attr("disabled", true);
                    $("#youtubeSearchBtn").attr("disabled", true);
                },
                success: function (data) {
                    if (data.Videos != null) {
                        baseUrl = data.BaseUrl;
                        thumbnailUrl = data.ThumbnailUrl;
                        thumbnailDefaultImage = data.ThumbnailDefaultImage;

                        $("#youtubeSearchResults").html("");
                        $.each(data.Videos, function (index, obj) {
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
    }
    function getVideoStruct(videoId, videoTitle, videoDescription) {
        if (typeof videoTitle == "undefined" || videoTitle == "") {
            videoTitle = "No title set";
        }
        if (typeof videoDescription == "undefined" || videoDescription == "") {
            videoDescription = "No description set...";
        }
        var struct = '';
        struct += '<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 youtubeThumbnailImageContainer">';
        struct += '<div class="youtubeThumbnailImageHolder">';
        struct += '<div id="youtubeThumbnailImageBlanker" class="youtubeThumbnailImageBlanker" style="display:none;" data-video-id="'+videoId+'"><i class="fa fa-youtube-play youtubePlayIcon" aria-hidden="true"></i></div>';
        struct += '<img src="' + thumbnailUrl + '/' + videoId + '/' + thumbnailDefaultImage + '" class="youtubeThumbnailImage"/>';
        struct += '<div class="youtubeVideoTitle" title="' + videoTitle + '">' + videoTitle + '</div>';
        struct += '<div class="youtubeVideoDescription">' + videoDescription + '</div>';
        struct += '</div>';
        struct += '</div>';
        return struct;
    }
    function showVideoModal(videoId) {
        $("#youtubeVideoFrame").attr("src", baseUrl + "/" + videoId +"?autoplay=1&showinfo=0&controls=0&rel=0");
        $("#youtubeVideoModal").modal("show");
    }
});