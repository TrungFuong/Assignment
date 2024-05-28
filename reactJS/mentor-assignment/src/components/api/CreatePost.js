const CreatePost = (newPost) => {
    try {
        fetch('http://localhost:5000/posts', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newPost),
        });
        
    }
    catch (error) {
        console.error('Error creating post:', error);
    }
}

export default CreatePost;