
var timer_manage = setInterval(function () {
    if (document.getElementById('results') != null) {
        $.ajax({
            url: "/Book/List",
            type: "POST",
            cache: false,
            success: function (data) {
                document.getElementById('results').innerHTML = data;
            }
        }
        );
    }
    }, 10000);

var timer_alerts = setInterval(function () {
    if (document.getElementById('results_u') != null) {
        $.ajax({
            url: "/Alert/List",
            type: "POST",
            cache: false,
            success: function (data) {
                document.getElementById('results_u').innerHTML = data;
            }
        });
    }
    }, 10000);

function BookAcceptDenide(id, method, nameId, controller) {
    $.ajax({
        url: '/' + controller + '/' + method,
        data: { 'id': id },
        type: 'POST',
        cache: false,
        success: function (data) {
            document.getElementById(nameId).remove();
        }
    });

}