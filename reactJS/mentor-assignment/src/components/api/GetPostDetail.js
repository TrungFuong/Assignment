import { useEffect, useState } from "react";

const GetPostDetail = (id) => {
    const [postDetail, setPostDetail] = useState({});

    useEffect(() => {
        const fetchPostDetail = async () => {
            try {
                const response = await fetch(`http://localhost:5000/posts/${id}`);
                const json = await response.json();
                setPostDetail(json);
            } catch (error) {
                console.error("Error fetching post detail:", error);
            }
        };
        fetchPostDetail();
    }, [id]);

    return postDetail;
};

export default GetPostDetail;
