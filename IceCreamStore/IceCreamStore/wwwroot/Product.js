
const us=sessionStorage.getItem("user")
console.log("before",us)
const user = JSON.parse(us)
console.log("user", user)
document.getElementById("name").innerHTML = user.firstName;

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
