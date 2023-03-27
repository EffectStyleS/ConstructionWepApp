import React, { useEffect } from 'react'

import './Style.css'

const User = ({ users, setUsers, removeUser }) => {
    useEffect(() => {
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
    };

    fetch("https://localhost:7190/api/users/", requestOptions)
        .then(response => response.json())
        .then(data => {
            setUsers(data)
        })
        .catch((error) => {
            console.log(error)
        });
    }, [setUsers])

    const deleteItem = async ({ Id }) => {
        const requestOptions = {
            method: 'DELETE'
        }
        return await fetch(`https://localhost:7190/api/users/${Id}`, 
        requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeUser(Id);
                }
            },
                (error) => console.log(error)
            )
    }

    return (
        <React.Fragment>
            <h3>Список пользователей</h3>
            {users.map(({ Id, login, name, budget }) => (
                <div className="User" key={Id} id={Id} >

                    <strong > {Id}: {login} </strong>
                    <strong > {Id}: {name} </strong>

                    <button onClick={(e) => deleteItem({ Id })}>Удалить</button>
                    
                    {budget.map(({ Id, startDate, timePeriodId}) => (
                        <div className="BudgetProperties" key={Id} id={Id} >
                            {startDate}<br /> {timePeriodId}<hr />
                        </div>
                    ))}
                </div>
            ))}
        </React.Fragment>
    )
}

export default User
