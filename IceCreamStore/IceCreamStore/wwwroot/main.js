

async function addUser() {
   const Email = document.getElementById("email").value;
    const Password = document.getElementById("pswRegister").value;
    const FirstName = document.getElementById("firstName").value;
    const LastName = document.getElementById("lastName").value;
    const user = {Email,Password,FirstName,LastName}
    if (user.Email == "" || user.Password == "")
        alert("Email and password required")

    const dataPost = await fetch("api/User/register",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }).then(response => {
            if (!response.ok) {
                alert("response",response)
                let validEmail = document.getElementById("email");
                validEmail.style.display = "block";
                throw new Error('Network response was not ok');
            }
            return response.json();
        }).then(data => {
            // Handle the JSON data
            console.log(data);
            alert("welcom " + user.FirstName + ", you are inside:)")
        })
}

async function login() {
     Email = document.getElementById("emailLogin").value;
    Password = document.getElementById("pswLogin").value;
    const userLogin = { Email:Email,Password:Password}
    if (userLogin.Email == "" || userLogin.Password == "") {
        alert("Email and password required")
        return
    }
        
    try {
        const res = await fetch("api/User/login",
            {
                method: "POST",
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify(userLogin),
            }).then(response => {
                if (!response.ok) {
                    throw new Error("fail!!!")
                }
                return response.json();
            }).then(data => {
                sessionStorage.setItem("user", JSON.stringify(data))
                window.location.replace("Product.html")
            })
    }
    catch (e) {
        alert("login failed")
        return "error";
    }
}



const checkPowerPassword = async () => {
    
    const password = document.getElementById("pswRegister").value

    console.log('ppppppppa',password)
    try {
        const resPassword = await fetch("api/User/checkPassword",
            {
                method: 'POST',
                headers: {
                    'Content-Type':'application/json'
                },
                body:JSON.stringify(password),
            }).then(response => {
                if (!response.ok) {
                    throw new Error("---check password failed")
                }
                 return response.json()
            }).then(data => {
                console.log("the data which return from checkpassword, ", data)
                alert(data)
            })
    }
    catch (e) {

    }
}




async function updateUser() {
    user.Email = document.getElementById("email").value;
    user.Password = document.getElementById("psw").value;
    user.FirstName = document.getElementById("firstName").value;
    user.LastName = document.getElementById("lastName").value;
    user.Id = Number(JSON.parse(sessionStorage.getItem("user")).userId);
    console.log(user)
    try {
        const dataPost = await fetch(`api/User/${user.Id}`,
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            }).then(response => {
                if (!response.ok) {
                    alert("Update fail");
                }
                return response.json();
            }).then(data => {
                sessionStorage.setItem("user", JSON.stringify(data))
                alert("update success!!")
            })
    }
    catch (e) {
        return "error";
    }
}

