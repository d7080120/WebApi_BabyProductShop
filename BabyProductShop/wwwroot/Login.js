﻿const querySelector = (selector) => document.querySelector(selector)?.value.trim() || "";

const login = async () => {
    const loginUser = {
        Username: document.querySelector("#loginUsername").value,
        Password: document.querySelector("#loginPassword").value,
    }
    console.log(loginUser)
    try {
        const response = await fetch('http://localhost:5155/api/Users/login', {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(loginUser)
        })
        if (!response.ok) {
            alert('username or password is not valid')
            throw new Error("Error reciving data from server")
        }
        var jsonUser = await response.json();
        jsonUser = JSON.stringify(jsonUser);
        localStorage.setItem("user", jsonUser);
        window.location.href = './connect.html'


    } catch (e) {
        console.log(e)
    }
}
const register = async () => {
    //const UserName = document.querySelector("#rusername").value;
    const newUser = {
        Username: document.querySelector("#rusername").value,
        Password: document.querySelector("#rpassword").value,
        FirstName: document.querySelector("#rfirstname").value,
        LastName: document.querySelector("#rlastname").value,
    };
    console.log(newUser)

    try {
        const response = await fetch('http://localhost:5155/api/Users', {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(newUser)
        })
        if (!response.ok)
            throw new Error("Error reciving data from server")
        alert('succsess add user')
        
    }
    catch (e) {
        console.log(e)
    }
}
const powerpassword = async (type) => {
    const password = type == `login` ? document.querySelector("#loginPassword").value : document.querySelector("#rpassword").value
    const response = await fetch(`api/Passwords`, {
        method: 'POST',
        headers: { "Content-Type": 'application/json' },
        body: JSON.stringify(password)
    })
    if (!response.ok)
        throw new Error("Error reciving data from server")
    power=await response.json()
    alert(power)
}
