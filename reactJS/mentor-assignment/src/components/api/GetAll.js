import {useEffect, useState} from "react";

function GetAllPost() {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        const fetchAllPost = async () => {
            try {
                const response = await fetch('https://localhost:7156/api/Book');
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