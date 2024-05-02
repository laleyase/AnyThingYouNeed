$(document).ready(function () {
    // Define patterns outside of event handlers to avoid re-declaring them multiple times
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const numericPattern = /^[0-9]+$/;

    // Helper function to format phone numbers
    function formatPhoneNumber(phone) {
        let cleaned = phone.replace(/\D/g, '');
        let formatted = '';
        if (cleaned.length >= 3) {
            formatted = `(${cleaned.substring(0, 3)}) `;
        }
        if (cleaned.length >= 6) {
            formatted += cleaned.substring(3, 6) + '-';
        }
        if (cleaned.length > 6) {
            formatted += cleaned.substring(6, 10);
        }
        return formatted;
    }

    // Helper function to check if a checkbox is checked
    function getCheckboxValue(id) {
        const checkbox = document.getElementById(id);
        return checkbox ? checkbox.checked : false;
    }

    // Phone number input event handler
    $("#PhoneNumber").on("input", function () {
        const phoneInput = $(this);
        const rawPhoneNumber = phoneInput.val().replace(/\D/g, '');

        // Format the phone number
        const formattedPhoneNumber = formatPhoneNumber(rawPhoneNumber);
        phoneInput.val(formattedPhoneNumber);

        const cleanedPhoneNumber = formattedPhoneNumber.replace(/\D/g, '');
        if (!numericPattern.test(cleanedPhoneNumber)) {
            $("#phone-error-message").text("Phone number is required and it must consist of numbers!");
        } else {
            $("#phone-error-message").text("");
        }
    });

    // Email input event handler
    $("#EMail").on("input", function () {
        const emailInput = $(this);
        const email = emailInput.val().trim().toLowerCase();

        if (!emailPattern.test(email)) {
            $("#email-error-message").text("Invalid e-mail address!");
        } else {
            $("#email-error-message").text("");
        }
    });

    // Button click event handler to make a request
    $("#MakeRequest").click(function () {
        // Get the values from input fields
        const name = $("#name").val();
        const surname = $("#surname").val();
        const phoneNumber = $("#PhoneNumber").val().replace(/\D/g, '');
        const email = $("#EMail").val().trim().toLowerCase();
        const roomNumber = $("#RoomNumber").val();
        const message = $("#message").val();

        // Get checkbox values
        const hair = getCheckboxValue("Hair");
        const skin = getCheckboxValue("Skin");
        const teeth = getCheckboxValue("Teeth");
        const taxi = getCheckboxValue("Taxi");
        const vip = getCheckboxValue("Vip");
        const phone = getCheckboxValue("Phone");
        const pc = getCheckboxValue("Pc");
        const pcpOther = getCheckboxValue("PcpOther");
        const traditionalProduct = getCheckboxValue("TraditionalProduct");
        const tpOther = getCheckboxValue("TpOther");
        const tpOtherDetail = $("#TpOtherDetail").val();
        const istanbulTour = getCheckboxValue("IstanbuTour");
        const otherPcpDetail = $("#PcpOtherDetail").val();

        // Validate the phone number and email
        if (!numericPattern.test(phoneNumber)) {
            alert("Phone number is required and it must consist of numbers!");
            return;
        }

        if (!emailPattern.test(email)) {
            alert("Invalid e-mail address!");
            return;
        }


        // Create the request model
        const requestModel = {
            Name: name,
            Surname: surname,
            PhoneNumber: phoneNumber,
            EMail: email,
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

    });

}); 

