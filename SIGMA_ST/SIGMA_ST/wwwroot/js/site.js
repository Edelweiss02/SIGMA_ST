
window.addEventListener('DOMContentLoaded', () => {

    var liters = document.getElementById('in1')
    var cost = document.getElementById('test3301')
    var price = document.getElementById('ui1')

    liters.addEventListener('input', () => {
        cost.value = (liters.value * price.value).toFixed(2)
    })
})

$("#danger").change(function () {
    if ($('#danger').is(':checked')) {
        $('#in3').height('300px');
        $('#in2').removeAttr('hidden');
    } else {
        $('#in2').attr('hidden', 'hidden');
        $('#in3').height('200px');
    }
});


$("#danger12").change(function () {

    if ($('#danger12').is(':checked')) {
        var cost = document.getElementById('test3301')
        var idcard = document.getElementById('in5')
        var id = idcard.value
        $("#" + id).attr('selected', 'selected');
        var price = document.getElementById('ui2')
        cost.value = (cost.value - (price.value / 10)).toFixed(2)

    } else {
        var cost2 = document.getElementById('test3301')
        var price2 = document.getElementById('ui2')
        cost2.value = (parseFloat(cost2.value) + parseFloat((price2.value / 10))).toFixed(2)
    }
});

function myFunction(e) {
    var price99 = document.getElementById('ui99')
    var cost99 = document.getElementById('in98')
    cost99.value = price99.value
}

