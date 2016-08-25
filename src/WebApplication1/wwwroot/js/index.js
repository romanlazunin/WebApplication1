"use strict";

$(document).ready(function () {
    $("#btn_send").click(function () {
        var $this = $(this);
        if ($("#fields").css('display') == 'none') {
            $("#fields").removeClass('hidden');
            $this.value('Send new message');
        }
        else {
            $("#fields").addClass('hidden');
            $this.value('Send');
        }
    });
});