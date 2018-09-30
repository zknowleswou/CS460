$(document).ready(function(){
    //Hide initial sections
    $("#rawPanel").hide();

    $("#rawBtn").on("click", function(){
        console.log("rawBtn");
        $("#buildPanel").hide();
        $("#rawPanel").show();
        elementBuilder.generateRawOutput();
    });

    $("#createHeaderBtn").on("click", function(){
        elementBuilder.createHeader();
    });
    $("#createParagraphBtn").on("click", function(){
        elementBuilder.createParagraph();
    });
    $("#createCodeBlockBtn").on("click", function(){
        elementBuilder.createCodeBlock();
    });
});