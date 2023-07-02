$(document).ready(function () {
    $('Form').submit(function (event) {
        if (!$(this).valid()) {
            event.preventDefault(); // Prevent form submission
        }
    });
});
function cmDelete(url) {
    $.confirm({
        title: 'Confirmation',
        content: 'Are you sure you want to delete?',
        type: 'red',
        typeAnimated: true,
        buttons: {
            confirm: {
                text: 'Confirm',
                btnClass: 'btn-red',
                action: function () {
                    window.location.href = url;
                }
            },
            cancel: {
                text: 'Cancel',
                action: function () {
                }
            }
        }
    });
}