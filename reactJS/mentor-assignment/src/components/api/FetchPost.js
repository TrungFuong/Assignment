const FetchPosts = async (setPosts) => {
    try {
        const response = await fetch('http://localhost:5000/posts');
        const json = await response.json();
        setPosts(json);
    } catch (error) {
        console.error('Error fetching posts:', error);
    }
};

export default FetchPosts;