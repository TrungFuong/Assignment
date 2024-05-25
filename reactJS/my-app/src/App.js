import logo from './logo.svg';
import './App.css';

const name = "Hehe";
const age = 20;
function App() {
  return (
    <div className="App" style= {{backgroundColor: "red", textAlign: "left"}}>
        <p><b>Name: {name}</b></p>
        <p><b>Age: {age}</b></p>
    </div>
  );
}

export default App;
