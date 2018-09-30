window.onbeforeunload = confirmExit;
function confirmExit() {
    return "Have you exported your current work?";
}

$(document).ready(function () {
    //Hide initial sections
    $("#rawPanel").hide();
    $("#importExportPanel").hide();

    $("#rawBtn").on("click", function () {
        $("#buildPanel").hide();
        $("#buildBtn").removeClass("active");

        $("#rawPanel").show();
        $("#rawBtn").addClass("active");

        $("#importExportPanel").hide();
        $("#importExportBtn").removeClass("active");

        elementBuilder.generateRawOutput();
    });

    $("#buildBtn").on("click", function () {
        $("#buildPanel").show();
        $("#buildBtn").addClass("active");

        $("#rawPanel").hide();
        $("#rawBtn").removeClass("active");

        $("#importExportPanel").hide();
        $("#importExportBtn").removeClass("active");

    })

    $("#importExportBtn").on("click", function () {
        $("#importExportPanel").show();
        $("#importExportBtn").addClass("active");

        $("#rawPanel").hide();
        $("#rawBtn").removeClass("active");

        $("#buildPanel").hide();
        $("#buildBtn").removeClass("active");
    })

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
    $("#exportBtn").on("click", function () {
        elementStore.exportWorkspace();
    });
    $("#importBtn").on("click", function () {
        elementStore.importWorkspace();
    })
});