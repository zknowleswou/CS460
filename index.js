console.log("test");

//Global variables are bad
var profileCards = [
    {
        fileName: "./images/portugal2.jpg",
        description: "This day I was in Vianna Do Castelo enjoying some sun with my German friend."
    },
    {
        fileName: "./images/sanfrancisco.jpg",
        description: "This day I got married in San Francisco."
    },
    {
        fileName: "./images/japan.jpg",
        description: "This day I discovered I am too big for Japan."
    },
    {
        fileName: "./images/newzealand.jpg",
        description: "This day I was blinded by the sun in New Zealand."
    },
    {
        fileName: "./images/portugal.jpg",
        description: "This day I ate a tasty steak in Porto, Portugal."
    },
    {
        fileName: "./images/austria.jpg",
        description: "This day I saw an incredible palace in Vienna, Austria."
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