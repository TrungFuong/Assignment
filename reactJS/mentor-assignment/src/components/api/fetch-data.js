import {useEffect, useState} from "react";

function GetAllPost() {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        const fetchAllPost = async () => {
            try {
<<<<<<< HEAD:reactJS/mentor-assignment/src/components/api/GetAll.js
                const response = await fetch('https://localhost:7156/api/Book');
=======
                const response = await fetch('https://jsonplaceholder.typicode.com/posts');
>>>>>>> parent of 956b0a6 (React CRUD (not auth yet)):reactJS/mentor-assignment/src/components/api/fetch-data.js
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