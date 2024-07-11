const tblBlog = "Blogs";
let blogID = null;
getBlogTable();

//createBlog("Title3","Author3","Content3");
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

    successMessage("Saving Successful.");
    clearControls();
}

function editBlog(id) {
    let list = getBlogs();
    const items = list.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No Data Found.");
        errorMessage("No Data Found.");
        return;
    }
    let item = items[0];
    blogID = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function updateBlog(id, title, author, content) {
    let list = getBlogs();
    const items = list.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No Data Found.");
        errorMessage("No Data Found.");
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

    successMessage("Updating Successful.");
    clearControls();
}

function deleteBlog(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
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

            successMessage("Deleting Successful.");
            getBlogTable();
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
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
    return list;
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogID === null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogID, title, author, content);
        blogID = null;
    }
    getBlogTable();
})

function successMessage(message) {
    Swal.fire({
        title: "Success!",
        text: message,
        icon: "success"
    });
}

function errorMessage(message) {
    Swal.fire({
        title: "Error!",
        text: message,
        icon: "error"
    });
}

function deleteMessage() {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
}

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    let list = getBlogs();
    let count = 0;
    let htmlRows = '';
    list.forEach(item => {
        const htmlRow = `
            <tr>
                <td>
                    <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')">Edit</button>
                    <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
                </td>
                <td>${++count}</td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
            </tr>
        `;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}