import GetAllPost from "../components/api/fetch-data";
import DataTable from "react-data-table-component";

const Post = () => {
    const dataSource = GetAllPost()
    const columns = [
        {
            name: 'ID',
            selector: row => row.id,
            sortable: true,
            width: '5vw'
        },
        {
            name: 'Title',
            selector: row => row.title,
            sortable: true,
            width: '35vw'
        },
        {
            name: 'Body',
            selector: row => row.body,
            width: '40vw'
        },
        {
            name: 'Action',
            cell: (row) => <div>
                <button className={"btn btn-outline-primary m-2"}>Edit</button>
                <button className={"btn btn-outline-danger m-2"}>Delete</button>
                <button className={"btn btn-outline-dark m-2"}>Details</button>
            </div>,
        }
    ];

    return (
        <div className="table-container">
            <div className="App">
                <DataTable
                    columns={columns}
                    data={dataSource}
                    pagination
                    responsive
                ></DataTable>
            </div>
        </div>
    );
}
export default Post;