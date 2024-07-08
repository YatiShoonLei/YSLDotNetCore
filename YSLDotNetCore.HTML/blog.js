const tblBlog = "Blogs";

createBlog("Title3","Author3","Content3");
//updateBlog("61a7364a-c87b-4bb8-bfa3-650ba2b56ce6","Title2","Author2","Content2");
//deleteBlog("9d8c9abc-9c4e-46a5-b28c-1839d6de8e30");
//readBlog();

function readBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog(title, author, content) {
    let list = getBlogs();
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };
    list.push(requestModel);
    const jsonBlog = JSON.stringify(list);
    localStorage.setItem(tblBlog, jsonBlog);

    blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function updateBlog(id, title, author, content) {
    let list = getBlogs();
    const items = list.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No Data Found.");
        return;
    }
    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = list.findIndex(x => x.id === id);
    list[index] = item;

    const jsonBlog = JSON.stringify(list);
    localStorage.setItem(tblBlog, jsonBlog);

    blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function deleteBlog(id) {
    let list = getBlogs();
    let items = list.filter(x => x.id === id);
    if (items.length == 0) {
        console.log("No Data Found.");
        return;
    }

    list = list.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(list);
    localStorage.setItem(tblBlog, jsonBlog);

    blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlogs() {
    let blogs = localStorage.getItem(tblBlog);
    let list = [];
    if (blogs !== null) {
        list = JSON.parse(blogs);
    }
}