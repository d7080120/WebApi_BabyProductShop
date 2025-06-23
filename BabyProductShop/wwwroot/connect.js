

let user = {};

function showToast(message, type = "info", duration = 6000) {
    const toast = document.getElementById("toast");
    toast.innerHTML = message;
    toast.className = "toast " + type + " show";
    setTimeout(() => {
        toast.className = "toast " + type;
    }, duration);
}

function isValidEmail(email) {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
}

const load = () => {
    const firstName = document.querySelector("#firstName");
    const jsonUser = localStorage.getItem("user");
    if (!jsonUser) {
        showToast("שגיאה: לא נמצא משתמש מחובר", "error");
        return;
    }
    user = JSON.parse(jsonUser);
    document.querySelector("#uusername").value = user.username;
    document.querySelector("#upassword").value = user.password;
    document.querySelector("#ufirstname").value = user.firstName;
    document.querySelector("#ulastname").value = user.lastName;
    firstName.innerHTML = user.firstName;
};

const update = async () => {
    const username = document.querySelector("#uusername").value.trim();
    const password = document.querySelector("#upassword").value;
    const firstName = document.querySelector("#ufirstname").value.trim();
    const lastName = document.querySelector("#ulastname").value.trim();

    // Validations
    const errors = [];
    if (!username) errors.push("יש להזין שם משתמש (אימייל)");
    else if (!isValidEmail(username)) errors.push("שם המשתמש חייב להיות כתובת אימייל תקינה");
    if (!password) errors.push("יש להזין סיסמה");
    else if (password.length < 6) errors.push("הסיסמה חייבת להכיל לפחות 6 תווים");
    if (!firstName) errors.push("יש להזין שם פרטי");
    if (!lastName) errors.push("יש להזין שם משפחה");

    if (errors.length > 0) {
        showToast(errors.join("<br>"), "error", 8000);
        return;
    }

    const newUser = {
        username,
        password,
        firstName,
        lastName,
        id: user.id
    };

    try {
        const response = await fetch(`api/Users/${user.id}`, {
            method: 'PUT',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(newUser)
        });
        if (!response.ok) {
            let msg = "עדכון נכשל.<br>סיבות אפשריות:<ul style='margin:0 1.2em;'>";
            msg += "<li>חסרים פרטים</li>";
            msg += "<li>הסיסמה לא מספיק חזקה</li>";
            msg += "<li>שם המשתמש כבר קיים</li>";
            msg += "<li>שם המשתמש צריך להיות כתובת אימייל תקינה</li>";
            msg += "</ul>";
            showToast(msg, "error", 9000);
            throw new Error("Error receiving data from server");
        }
        var jsonUser = await response.json();
        jsonUser = JSON.stringify(jsonUser);
        localStorage.setItem("user", jsonUser);
        load();
        showToast('הפרטים עודכנו בהצלחה', "success");
    }
    catch (e) {
        console.log(e);
    }
};

const updateDitels = () => {
    const buttonupdateDitels = document.querySelector("#ButtonupdateDitels");
    const updateDitels = document.querySelector("#updateDitels");
    buttonupdateDitels.style.visibility = 'hidden';
    updateDitels.style.visibility = 'visible';
};

window.onload = load;


