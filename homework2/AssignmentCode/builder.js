var elementBuilder = {
    createHeader: function () {
        var elementId = elementStore.createElement("header");
        var html = `
    <div id="element_${elementId}" class="card">
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Heading</h6>
                <textarea id="element_${elementId}_val" style="width:100%;"></textarea>
            </div>
        </div>
    `;

        $("#buildElementList").append(html);
    },
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
    },
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
    },
    generateRawOutput: function () {
        var rawOutput = $("#rawOutput");
        rawOutput.html("");

        elementStore.elements.forEach(element => {
            var rawElement;
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

            }
            rawOutput.append(document.createTextNode(rawElement));
            rawOutput.append("\n");
        });
    },
    formatCodeBlock: function(codeBlock){
        var formattedBlock = codeBlock;
        formattedBlock = formattedBlock.replace(/</g, "&lt;");
        formattedBlock = formattedBlock.replace(/>/g, "&gt;");
        return formattedBlock;
    }
};