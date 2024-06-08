import FormInput from "../components/FormInput";

const CreatePost = () => {
    return (
        <div>
            <h1>Create Post</h1>
            <form style={{display: "flex", justifyContent: "center", flexDirection: "column"}}>
                <FormInput name="userId" placeholder="UserId" />
                <FormInput name="id" placeholder="ID" />
                <FormInput name="title" placeholder="Title" />
                <FormInput name="body" placeholder="Body" />
                <button className="btn btn-outline-success" style={{width: "10vw", margin: "10px auto"}}>Submit Post</button>
            </form>
        </div>
    );
}

export default CreatePost;