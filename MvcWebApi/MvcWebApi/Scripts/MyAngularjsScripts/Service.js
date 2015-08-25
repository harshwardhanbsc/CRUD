app.service('CRUD_OperService', function ($http) {

    //Create new record  
    this.post = function (Student) {
        var request = $http({
            method: "post",
            url: "/api/StudentsAPI",
            data: Student
        });
        return request;
    }

    //Get Single Records  
    this.get = function (studentID) {
        return $http.get("/api/StudentsAPI/" + studentID);
    }

    //Get All Student  
    this.getAllStudent = function () {
        return $http.get("/api/StudentsAPI");
    }

    //Update the Record  
    this.put = function (studentID, Student) {
        var request = $http({
            method: "put",
            url: "/api/StudentsAPI/" + studentID,
            data: Student
        });
        return request;
    }

    //Delete the Record  
    this.delete = function (studentID) {
        var request = $http({
            method: "delete",
            url: "/api/StudentsAPI/" + studentID
        });
        return request;
    }
});