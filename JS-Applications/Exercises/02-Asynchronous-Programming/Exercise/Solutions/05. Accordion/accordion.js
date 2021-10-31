function solution() {
    async function getArticles() {
        let responce = await fetch("http://localhost:3030/jsonstore/advanced/articles/list");

        if(responce.ok == false){
            throw new Error(`${response.status} ${response.statusText}`);
        }

        let articles = await responce.json();

        let articleStructure = document.querySelector(".accordion");

        for (const article of articles) {
            responce = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`);
            if(responce.ok == false){
                throw new Error(`${response.status} ${response.statusText}`);
            }
            let info = responce.json();

            let newArticle = document.createElement("div");
            newArticle.classList.add("accordion");

            newArticle.innerHTML = articleStructure.innerHTML;

            newArticle.querySelector(".head span").textContent = article.title;
            newArticle.querySelector(".head button").id = article._id;
            newArticle.querySelector(".extra p").textContent = article.content;
        }
    }
}

solution();