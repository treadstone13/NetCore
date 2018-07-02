// Write your JavaScript code.

$(document).ready(function () {
    $('#AddStudent').on('click', function () {
        $("#studentAddModal").modal();
    })
})
$(document).ready(function () {
    $('.updateS').on('click', function () {
        var bid = $(this).closest('td').parent();
        //console.log(bid);
        document.getElementById('StudentID').value = bid[0].firstElementChild.innerHTML;
        $("#studentUpdateModal").modal();
    })
})  

$(document).ready(function () {
    $('#AddCourse').on('click', function () {
        $("#courseAddModal").modal();
    })
})

$(document).ready(function () {
    $('.updateC').on('click', function () {
        var bid = $(this).closest('td').parent();
        //console.log(bid);
        document.getElementById('CourseID').value = bid[0].firstElementChild.innerHTML;
        $("#courseUpdateModal").modal();
    })
})  

$(document).ready(function () {
    $('#AddUserRole').on('click', function () {
        $("#userAddModal").modal();
    })
})

$(document).ready(function () {
    $('.updateR').on('click', function () {
        var bid = $(this).closest('td').parent();
        //console.log(bid);
        document.getElementById('RoleID').value = bid[0].firstElementChild.innerHTML;
        $("#roleUpdateModal").modal();
    })
})

$(document).ready(function () {
    $('#AddUser').on('click', function () {
        $("#userAddModal").modal();
    })
})

$(document).ready(function () {
    $('.updateU').on('click', function () {
        var bid = $(this).closest('td').parent();
        //console.log(bid);
        document.getElementById('UserID').value = bid[0].firstElementChild.innerHTML;
        $("#userUpdateModal").modal();
    })
})