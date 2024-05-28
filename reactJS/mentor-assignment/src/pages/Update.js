import { useEffect, useState } from "react";
import GetPostDetail from "../components/api/GetPostDetail";
import { useNavigate, useParams } from "react-router-dom";
import UpdateThePost from "../components/api/UpdatePost";

const UpdatePost = () => {
  const { id } = useParams();
  const postDetail = GetPostDetail(id);
  console.log(postDetail);
  
    const [userId, setUserId] = useState('');
    const [postId, setPostId] = useState('');
    const [title, setTitle] = useState('');
    const [body, setBody] = useState('');
    const navigate = useNavigate();
    
    useEffect(() => {
      if (postDetail) {
        setUserId(postDetail.userId);
        setPostId(postDetail.id);
        setTitle(postDetail.title);
        setBody(postDetail.body);
      }
    }, [postDetail]);

      const handleSubmit = async (event) => {
        event.preventDefault();
  
      const updatedPost = {
        userId: userId,
        id: postId,
        title: title,
        body: body
    };

    await UpdateThePost(updatedPost);
    alert('Post updated successfully');
    navigate('/posts');
    
};

  return (
    <div>
      <h1>Post Detail</h1>
      <form
        onSubmit = {(event)=>{handleSubmit(event)}}
        style={{
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
        }}
      >
        <div className="formInput">
          <label>
            userId
            <br />
            <input defaultValue={userId} onChange={e => setUserId(e.target.value)}/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            id
            <br />
            <input defaultValue={id} onChange={e => setPostId(e.target.value)}/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            title
            <br />
            <input defaultValue={title} onChange={e => setTitle(e.target.value)}/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            body
            <br />
            <input defaultValue={body} onChange={e => setBody(e.target.value)}/>
          </label>
        </div>

        <button type="submit" className="btn btn-outline-success" style={{ width: "10vw", margin: "10px auto" }}>
                    Update Post
                </button>
      </form>
    </div>
  );
};

export default UpdatePost;
