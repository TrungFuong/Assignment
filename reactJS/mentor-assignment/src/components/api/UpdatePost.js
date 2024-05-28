const UpdateThePost = (updatedPost) => {
    try{
        fetch(`http://localhost:5000/posts/${updatedPost.id}`, {
            method: 'PUT',
            body: JSON.stringify(updatedPost),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            },
        });
    }
    catch (error) {
        console.error('Error updating post:', error);
    }
}

export default UpdateThePost;