var youtubeSearchModule = angular.module("YoutubeSearchApp", []);

youtubeSearchModule.controller("YoutubeSearchController", function ($scope, $http) {

    var dataUrl = "/api/YoutubeApi/SearchAsyncPost";
    var dataToPost = { "Keyword": "", "NamespaceName": "keywordSearchService", "ClassName": "YoutubeSearchLogService", "MethodName": "AddLog" };

    $scope.btnPostCall = function () {
        postData(dataUrl, dataToPost);
    };
    $scope.onSearchValKeyup = function (event) {
        if (event.keyCode == 13) {
            dataToPost["Keyword"] = $scope.youtubeSearchVal;
            postData(dataUrl, dataToPost);
        }
    };
    $scope.onThumbnailImageMouseenter = function (event) {
        $scope.youtubeThumbnailImageBlankerShow = false;
        angular.element(event.currentTarget).find(".youtubeThumbnailImageBlanker").scope().youtubeThumbnailImageBlankerShow = true;
    };
    $scope.onThumbnailImageMouseleave = function () {
        $scope.youtubeThumbnailImageBlankerShow = false;
        angular.element(event.currentTarget).find(".youtubeThumbnailImageBlanker").scope().youtubeThumbnailImageBlankerShow = false;
    };
    $scope.showVideoModal = function (event) {
        var videoId = angular.element(event.target).closest(".youtubeThumbnailImageHolder").data('video-id');
        if (videoId) {
            var additionalParams = "?controls=0&autoplay=1&showinfo=0&rel=0";
            angular.element("#youtubeVideoFrame").attr("src", $scope.BaseUrl + "/" + videoId + additionalParams);
            angular.element("#youtubeVideoModal").modal("show");
        }      
    };
    angular.element("#youtubeVideoModal").on("hidden.bs.modal", function () {
        angular.element("#youtubeVideoFrame").attr("src", "");
    });
    function postData(url, dataToPost) {
        dataToPost["Keyword"] = $scope.youtubeSearchVal;
        $http.post(url, dataToPost).then(function (success) {
            if (success.status == 200) {
                $scope.BaseUrl = success.data.BaseUrl;
                $scope.ThumbnailDefaultImage = success.data.ThumbnailDefaultImage;
                $scope.ThumbnailUrl = success.data.ThumbnailUrl;
                $scope.YoutubeVideos = success.data.Videos;
            }
        });
    }
});
