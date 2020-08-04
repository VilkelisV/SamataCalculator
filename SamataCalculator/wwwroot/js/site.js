// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    var rawData = [];
    var validData = [];
    var postData = {};

    function getFormData() {
        rawData = $('form').serializeArray();

        $(rawData).each(function (i, field) {
            if (field.value != "") validData.push(field)
        })
        console.log("nice")
    }

    function generateObjectFromValidData() {
        for (var i = 0; i <= validData.length - 1; i++) {
            var key = validData[i].name;
            postData[key] = validData[i].value;
        }
    }

    // send data to server
    $('#formBtn').click(function (e) {
        e.preventDefault();

        getFormData();
        generateObjectFromValidData();
        console.log(postData)


        $.ajax({
            url: '/Samata/GetData',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(postData),
            success: function (data) {
                $('#resultText').html(data.msg);
            },
            error: function () {
                console.log("error");
            }
        });

        validData = [];
        postData = {};
    });


    // Show/hide form elements
    $('.categorySelection').hide();
    $('.categorySelection').children().not("#jobTypeSelector").hide();

    $('#category').change(function () {
        var selectedCategory = $(this).children("option:selected").val();
        $("#" + selectedCategory).toggle();
    })

    $('.typeSelection').on("change", function () {
        for (var i = 0; i < $(this).children().length; i++) {
            var category = $(this).children().eq(i).val();
            $("#" + category).hide();
            clearPreviousInputs(category);
        }

        var selectedCategory = $(this).children("option:selected").val();
        $("#" + selectedCategory).toggle();
    })

    // clear previous data if new option selected
    function clearPreviousInputs(category) {
        for (var i = 0; i < $("#" + category).children().length; i++) {
            $("#" + category + " :input").each(function () {
                if ($(this).attr('type') == "number") {
                    $(this).val("");
                } else {
                    $(this).val("").change();

                }
            });


        }
    }

})
