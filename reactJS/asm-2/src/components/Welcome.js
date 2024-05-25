const Welcome = ({ name, age, bgColor}) => {
    const style = {
        backgroundColor: bgColor,
        padding: '10px',
        margin: '10px',
    };

    return (
        <div style={style}>
            <p>Name: {name}</p>
            <p>Age: {age}</p>
        </div>
    )
}

export default Welcome;