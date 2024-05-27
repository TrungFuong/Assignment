import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const Navbar = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light" style={{ position: 'sticky', top: 0, zIndex: 1000 }}>
            <div className="container-fluid">
                <div>
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link to="/home" className="nav-link">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/posts" className="nav-link">Posts</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/create" className="nav-link">Create</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;
