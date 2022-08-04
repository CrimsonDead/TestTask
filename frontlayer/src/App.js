import React, { Component, useState, useEffect } from 'react';

const App = () => {

    const onButtonClick = (event) => {
        event.stopPropagation();
        populateUser(inputState);
    }

    const [state, setState] = useState({ unps: [], loading: true });

    const [inputState, setInputState] = useState('');

    const [isSeven, setIsSeven] = useState(false);

    const currentTime = new Date().getHours();
   
    useEffect(() => {
        currentTime === 16 ? setIsSeven(true) : setIsSeven(false);
    }, [])

    const onInputChange = (event) => {
        event.stopPropagation();
        const { target: { value } } = event;
        setInputState(value);
    }

    async function populateUser(inputState) {
        var url = `api/user?unp=${inputState}`;
        const response = await fetch(url);
        const data = await response.json();
        console.log(data);
        setState({ unps: data, loading: false });
        console.log(state.unps.value);
    }

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel" style={{
            border: '4px double #333', 
            borderCollapse: 'separate',
            width: '100%',
            borderSpacing: '7px 11px'}}>
            <thead>
                <tr>
                    <th>User unique number</th>
                    <th>Exist in local data base</th>
                    <th>Exsist in external data base</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input onChange={(event) => onInputChange(event)} type="text" name="UNP" placeholder="User UNP" /></td>
                    <td><input type="checkbox" checked={state.unps.isLocalUserExist} /></td>
                    <td><input type="checkbox" checked={!state.unps.isExternalUserExist} /></td>
                </tr>
                <tr>
                    <td><div onClick={(event) => { onButtonClick(event) }} style={{backgroundColor: 'red', alignContent: 'center'}}>Check</div></td>
                    <td>{isSeven && (<div style={{margin: '0 0 0 30px'}}>Your status changed</div>)}</td>
                </tr>
            </tbody>
        </table >
    );
}


export default App;