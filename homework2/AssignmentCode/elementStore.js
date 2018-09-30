var elementStore = {
    elements: [],
    createElement: function (elementType) {
        var newElement = {
            elementId: this.elements.length,
            type: elementType
        }

        this.elements.push(newElement);
        return newElement.elementId;
    },
    createElementArray: function () {
        var elementArray = [];
        this.elements.forEach(element => {
            elementArray.push({
                type: element.type,
                value: $(`#element_${element.elementId}_val`).val()
            });
        });

        return elementArray;
    },
    exportWorkspace: function () {
        var workspaceString = JSON.stringify(this.createElementArray());
        $("#importExportValue").val(workspaceString);
    },
    importWorkspace: function () {
        var importString = $("#importExportValue").val();
        if (importString.length === 0 || importString === "[]")
            return;

        $("#buildElementList").html("");    
        var workspace = JSON.parse(importString);

        this.elements = [];

        workspace.forEach(element => {
            var elementId = elementBuilder.createElement(element.type);
            $(`#element_${elementId}_val`).val(element.value);
        });

        $("#buildBtn").click();
    }
};