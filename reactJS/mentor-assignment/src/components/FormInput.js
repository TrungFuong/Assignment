const FormInput = (props) => {
    return (
    <div className="formInput">
        <label>{props.placeholder}
        <br />
        <input name={props.name} placeholder={props.placeholder} />
        </label>
    </div>
    );
}

export default FormInput;