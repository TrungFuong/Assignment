import "./App.css";
import {useEffect, useRef, useState} from "react";
import Welcome from "./components/Welcome";
import Counter from "./components/Counter";
import RegisterForm from "./components/FormInput";
import FormInput from "./components/FormInput";

function App() {
    const [option, setOption] = useState("Welcome");
    const handleSelectChange = (e) => {
        setOption(e.target.value);
    };

    const [interests, setInterests] = useState({all: false, coding: false, music: false, reading: false});
    const handleCheckboxChange = (event) => {
        const {name, checked} = event.target;

        setInterests((prevState) => {
            if (name === 'all') {
                return {
                    all: checked,
                    coding: checked,
                    music: checked,
                    reading: checked,
                };
            }
            return {
                ...prevState,
                [name]: checked,
                all: checked && prevState.coding && prevState.music && prevState.reading,
            };
        });
    };

    const [pokemon, setPokemon] = useState(null);
    const [pokemonId, setPokemonId] = useState(1);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [totalPokemon, setTotalPokemon] = useState(0);

    useEffect(() => {
        const fetchPokemon = async () => {
            setLoading(true);
            setError(null);
            try {
                const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonId}`);
                if (!response.ok) {
                    throw new Error('Pokemon not found');
                }
                const data = await response.json();
                setPokemon(data);
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };
        fetchPokemon();
    }, [pokemonId]);

    useEffect(() => {
        const fetchTotalPokemon = async () => {
            try {
                const response = await fetch('https://pokeapi.co/api/v2/pokemon?limit=1');
                if (!response.ok) {
                    throw new Error('Failed to fetch total number of Pokemon');
                }
                const data = await response.json();
                setTotalPokemon(data.count);
            } catch (error) {
                console.error('Error fetching total number of Pokemon:', error);
            }
        };

        fetchTotalPokemon();
    }, []);
    const handleNext = () => {
        setPokemonId((prevId) => prevId + 1);
    };

    const handlePrevious = () => {
        setPokemonId((prevId) => (prevId > 1 ? prevId - 1 : 1));
    };

    const arrayProfile = [
        {
            name: "Hoangdd",
            age: 34,
            bgColor: "red",
            id: 1,
        },
        {
            name: "Son Tung MTP",
            age: 25,
            bgColor: "yellow",
            id: 2,
        },
        {
            name: "Ronaldo",
            age: 37,
            bgColor: "green",
            id: 3,
        },
    ]

    // const [username, setUsername] = useState("");
    // console.log(username);
    // const usernameRef = useRef()
    const handleSubmit = (e) => {
        e.preventDefault();
        // console.log(usernameRef)
    const data = new FormData(e.target);
    console.log(Object.fromEntries(data.entries()))
    }


    return (
        <>
            <select onChange={handleSelectChange}>
                <option value="Welcome">Welcome</option>
                <option value="Counter">Counter</option>
                <option value="Checkboxes">Checkboxes</option>
                <option value="Pokemon">Pokemon</option>
                <option value="Register">Register</option>
            </select>
            <p>Option selected: {option}</p>

            {option === "Welcome" && (
                <>
                    <div>
                        <Welcome name="Hoangdd" age={34} bgColor="red"/>
                        <Welcome name="Son Tung MTP" age={25} bgColor="yellow"/>
                        <Welcome name="Ronaldo" age={37} bgColor="green"/>
                    </div>
                    <div>
                        {arrayProfile.map((profile) => (
                            <Welcome key={profile.id} name={profile.name} age={profile.age} bgColor={profile.bgColor}/>
                        ))}
                    </div>
                </>
            )}

            {option === "Counter" && (
                <div>
                    <Counter/>
                </div>
            )}

            {option === "Checkboxes" && (
                <div>
                    <p>Choose your interests:</p>
                    <input
                        name="all"
                        type="checkbox"
                        checked={interests.all}
                        onChange={handleCheckboxChange}
                    />
                    <label htmlFor="all">All</label>
                    <br/>
                    <input
                        name="coding"
                        type="checkbox"
                        checked={interests.coding}
                        onChange={handleCheckboxChange}
                    />
                    <label htmlFor="coding">Coding</label>
                    <br/>
                    <input
                        name="music"
                        type="checkbox"
                        checked={interests.music}
                        onChange={handleCheckboxChange}
                    />
                    <label htmlFor="music">Music</label>
                    <br/>
                    <input
                        name="reading"
                        type="checkbox"
                        checked={interests.reading}
                        onChange={handleCheckboxChange}
                    />
                    <label htmlFor="reading">Reading books</label>
                </div>
            )}
            {option === "Checkboxes" && (
                <div>
                    <p>Interests selected:</p>
                    <pre>{JSON.stringify({
                        coding: interests.coding,
                        music: interests.music,
                        reading: interests.reading,
                    }, null, 2)}</pre>
                </div>
            )}
            {option === "Pokemon" && (
                <div>
                    {loading && <p>Loading...</p>}
                    {error && <p>Error: {error}</p>}
                    {pokemon && (
                        <div>
                            <p>ID: {pokemon.id}</p>
                            <p>Name: {pokemon.name}</p>
                            <p>Weight: {pokemon.weight}</p>
                            <img src={pokemon.sprites.front_default} alt={pokemon.name}/>
                            <img src={pokemon.sprites.back_default} alt="{pokemon.name}"/>
                        </div>
                    )}
                    <button onClick={handlePrevious} disabled={pokemonId === 1}>Previous</button>
                    <button onClick={handleNext}>Next</button>
                </div>
            )}
            {option === "Register" && (
                <div>
                    <form onSubmit={handleSubmit}>
                        <FormInput name = "username" placeholder="Username"/>
                        <FormInput name = "email" placeholder="Email"/>
                        <FormInput name = "password" placeholder="Password"/>
                        <FormInput name = "confirmpassword" placeholder="Confirm password"/>
                        <button>Register</button>
                    </form>
                </div>
            )}
        </>
    );
}

export default App;
