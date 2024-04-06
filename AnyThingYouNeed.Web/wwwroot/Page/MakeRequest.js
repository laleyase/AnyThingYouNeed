$(document).ready(function () {
    var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    $("#PhoneNumber").on("input", function () {
        var phoneNumber1 = document.getElementById('PhoneNumber');
        var numericPattern = /^[0-9]+$/;

        var phoneNumber = phoneNumber1.value.replace(/\D/g, '');
        if (phoneNumber.length > 0) {
            var formattedPhoneNumber = '(' + phoneNumber.substring(0, 3) + ') ' +
                phoneNumber.substring(3, 6) + '-' +
                phoneNumber.substring(6, 10);
            phoneNumber1.value = formattedPhoneNumber;
        }
        var phoneNumber2 = phoneNumber1.value.replace('(', '').replace(')', '').replace('-', '').replace(' ', '');
        if (!numericPattern.test(phoneNumber2)) {
            document.getElementById('phone-error-message').textContent = 'Telefon numarası sadece rakamlardan oluşmalıdır.';
            return;
        } else {
            document.getElementById('phone-error-message').textContent = '';
        }
    })
    $("#EMail").on("input", function () {
        var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        var eMail = document.getElementById('EMail');
        var email = eMail.value.trim();
        var formattedEmail = email.toLowerCase();


        if (!emailPattern.test(formattedEmail)) {
            document.getElementById('email-error-message').textContent = 'Geçersiz e-posta adresi!';
        } else {
            document.getElementById('email-error-message').textContent = '';
        }
    })
    function getCheckboxValue(item) {
        var checkBox = document.getElementById(item);
        var isChecked = checkBox.checked;

        if (isChecked) {
            return true
        } else {
            return false
        }
    }
    $("#MakeRequest").click(function () {
        var name = document.getElementById("name").value;
        var sureName = document.getElementById("surname").value;
        var phoneNumber = document.getElementById("PhoneNumber").value;
        var phoneNumber2 = phoneNumber.replace('(', '').replace(')', '').replace('-', '').replace(' ', '');
        var roomNumber = document.getElementById("RoomNumber").value;
        var hair = getCheckboxValue("Hair");
        var skin = getCheckboxValue("Skin");
        var teeth = getCheckboxValue("Teeth");
        var taxi = getCheckboxValue("Taxi");
        var vip = getCheckboxValue("Vip");
        var phone = getCheckboxValue("Phone");
        var pc = getCheckboxValue("Pc");
        var pcpOther = getCheckboxValue("PcpOther");
        var traditionalProduct = getCheckboxValue("TraditionalProduct");
        var tpOther = getCheckboxValue("TpOther");
        var tpOtherDetail = document.getElementById("TpOtherDetail").value;
        var message = document.getElementById("message").value;
        var istanbulTour = getCheckboxValue("IstanbuTour");
        var otherPcpDetail = document.getElementById("PcpOtherDetail").value;



        var numericPattern = /^[0-9]+$/;
        var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!numericPattern.test(phoneNumber2)) {
            alert = 'Telefon numarası sadece rakamlardan oluşmalıdır.';
        }
        var eMail = document.getElementById("EMail").value;

        var numericPattern = /^[0-9]+$/;

        var email = eMail.trim();
        var formattedEmail = email.toLowerCase();
        var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!emailPattern.test(formattedEmail)) {
            emailInput.value = formattedEmail;
            alert = 'Geçersiz e-posta adresi!';
        }

        var requestModel = {
            Name: name,
            Surname: sureName,
            PhoneNumber: phoneNumber2,
            EMail: eMail,
            RoomNumber: roomNumber,
            Hair: hair,
            Skin: skin,
            Teeth: teeth,
            Taxi: taxi,
            VipCar: vip,
            MobilePhone: phone,
            LaptopCharger: pc,
            PcpOther: pcpOther,
            TraditionalProduct: traditionalProduct,
            TpOther: tpOther,
            TpOtherDetail: tpOtherDetail,
            DetailsAndOthers: message,
            IstanbulTour: istanbulTour,
            OtherPcpDetail: otherPcpDetail,
        };
        $.ajax({
            url: "/Home/MakeRequest",
            type: "POST",
            data: JSON.stringify(requestModel),
            contentType: "application/json",
            dataType: "json",
            success: function (response) {
                alert(response);
            },
            error: function (response) {
                console.log(response);

                alert("hata " + response);

            }
        });
    });
});
