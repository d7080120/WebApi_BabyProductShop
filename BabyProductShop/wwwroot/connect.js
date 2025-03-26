let user = {}
const load = () => {
    const firstName = document.querySelector("#firstName");
    const jsonUser = localStorage.getItem("user");
    user = JSON.parse(jsonUser);
    firstName.innerHTML = user.firstName;
}
const update = async () => {
    console.log("e")
    const newUser = {
        Username: document.querySelector("#uusername").value,
        Password: document.querySelector("#upassword").value,
        FirstName: document.querySelector("#ufirstname").value,
        LastName: document.querySelector("#ulastname").value,
        UserId : user.userId
    };
    console.log(newUser)
    try {
        const response = await fetch(`api/Users/${user.userId}`, {
            method: 'PUT',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(newUser)
        })
        if (!response.ok)
            throw new Error("Error reciving data from server")
        alert('succsess update user')


    }
    catch (e) {
        console.log(e)
    }
}


window.onload = load;



