import FormInput from "../components/FormInput";
import { useState } from "react";
import CreatePost from "../components/api/CreatePost";
import {useNavigate} from "react-router-dom";

const Create = () => {
    const [userId, setUserId] = useState('');
    const [id, setId] = useState('');
    const [title, setTitle] = useState('');
    const [body, setBody] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        const newPost = {
            userId: userId,
            id: id,
            title: title,
            body: body
        };
        await CreatePost(newPost);
        alert('Post created successfully');
        navigate('/posts');
    };

    return (
        <div>
            <h1>Create Post</h1>
            <form onSubmit={handleSubmit} style={{ display: "flex", justifyContent: "center", flexDirection: "column" }}>
                <FormInput name="userId" placeholder="UserId" onChange={(e) => setUserId(e.target.value)} />
                <FormInput name="id" placeholder="ID" onChange={(e) => setId(e.target.value)} />
                <FormInput name="title" placeholder="Title" onChange={(e) => setTitle(e.target.value)} />
                <FormInput name="body" placeholder="Body" onChange={(e) => setBody(e.target.value)} />
                <button type="submit" className="btn btn-outline-success" style={{ width: "10vw", margin: "10px auto" }}>
                    Submit Post
                </button>
            </form>
        </div>
    );
};

export default Create;
