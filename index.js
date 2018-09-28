console.log("test");

//Global variables are bad
var profileCards = [
    {
        fileName: "Zach1-min.jpg",
        description: "This day I was in Vianna Do Castelo enjoying some sun with my German friend."
    }
];

$(document).ready(function () {
    var profileCard = profileCards[getRandomInt(0, profileCards.length - 1)]
    
});

//From Mozilla
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}