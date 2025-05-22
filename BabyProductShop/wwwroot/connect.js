
let user = {}
const load = () => {
    const firstName = document.querySelector("#firstName");
    const jsonUser = localStorage.getItem("user");
    const username = document.querySelector("#uusername");
    const password = document.querySelector("#upassword");
    const ufirstName = document.querySelector("#ufirstname");
    const lastName = document.querySelector("#ulastname");
    user = JSON.parse(jsonUser);
    username.value = user.username;
    password.value = user.password;
    ufirstName.value = user.firstName;
    lastName.value = user.lastName;
    firstName.innerHTML = user.firstName;
}
const update = async () => {
    console.log(user)
    const newUser = {
        Username: document.querySelector("#uusername").value,
        Password: document.querySelector("#upassword").value,
        FirstName: document.querySelector("#ufirstname").value,
        LastName: document.querySelector("#ulastname").value,
        Id : user.id
    };
    console.log(newUser)
    try {
        const response = await fetch(`api/Users/${user.id}`, {
            method: 'PUT',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(newUser)
        })
        if (!response.ok) {
            alert("filds are empty and the password must be stronger from 2 or username is existed")
            throw new Error("Error reciving data from server")
        }
        var jsonUser = await response.json();
        jsonUser = JSON.stringify(jsonUser);
        localStorage.setItem("user", jsonUser);
        load();
        alert('succsess update user')


    }
    catch (e) {
        console.log(e)
    }
}
const updateDitels = () => {
    const buttonupdateDitels = document.querySelector("#ButtonupdateDitels");
    const updateDitels = document.querySelector("#updateDitels");
    buttonupdateDitels.style.visibility = 'hidden';
    updateDitels.style.visibility = 'visible';
}


window.onload = load;



