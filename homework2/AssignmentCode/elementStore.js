//Create a global singleton that can be accessed from anywhere
var elementStore = {
    //Initialize the elements collection
    elements: [],
    //Create a new element object and store it then return its id
    createElement: function (elementType) {
        //Create element
        var newElement = {
            elementId: this.elements.length,
            type: elementType
        }

        //Store element
        this.elements.push(newElement);

        //Return the created elements id
        return newElement.elementId;
    },
    //Create an array that represents our workspace includes the values
    createElementArray: function () {
        //Create new array
        var elementArray = [];

        //Iterate of the elements collection
        this.elements.forEach(element => {
            //Fetch the value of each element and add that and its type to the collection
            elementArray.push({
                type: element.type,
                value: $(`#element_${element.elementId}_val`).val()
            });
        });

        return elementArray;
    },
    //Create a JSON object that can later be imported
    exportWorkspace: function () {
        //Create an array that represents the current workspace and convert it to a JSON string
        var workspaceString = JSON.stringify(this.createElementArray());

        //Display the JSON string to the user
        $("#importExportValue").val(workspaceString);
    },
    //Import a JSON object and rebuild the workspace
    importWorkspace: function () {
        //Store the jQuery object because we need to use it a lot
        var importString = $("#importExportValue").val();

        //Do some simple error checking so we dont wipe the users work
        if (importString.length === 0 || importString === "[]")
            return;

        //Clear existing workspace
        this.elements = [];
        $("#buildElementList").html("");  
        
        //Convert the imported string to an object. If its not valid let it blow up.
        var workspace = JSON.parse(importString);

        //Iterate over the imported workspace's elements and build a new workspace
        workspace.forEach(element => {
            var elementId = elementBuilder.createElement(element.type);
            $(`#element_${elementId}_val`).val(element.value);
        });

        //Switch back over to the builder view
        $("#buildBtn").click();
    }
};