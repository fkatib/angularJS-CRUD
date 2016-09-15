function newsItemController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data
    $http.get('/api/NewsItem/').success(function (data) {
        $scope.newsItems = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading the news items!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.newsItem.editMode = !this.newsItem.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit
    $scope.save = function () {
        //alert("Edit");
        $scope.loading = true;
       // var newsItem = this.newsItem;
        //alert(emp);
        $http.put('/api/NewsItem/', this.newsItem).success(function (data) {
            alert("Saved Successfully!!");
            $scope.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while saving the news item! " + data;
            $scope.loading = false;

        });
    };

    $scope.reset = function () {
        $scope.newNewsItem.NewsItemText = '';
        $scope.newNewsItem.NewsItemDate = '';
        // Todo: Reset field to pristine state, its initial state!
    };

    //Used to add a new record
    $scope.add = function () {
        $scope.loading = true;
        if (angular.element('#dtp_input2').val())
        {
            $scope.newNewsItem.NewsItemDate = angular.element('#dtp_input2').val();
        }
        else
        {
            $scope.newNewsItem.NewsItemDate = new Date().toISOString().slice(0, 10);
        }
       
        $http.post('/api/NewsItem/', this.newNewsItem).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.newsItems.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while adding the news item! " + data;
            $scope.loading = false;

        });
        $scope.addMode = {};
    };

    //Used to edit a record
    $scope.deleteNewsItem = function () {
        $scope.loading = true;
        var newsItemId = this.newsItem.NewsItemId;
        $http.delete('/api/NewsItem/' + newsItemId).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.newsItems, function (i) {
                if ($scope.newsItems[i].NewsItemId === newsItemId) {
                    $scope.newsItems.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while saving the news item! " + data;
            $scope.loading = false;

        });
    };

}