var elementStore = {
    elements: [],
    createElement: function(elementType) {
        var newElement = {
            elementId: this.elements.length,
            type: elementType
        }

        this.elements.push(newElement);
        console.log(newElement);
        return newElement.elementId;
    }
};