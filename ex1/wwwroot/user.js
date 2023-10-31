
const register = async () => {
    if (checkPassword()) {
        var user = {
            email: document.getElementById("email").value,
            password: document.getElementById("password").value,
            firstName: document.getElementById("firstName").value,
            lastName: document.getElementById("lastName").value,
        }
        try {
            const responsePost = await fetch('api/Users', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            if (!responsePost.ok) {
                alert(`${user.firstName} not register`)
            }
            else {
                const newUser = await responsePost.json();
                alert(`${newUser.firstName} register`)
            }
        }
        catch (error) {
            alert(error, "error")
        }

    }

}


const login = async () => {
    let emailLog = document.getElementById("emailLog").value
    let passwordLog = document.getElementById("passwordLog").value

    try {
        const responseGet = await fetch(`api/Users?email=${emailLog}&password=${passwordLog}`);
        if (!responseGet.ok) {
            alert("not login")
        }
        else {
            const dataGet = await responseGet.json();
            console.log(dataGet)
            sessionStorage.setItem("id", JSON.stringify(dataGet))
            window.location.href = "./update.html"
        }

    }
    catch (error) {
        alert(error)
    }
}
const update = async () => {
    var user = {
        email: document.getElementById("emailUp").value,
        password: document.getElementById("passwordUp").value,
        firstName: document.getElementById("firstNameUp").value,
        lastName: document.getElementById("lastNameUp").value,
    }
    var id = JSON.parse(sessionStorage.getItem("user")).id
    alert(id)
    try {
        const responsePut = await fetch(`api/Users${id}`,
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
        if (!responsePut.ok) {
            alert("not update")
        }
        else {
            const updateUser = await responsePut.json()
            alert(updateUser.firstName)
        }
    }
    catch (error) {
        alert(error)
    }

}
const checkPassword = async () => {


    var password = document.getElementById("password").value;
    var meter = document.getElementById('level');

    try {
        const response = await fetch('api/Users/check', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });
        if (!response.ok)
            alert('enter password')
        else {
            const strengthLevel = await response.json();
            if (strengthLevel <= 2) {
                meter.value = strengthLevel;
                alert('your password is weak try again')

            }
            meter.value = strengthLevel;
            return true;
        }


    }
    catch (error) {
        alert(error, "error")
    }
}
const getById = async (id) => {


    try {
        const responseGet = await fetch(`api/Users/${id}`);
        if (!responseGet.ok) {
            alert("no user")
        }
        else {
            const dataGet = await responseGet.json();
            console.log(dataGet)
        }

    }
    catch (error) {
        alert(error)
    }
}


