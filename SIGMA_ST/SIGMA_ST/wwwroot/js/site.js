// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#danger").change( function () {
    if ($('#danger').is(':checked')) { 
        $('#in3').height('300px');
      $('#in2').removeAttr('hidden');
  } else {
        $('#in2').attr('hidden', 'hidden');
        $('#in3').height('200px');
  }
});