// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var file = document.getElementById('onlypdf');

file.onchange = function (e) {
    var ext = this.value.match(/\.([^\.]+)$/)[1];
    switch (ext) {
        case 'pdf':
            break;
        default:
            alert('Not allowed');
            this.value = '';
    }
};