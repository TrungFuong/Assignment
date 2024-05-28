import GetPostDetail from "../components/api/GetPostDetail";
import { useParams } from "react-router-dom";

const PostDetail = () => {
  const { id } = useParams();
  const postDetail = GetPostDetail(id);
  console.log(postDetail);

  return (
    <div>
      <h1>Post Detail</h1>
      <form
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
            <input value={postDetail.userId} disabled/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            id
            <br />
            <input value={postDetail.id} disabled/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            title
            <br />
            <input value={postDetail.title} disabled/>
          </label>
        </div>
        
        <div className="formInput">
          <label>
            body
            <br />
            <input value={postDetail.body} disabled/>
          </label>
        </div>
      </form>
    </div>
  );
};

export default PostDetail;
