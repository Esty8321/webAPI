


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