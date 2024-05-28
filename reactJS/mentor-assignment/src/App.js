import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Post from './pages/Post';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Navbar from "./components/navbar/navbar";
import Home from "./pages/Home";
import Create from "./pages/Create";
import PostDetail from './pages/Detail.js';
import UpdatePost from './pages/Update.js';

function App() {
    return (
        <Router>
            <Navbar/>
            <Routes>
                <Route path='/home' element={<Home/>}/>
                <Route path='/create' element={<Create/>}/>
                <Route path='/posts' element={<Post/>}/>
                <Route path='/posts/:id' element={<PostDetail/>}/> 
                <Route path='/update/:id' element={<UpdatePost/>}/> 
            </Routes>
        </Router>
    );
}

export default App;
