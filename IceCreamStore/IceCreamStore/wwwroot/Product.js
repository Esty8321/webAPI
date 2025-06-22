


async function getAllProducts() {
  
    
    try {
        const res = await fetch("api/Product",
            {
                method: "GET",
                headers: {
                    'Content-Type': "application/json"
                },
           
            }).then(response => {
                if (!response.ok) {
                    throw new Error("get all products fail!!!")
                }
                return response.json();
            }).then(data => {
                console.log("products: "+data)
            })
    }
    catch (e) {
        console.log("error in get all products")
        return "error";
    }
}
async function getAllCategories() {


    try {
        const res = await fetch("api/Category",
            {
                method: "GET",
                headers: {
                    'Content-Type': "application/json"
                },

            }).then(response => {
                if (!response.ok) {
                    throw new Error("get all products fail!!!")
                }
                return response.json();
            }).then(data => {
                console.log("category: " + data)
            })
    }
    catch (e) {
        console.log("error in get all category")
        return "error";
    }
}

getAllProducts()
getAllCategories()

const updateUser = async () => {
    const Email = document.getElementById("email").value
    const FirstName = document.getElementById("firstName").value;
    const LastName = document.getElementById("lastName").value;
    const Passord = document.getElementById("password").value
    const Id = Number(JSON.parse(sessionStorage.getItem("user")).id);
    console.log("in the session: ", sessionStorage.getItem("user"))
    const user = { Id, Email, Passord, FirstName, LastName };
    console.log("user try to update: ", user);
    try{
        const dataUpdate = await fetch(`api/User/update`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }).then(response => {
            if (!response.ok)
                alert("Update fail")
            return response.json();
        }).then(data => {
            console.log(" B''H update success 😁😁😆😂😀🙌")
            sessionStorage.setItem("user", JSON.stringify(data))
            alert(" B''H update success 😁😁😆😂😀🙌")
        })
    }
    catch (e) { console.log("fail to update 😟😟😟💔",e) }
 }