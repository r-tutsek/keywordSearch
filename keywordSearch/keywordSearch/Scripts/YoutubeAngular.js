var youtubeSearchModule = angular.module("YoutubeSearchApp", []);

youtubeSearchModule.controller("YoutubeSearchController", function ($scope, $http) {
    $scope.btnPostCall = function () {
        var dataToSend = { "Keyword": $scope.youtubeSearch, "NamespaceName": "keywordSearchService", "ClassName": "YoutubeSearchLogService", "MethodName": "AddLog" }
        $http.post("/api/YoutubeApi/SearchAsyncPost", dataToSend).then(function (success) {
            if (success.status == 200) {
                $scope.BaseUrl = success.data.BaseUrl;
                $scope.ThumbnailDefaultImage = success.data.ThumbnailDefaultImage;
                $scope.ThumbnailUrl = success.data.ThumbnailUrl;
                $scope.YoutubeVideos = success.data.Videos;
                console.log(success.data);
            }
        });
    };
});
