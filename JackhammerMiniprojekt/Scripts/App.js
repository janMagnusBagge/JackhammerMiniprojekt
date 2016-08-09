(function () {

    var QuestionApp = angular.module('myApp', []);


    QuestionApp.controller("PunctuationController", function ($scope) {

        $scope.score = 0;
        $scope.originalText;

        var testString = "Hej?!";
        var testArray = testString.split("");

        $scope.checkAnswer = function () {

            // kolla om userInput är samma som orginalsträngen,
            // om den är det, returnera true, annars false
        };

    });
})();