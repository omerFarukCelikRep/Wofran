$(document).ready(function () {
    var degreeType = null;
    $("#degreeType").change(function () {
        degreeType = $(this).children("option:selected").val();
    });

    $("#addEducation").click(function () {
        var isCurrent = $("input[type='radio'][name='isCurrent']:checked").val();
        var id = $(this).data("datac");

        var degreeName = $("#degreeName").val();
        var schoolName = $("#schoolName").val();
        var country = $("#country").val();
        var state = $("#state").val();
        var city = $("#city").val();
        var startDate = $("#start-year").val();
        var completionDate = $("#completion-year").val();

        var education = {
            ID: id,
            IsCurrent: isCurrent,
            DegreeType: degreeType,
            DegreeName: degreeName,
            SchoolName: schoolName,
            Country: country,
            State: state,
            City: city,
            StartYear: startDate,
            CompletionYear: completionDate
        }

        $.ajax({
            type: "POST",
            url: "/JobSeeker/AddEducation",
            data: education,
            success: function (data) {
                $("#educationList").empty();
                $("#educationList").html(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    });


    $(".editEducation button").click(function () {
        var id = $(this).data("datac");
        $.ajax({
            type: "GET",
            url: "/JobSeeker/EditEducation/" + id,
            async:true,
            success: function (data) {
                if (data.isCurrent) {
                    $("input[type='radio'][name='isCurrent']").prop('checked', true);
                }

                $("#addEducation").data("datac", id);

                $("#degreeType").val(data.degreeType);
                $("#degreeName").val(data.degreeName);
                $("#schoolName").val(data.schoolName);
                $("#country").val(data.country);
                $("#state").val(data.state);
                $("#city").val(data.city);
                $("#start-year").val(data.startYear);
                $("#completion-year").val(data.completionYear);
            },
            error: function (data) {
                console.log(data);
            }
        })
    })

});