const FormInput = ({ name, placeholder, onChange }) => {
    return (
        <div className="formInput">
            <label>
                {placeholder}
                <br />
                <input 
                    name={name} 
                    placeholder={placeholder} 
                    onChange={onChange} 
                />
            </label>
        </div>
    );
}

export default FormInput;
