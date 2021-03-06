//Create a global singleton that can be accessed from anywhere
var elementBuilder = {
    createHeader: function () {
        //Store the element for later use so I can access its value
        var elementId = elementStore.createElement("header");
        var html = `
    <div id="element_${elementId}" class="card">
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Heading</h6>
                <textarea id="element_${elementId}_val" style="width:100%;"></textarea>
            </div>
        </div>
    `;
        //Add the element to the UI
        $("#buildElementList").append(html);

        //Focus the cursor on the element to save the user a click
        $(`#element_${elementId}_val`).focus();

        //Return the created elements ID for the importer
        return elementId;
    },
    //See above comments
    createParagraph: function () {
        var elementId = elementStore.createElement("paragraph");
        var html = `
    <div id="element_${elementId}" class="card">
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Paragraph</h6>
                <textarea id="element_${elementId}_val" style="width:100%;"></textarea>
            </div>
        </div>
    `;

        $("#buildElementList").append(html);
        $(`#element_${elementId}_val`).focus();
        return elementId;
    },
    //See above comments
    createCodeBlock: function () {
        var elementId = elementStore.createElement("codeBlock");
        var html = `
    <div id="element_${elementId}" class="card">
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Code Block</h6>
                <textarea id="element_${elementId}_val" style="width:100%;"></textarea>
            </div>
        </div>
    `;

        $("#buildElementList").append(html);
        $(`#element_${elementId}_val`).focus();
        return elementId;
    },
    //See above comments
    createImage: function () {
        var elementId = elementStore.createElement("image");
        var html = `
    <div id="element_${elementId}" class="card">
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Image</h6>
                <input type="text" id="element_${elementId}_val" style="width:100%;"/>
            </div>
        </div>
    `;

        $("#buildElementList").append(html);
        $(`#element_${elementId}_val`).focus();
        return elementId;
    },
    //A helper function that the element store uses on importing
    createElement: function (type) {
        switch (type) {
            case "header":
                return this.createHeader();
            case "paragraph":
                return this.createParagraph();
            case "codeBlock":
                return this.createCodeBlock();
            case "image":
                return this.createImage();
        }
    },
    //Generate raw HTML that can be copied into a HTML file
    generateRawOutput: function () {
        //Locate the div to display the raw html
        var rawOutput = $("#rawOutput");
        
        //Clear out any old values
        rawOutput.html("");

        //Iterate over all the elements the user has created
        elementStore.elements.forEach(element => {
            var rawElement;
            //Each element needs to to rendered differently
            //Go over each one and reder it correctly
            switch (element.type) {
                case "header":
                    rawElement = `<h4>${$(`#element_${element.elementId}_val`).val()}</h4>`;
                    break;
                case "paragraph":
                    rawElement = `<p>${$(`#element_${element.elementId}_val`).val()}</p>`;
                    break;
                case "codeBlock":
                    rawElement = `<div><pre><code>\n${this.formatCodeBlock($(`#element_${element.elementId}_val`).val())}\n</code></pre></div>`;
                    break;
                case "image":
                    rawElement = `<img src="./${$(`#element_${element.elementId}_val`).val()}" style="width:100%;"/>`;
                    break;

            }

            //Place the current elements raw HTML into the display div
            rawOutput.append(document.createTextNode(rawElement));
            
            //New lines make the raw HTML copy over nicer
            rawOutput.append("\n");
        });
    },
    //Don't make the user type out the codeblock symbols. 
    formatCodeBlock: function (codeBlock) {
        //Use regular expressions to replace all <'s and >'s
        var formattedBlock = codeBlock;
        formattedBlock = formattedBlock.replace(/</g, "&lt;");
        formattedBlock = formattedBlock.replace(/>/g, "&gt;");
        return formattedBlock;
    }
};