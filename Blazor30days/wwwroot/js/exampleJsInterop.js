window.exampleJsFunctions = {
    focusElement: function (element) {
        element.focus();
    },
    testPromise: function () {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve('foo');
            }, 300);
        });
    },
    callDotNetAndPrintData: function (a, b) {
        DotNet.invokeMethodAsync('Blazor30days', 'Sum', 1, 2)
            .then(data => {
                console.log(data);
            });
    },
    callDotNetAndPrintData2: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync('Sum', 1, 3)
            .then(data => {
                console.log(data);
            });
    },
    setLocalStorageItem: function (key, value) {
        localStorage.setItem(key, value);
    },
    getLocalStorageItem: function (key) {
        return localStorage.getItem(key);
    }
};