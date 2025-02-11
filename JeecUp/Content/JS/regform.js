function SubmitForm() {
    // debugger;
    ///Get Form Data ///
    var name = $("#name").val();
    var fathername = $("#fathername").val();
    var mothername = $("#mothername").val();
    var dob = $("#dob").val();
    var gender = $("#gender").val();
    //var aadhaar = $(".adhar").val();
    var mobile = $("#mobile").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var confirmpassword = $("#confirmpassword").val();

    if (name == null || name == "") {
        Swal.fire({
            icon: "warning",
            title: "warning...",
            text: "Name is Required !"
        });
        return;
    }

    if (fathername == null || fathername == "") {
        Swal.fire({
            icon: "warning",
            title: "warning...",
            text: "father name is Required !"

        });
        return;
    }
    if (mothername == null || mothername == "") {
        Swal.fire({
            icon: "warning",
            title: "warning...",
            text: "mother name is Required !"

        });
        return;
    }


    $.ajax({
        url: '../Home/SaveRecord',
        type: 'POST',
        data: {
            Name: name, Father: fathername, Mother: mothername, DOB: dob, Gender: gender,
            Mobile: mobile, Email: email, Password: password, Cpwd: confirmpassword
        } // Key:value
        , success: function (response)
        {
            Swal.fire({
                icon: "success",
                title: response.Message,
                text: "Form Saved Successfully "

            });
        }

    });
}

//function validation(e) {
//    debugger;
//    var keycode = e.charCode || e.charCode;

//    if (keycode >= 48 && keycode <= 57) {
//        return true;
//    }
//    else {
//        Swal.fire({
//            icon: "warning",
//            title: "warning...",
//            text: "Not Valid Number !"

//        });
//        return false;
//    }
//}

