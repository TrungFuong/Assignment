const DeletePost = async (id, fetchPosts, setPosts) => {
    try {
        await fetch(`http://localhost:5000/posts/${id}`, {
            method: 'DELETE',
        });
        fetchPosts(setPosts);
    } catch (error) {
        console.error('Error deleting post:', error);
    }
};

export default DeletePost;