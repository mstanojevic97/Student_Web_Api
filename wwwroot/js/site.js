// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function AddCourse() {
    debugger
    var objData = {
        Id : 1,
        Code : $('#Code').val(),
        Name : $('#Name').val(),
        Description : $('#Description').val()
    }
    $.ajax({
        method: "POST",
        url: '/Home/AddCourse',
        data: { course: objData },
        success: function () {
            alert('Course Added!');
            $('#courseModal').modal('toggle');
            $('#tableContainer').load('Home/GetTablePartial');
        },
        error: function () {
            alert("Course can't be saved!");
        }
    })
}
function AddStudent() {
    var objData = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Address: $('#Address').val(),
        City: $('#City').val(),
        State: $('#State').val(),
        DateBirth: $('#DateOfBirth').val(),
        Sex: $('#Gender').val()
    }
    $.ajax({
        method: "POST",
        url: '/Home/AddStudent',
        data: { student: objData },
        success: function () {
            alert('Student Added!');
            $('#studentModal').modal('toggle');
            $('#tableContainer').load('Home/GetTablePartial');
        },
        error: function () {
            alert("Student can't be saved!");
        }
    })
}

function search() {
    const student = $('#searchStudentInput').val();
    const course = $('#searchCourseInput').val();
    $('#tableContainer').load('Home/GetTablePartial?student=' + student.replace(' ', '%20') + '&course=' + course.replace(' ', '%20'));
}