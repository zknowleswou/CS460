console.log("test");

//Global variables are bad
var profileCards = [
    {
        fileName: "./images/Zach1-min.jpg",
        description: "This day I was in Vianna Do Castelo enjoying some sun with my German friend."
    },
    {
        fileName: "./images/Zach2.jpg",
        description: "This day I got married in San Francisco."
    }
];

$(document).ready(function () {
    var profileCard = profileCards[getRandomInt(0, profileCards.length - 1)]
    $("#profileLocationDescription").text(profileCard.description);
    $("#profileImage").attr("src", profileCard.fileName);
});

//From Mozilla
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}