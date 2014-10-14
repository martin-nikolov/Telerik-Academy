$(document).ready(function () {
    $('body #btn-event-leave').on('click', function () {
        var id = $('#event-id').html();

        $.ajax({
            url: '/events',
            method: 'PUT',
            data: {
                id: id
            },
            success: function (data) {
                console.log(data);
            },
            error: function (error) {
                console.log(error);
            }
        })
    });
});