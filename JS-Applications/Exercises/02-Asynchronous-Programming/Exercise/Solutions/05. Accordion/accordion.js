function solution() {
    getArticles();
    async function getArticles() {
        try {
            let responce = await fetch("http://localhost:3030/jsonstore/advanced/articles/list");
    
            if (responce.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`);
            }
    
            let articles = await responce.json();
    
            let articleStructure = document.querySelector(".accordion");
    
            for (const article of articles) {
                responce = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`);
                if (responce.ok == false) {
                    throw new Error(`${response.status} ${response.statusText}`);
                }
                let info = await responce.json();
    
                let newArticle = document.createElement("div");
                newArticle.classList.add("accordion");
    
                newArticle.innerHTML = articleStructure.innerHTML;
    
                newArticle.querySelector(".head span").textContent = info.title;
                newArticle.querySelector(".head button").id = info._id;
                newArticle.querySelector(".head button").addEventListener("click", onClick);
                newArticle.querySelector(".extra p").textContent = info.content;
                newArticle.querySelector(".extra").style.display = 'none'
    
                articleStructure.parentElement.appendChild(newArticle);
            }
    
            articleStructure.parentElement.removeChild(articleStructure);
        } catch (error) {
            console.log(error.message);
        }
    }

    function onClick(e) {
        e.target.textContent = e.target.textContent == "More" ? "Less" : "More";

        let extra = e.target.parentElement.parentElement.querySelector(".extra");

        if (extra.style.display === 'none') {
            extra.style.display = 'block';
        } else {
            extra.style.display = 'none'
        }
    }
}

solution();