import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Post from './components/post/post';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Navbar from "./components/navbar/navbar";
import Home from "./components/home/Home";

function App() {
    return (
    <Router>
        <Navbar/>
        <Routes>
            <Route path='/home' element={<Home/>} />
            <Route path='/posts' element={<Post/>} />
        </Routes>
    </Router>
  );
}

export default App;
