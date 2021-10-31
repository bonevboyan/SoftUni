function attachEvents() {
    document.getElementById("btnLoadPosts").addEventListener("click", onLoad);
    document.getElementById("btnViewPost").addEventListener("click", onView);

    async function onLoad(e) {
        try {
            let response = await fetch("http://localhost:3030/jsonstore/blog/posts");
    
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`);
            }
    
            let posts = await response.json();
    
            let select = document.getElementById("posts");
    
            for (const key in posts) {
                let option = document.createElement("option");
                option.setAttribute("value", key);
    
                option.textContent = posts[key].title;
    
                select.appendChild(option);
            }
        } catch (error) {
            console.log(error.message);
        }
    }

    async function onView(e) {
        try {
            let postId = document.getElementById("posts").value.value;

            let response = await fetch(`http://localhost:3030/jsonstore/blog/comments/${postId}`);
    
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`);
            }
    
            let comments = await response.json();
    
            let postComments = document.getElementById("post-comments");
    
            for (const comment in comments) {
                let option = document.createElement("li");
                option.setAttribute("id", key);
    
                option.textContent = comments[key].text;
    
                postComments.appendChild(option);
            }

            response = await fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`);
    
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`);
            }
    
            let post = await response.json();

            document.getElementById("post-title").textContent = post.title;
            document.getElementById("post-body").textContent = post.body;


        } catch (error) {
            console.log(error.message);
        }
    }
}

attachEvents();