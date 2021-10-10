function getArticleGenerator(articles) {
    let div = document.getElementById('content');

    index = 0;

    function next() {
        let article = document.createElement('article');
        let p = document.createElement('p');

        if (index < articles.length) {
            let nextString = articles[index++];
            
            p.appendChild(document.createTextNode(nextString));            
            article.appendChild(p);
            div.appendChild(article);
        }
    }

    return next;
}