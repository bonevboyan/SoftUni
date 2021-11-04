function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getPosts);
    document.getElementById('btnViewPost').addEventListener('click', displayPost);

    let select = document.getElementById('posts');

    async function getPosts() {
        let response = await fetch("http://localhost:3030/jsonstore/blog/posts");
        let data = await response.json();

        Object.values(data).map(createOption).forEach(x => select.appendChild(x));
    }

    function createOption(post) {
        let result = document.createElement('option');
        result.textContent = post.title;
        result.value = post.id;

        return result;
    }

    function displayPost() {
        let postId = document.getElementById('posts').value;
        getCommentsByPostId(postId);

    }

    async function getCommentsByPostId(postId) {

        let commentsUl = document.getElementById('post-comments');
        commentsUl.innerHTML = '';

        let [postResponse, commentsResponse] = await Promise.all([
            fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`),
            fetch("http://localhost:3030/jsonstore/blog/comments")
        ]);


        let postData = await postResponse.json();

        document.getElementById('post-title').textContent = postData.title;
        document.getElementById('post-body').textContent = postData.body;

        let commentsData = await commentsResponse.json();
        let comments = Object.values(commentsData).filter(comment => comment.postId === postId);


        comments.map(createComment).forEach(c => commentsUl.appendChild(c));
    }

    function createComment(comment) {
        let result = document.createElement('li');
        result.textContent = comment.text;
        result.id = comment.id;
        return result;
    }
}

attachEvents();



attachEvents();