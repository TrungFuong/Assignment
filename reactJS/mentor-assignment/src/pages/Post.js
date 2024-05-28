import React, { useState, useEffect } from 'react';
import { confirmAlert } from 'react-confirm-alert';
import DataTable from 'react-data-table-component';
import 'react-confirm-alert/src/react-confirm-alert.css';
import deletePost from '../components/api/Delete';
import FetchPosts from '../components/api/FetchPost';
import {useNavigate} from "react-router-dom";

const handleDelete = (id, fetchPosts, setPosts) => {
    confirmAlert({
        title: 'DELETE',
        message: 'Are you sure to do this.',
        buttons: [
            {
                label: 'Yes',
                onClick: () => deletePost(id, fetchPosts, setPosts),
            },
            {
                label: 'No',
                onClick: () => alert('Click No'),
            },
        ],
    });
};

const handleUpdate = (id, fetchPosts) => {
    fetchPosts();
    window.location.href = `/update/${id}`;
}

const Post = () => {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        FetchPosts(setPosts);
    }, []);

    const columns = [
        {
            name: 'ID',
            selector: row => row.id,
            sortable: true,
            width: '5vw',
        },
        {
            name: 'Title',
            selector: row => row.title,
            sortable: true,
            width: '35vw',
        },
        {
            name: 'Body',
            selector: row => row.body,
            width: '40vw',
        },
        {
            name: 'Action',
            cell: (row) => (
                <div>
                    <button className="btn btn-outline-primary m-2" onClick={() => handleUpdate(row.id, FetchPosts)}>Edit</button>
                    <button
                        className="btn btn-outline-danger m-2"
                        onClick={() => handleDelete(row.id, FetchPosts, setPosts)}
                    >
                        Delete
                    </button>
                </div>
            ),
        },
    ];

    const navigate = useNavigate();
    const handleRowClick = (row) => {
        navigate(`/posts/${row.id}`);
    };

    return (
        <div className="table-container">
            <div className="App">
                <DataTable
                    columns={columns}
                    data={posts}
                    pagination
                    responsive
                    onRowClicked={handleRowClick}
                    pointerOnHover
                    />
            </div>
        </div>
    );
};

export default Post;