
//Make sure the user does not accidentally leave the page and lose their work
window.onbeforeunload = confirmExit;
function confirmExit() {
    return "Have you exported your current work?";
}

//When the document attach a bunch of event handlers
$(document).ready(function () {
    //Hide initial sections
    $("#rawPanel").hide();
    $("#importExportPanel").hide();

    //Raw tab click
    $("#rawBtn").on("click", function () {
        $("#buildPanel").hide();
        $("#buildBtn").removeClass("active");

        $("#rawPanel").show();
        $("#rawBtn").addClass("active");

        $("#importExportPanel").hide();
        $("#importExportBtn").removeClass("active");

        //Regenerate the raw output in case there are any changes
        elementBuilder.generateRawOutput();
    });

    //Build tab click
    $("#buildBtn").on("click", function () {
        $("#buildPanel").show();
        $("#buildBtn").addClass("active");

        $("#rawPanel").hide();
        $("#rawBtn").removeClass("active");

        $("#importExportPanel").hide();
        $("#importExportBtn").removeClass("active");

    })

    //Import/export tab click
    $("#importExportBtn").on("click", function () {
        $("#importExportPanel").show();
        $("#importExportBtn").addClass("active");

        $("#rawPanel").hide();
        $("#rawBtn").removeClass("active");

        $("#buildPanel").hide();
        $("#buildBtn").removeClass("active");
    })

    //Wire up the builder buttons
    $("#createHeaderBtn").on("click", function () {
        elementBuilder.createHeader();
    });
    $("#createParagraphBtn").on("click", function () {
        elementBuilder.createParagraph();
    });
    $("#createCodeBlockBtn").on("click", function () {
        elementBuilder.createCodeBlock();
    });
    $("#createImageBtn").on("click", function () {
        elementBuilder.createImage();
    });

    //Wire up the import/export buttons
    $("#exportBtn").on("click", function () {
        elementStore.exportWorkspace();
    });
    $("#importBtn").on("click", function () {
        elementStore.importWorkspace();
    })
});