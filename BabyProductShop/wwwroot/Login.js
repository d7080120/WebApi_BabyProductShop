//const querySelector = (selector) => document.querySelector(selector)?.value.trim() || "";

//const login = async () => {
//    const loginUser = {
//        username: document.querySelector("#loginUsername").value,
//        password: document.querySelector("#loginPassword").value,
//    }
//    console.log(loginUser)
//    try {
//        const response = await fetch(`api/Users/login`, {
//            method: 'POST',
//            headers: { "Content-Type": 'application/json' },
//            body: JSON.stringify(loginUser)
//        })
//        if (!response.ok) {
//            alert('username or password is not valid')
//            throw new Error("Error reciving data from server")
//        }
//        var jsonUser = await response.json();
//        jsonUser = JSON.stringify(jsonUser);
//        localStorage.setItem("user", jsonUser);
//        window.location.href = './connect.html'


//    } catch (e) {
//        console.log(e)
//    }
//}
//const register = async () => {
//    //const UserName = document.querySelector("#rusername").value;
//    const newUser = {
//        username: document.querySelector("#rusername").value,
//        password: document.querySelector("#rpassword").value,
//        firstName: document.querySelector("#rfirstname").value,
//        lastName: document.querySelector("#rlastname").value,
//    };
//    console.log(newUser)

//    try {
//        const response = await fetch(`api/Users`, {
//            method: 'POST',
//            headers: { "Content-Type": 'application/json' },
//            body: JSON.stringify(newUser)
//        })
//        if (!response.ok) {
//            alert ("filds are empty and the password must be stronger from 2 or username is existed")
//            throw new Error("Error reciving data from server")
//        }
//        alert('succsess add user')
        
//    }
//    catch (e) {
//        console.log(e)
//    }
//}
//const powerpassword = async (type) => {
//    const password = type == `update` ? document.querySelector("#upassword").value : document.querySelector("#rpassword").value
//    if (password == null) {
//        alert("0")
//        return;
//    }
//    const response = await fetch(`api/Passwords`, {
//        method: 'POST',
//        headers: { "Content-Type": 'application/json' },
//        body: JSON.stringify(password)
//    })
//    if (!response.ok) {
//        alert("0");
//        return;
//    }
//    power = await response.json()
//    alert(power)
//}
// --- Toasts ---
function showToast(message, type = "info", duration = 5000) {
    const toast = document.getElementById("toast");
    toast.innerHTML = message;
    toast.className = "toast " + type + " show";
    setTimeout(() => {
        toast.className = "toast " + type;
    }, duration);
}

// Email validation
function isValidEmail(email) {
    // Simple email regex
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
}

// --- Login ---
const login = async () => {
    const username = document.querySelector("#loginUsername").value.trim();
    const password = document.querySelector("#loginPassword").value;

    // Validation
    if (!username) {
        showToast("יש להזין שם משתמש (אימייל)", "error");
        return;
    }
    if (!isValidEmail(username)) {
        showToast("שם המשתמש חייב להיות כתובת אימייל תקינה", "error");
        return;
    }
    if (!password) {
        showToast("יש להזין סיסמה", "error");
        return;
    }

    const loginUser = { username, password };

    try {
        const response = await fetch(`api/Users/login`, {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(loginUser)
        });
        if (!response.ok) {
            showToast('שם המשתמש או הסיסמה שגויים', "error");
            throw new Error("Error reciving data from server");
        }
        var jsonUser = await response.json();
        jsonUser = JSON.stringify(jsonUser);
        localStorage.setItem("user", jsonUser);
        window.location.href = './connect.html';
    } catch (e) {
        console.log(e);
    }
};

// --- Register ---
const register = async () => {
    const username = document.querySelector("#rusername").value.trim();
    const password = document.querySelector("#rpassword").value;
    const firstName = document.querySelector("#rfirstname").value.trim();
    const lastName = document.querySelector("#rlastname").value.trim();

    // Collect errors
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

    const newUser = { username, password, firstName, lastName };
    try {
        const response = await fetch(`api/Users`, {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(newUser)
        });
        if (!response.ok) {
            // Try to get error from server, fallback to generic
            let errMsg = "הרשמה נכשלה.<br>סיבות אפשריות:<ul style='margin:0 1.2em;'>"
            errMsg += "<li>חסרים פרטים</li>";
            errMsg += "<li>הסיסמה לא מספיק חזקה</li>";
            errMsg += "<li>שם המשתמש כבר קיים</li>";
            errMsg += "<li>שם המשתמש צריך להיות כתובת אימייל תקינה</li>";
            errMsg += "</ul>";
            showToast(errMsg, "error", 9000);
            throw new Error("Error reciving data from server");
        }
        showToast('נרשמת בהצלחה! אפשר להתחבר', "success");
    }
    catch (e) {
        console.log(e);
    }
}

// --- Password strength (as before, with toast) ---
const powerpassword = async (type) => {
    const password = type === "update"
        ? document.querySelector("#upassword").value
        : document.querySelector("#rpassword").value;
    if (!password) {
        showToast("יש להזין סיסמה", "info");
        return;
    }
    const response = await fetch(`api/Passwords`, {
        method: 'POST',
        headers: { "Content-Type": 'application/json' },
        body: JSON.stringify(password)
    });
    if (!response.ok) {
        showToast("בעיה בבדיקת חוזק הסיסמה", "error");
        return;
    }
    const power = await response.json();
    showToast("חוזק הסיסמה: " + power, "info");
}