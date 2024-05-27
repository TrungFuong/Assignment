import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Post from './pages/Post';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Navbar from "./components/navbar/navbar";
import Home from "./pages/Home";
import CreatePost from "./pages/CreatePost";

function App() {
    return (
        <Router>
            <Navbar/>
            <Routes>
                <Route path='/home' element={<Home/>}/>
                <Route path='/posts' element={<Post/>}/>
                <Route path='/create' element={<CreatePost/>}></Route>
            </Routes>
        </Router>
    );
}

export default App;
