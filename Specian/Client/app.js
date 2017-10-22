/* global $http */

var app = angular.module('personList', []);

app.controller('TabController', function () {
    /*
     * this.tab = 1; //default value for list of persons
     * this.tab = 2; //person detail
     */
    this.tab = tab; //default value for list of persons
    this.changeTab = function (value)
    {
        if (value > 0)
        {
            this.tab = value;
        } else
        {
            this.tab = 1;
        }
    }
});


app.controller('PersonController', function ($scope, $http) {
    
    $http.get("http://localhost:62175/api/PersonApi")
            .then(function (response) {
                $scope.persons = response.data;
                //alert(JSON.stringify(response.data));
            });

    this.actualPerson = [];
    this.groups = groups;
    this.personDetail = function (id) {
        
        $http.get("http://localhost:62175/api/PersonApi/" + id)
            .then(function (response) {
                $scope.personForEdit = response.data;
            });
        
    };



    //via RFC Guid Gerenator
    this.generateId = function () { // Public Domain/MIT
        var d = new Date().getTime();
        if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
            d += performance.now(); //use high-precision timer if available
        }
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    }
    this.newPerson =
            {
                id: 0,
                firstName: 'New',
                lastName: "New",
                groups: ["Group1", "Group2", "Group3"]
            };
    this.addPerson = function ()
    {
        
        this.newPerson = [];
        this.newPerson =
                {
                    id: 0,
                    firstName: 'New next',
                    lastName: "New",
                    groups: ["Group1s", "Group2", "Group3"]
                };

        this.newPerson.firstName = $scope.firstName;
        this.newPerson.lastName = $scope.lastName;
        this.newPerson.id = this.generateId();
        
        //post request
        $http.post("http://localhost:62175/api/PersonApi", this.newPerson, {headers: {'Content-Type': 'application/json'}})
                .then(function (response) {
                    return response;
                });
        $scope.$apply();
        //alert(JSON.stringify(this.newPerson));

    };
});

app.controller('PersonFindController', function () {

    this.findInput = findWord;

});

var findWord = "";
var tab = 1;

var groups = [
    "group1",
    "group2",
    "group3",
];


var people = [

    {
        id: 1,
        firstName: 'Anna',
        lastName: "Karenina",
        groups: ["Group1", "Group2", "Group3"]
    },
    {
        id: 2,
        firstName: 'Petr',
        lastName: "Nový",
        groups: ["Group1", "Group2", "Group3"]
    },
    {
        id: 3,
        firstName: 'Jaroslav',
        lastName: "Škoda",
        groups: ["Group1", "Group2"]
    },
    {
        id: 4,
        firstName: 'Antonín',
        lastName: "Dvořák",
        groups: ["Group1", "Group2", "Group3"]
    },
    {
        id: 5,
        firstName: 'Petr',
        lastName: "Novotný",
        groups: ["Group1", "Group2", "Group3"]
    },
    {
        id: 6,
        firstName: 'Libor',
        lastName: "Souček",
        groups: ["Group1", "Group2"]
    },
];