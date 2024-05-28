import {useEffect, useState} from "react";

function GetAllPost() {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        const fetchAllPost = async () => {
            try {
                const response = await fetch('http://localhost:5000/posts');
                const json = await response.json();
                setPosts(json);
            } catch (error) {
                console.error('Error fetching posts:', error);
            }
        };

        fetchAllPost();
    }, []);

    return posts;
}
export default GetAllPost;