import React, { useEffect } from 'react'

import './Style.css'

const Budget = ({ user, budgets, setBudgets, removeBudget }) => {
    useEffect(() => {
        const getBudgets = async () => {
            const requestOptions = {
                method: 'GET',
            };
            return await fetch("api/budgets", requestOptions)
            .then((response) => response.json())
            .then(
              (data) => {
                console.log("Data:", data)
                setBudgets(data)
              },
              (error) => {
                console.log(error)
              }
            )
        }
        getBudgets();
    }, [setBudgets])

    const deleteItem = async ({ Id }) => {
        const requestOptions = {
            method: 'DELETE'
        }
        return await fetch(`api/budgets/${Id}`, 
        requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeBudget(Id);
                }
            },
                (error) => console.log(error)
            )
    }

    return (
        <React.Fragment>

            <h3>Список бюджетов</h3>

            {budgets.map(({ Id, startDate, timePeriodId, userId}) => (
                <div className="Budget" key={Id} id={Id} >

                    <strong > {Id}: {startDate} </strong>

                    {user.isAuthenticated ? (
                        <button onClick={() => deleteItem({ Id })}>Удалить</button>
                    ) : (
                        ""
                    )}
                    <br />
                                        
                    {/* {timePeriod.Length > 0 && timePeriod.map(({ Id, name }) => (
                        <div className="TimePeriodProperties" key={Id} id={Id} >
                            {name}<br />
                        </div>
                    ))} */}

                    <strong > {Id}: {timePeriodId} </strong>
                    <br/>
                    <strong > {Id}: {userId} </strong>
                    
                    {/* {userOwner.length > 0 && userOwner.map(({ Id, userName }) => (
                        <div className="UserProperties" key={Id} id={Id} >
                            {userName}<br />
                        </div>
                    ))} */}

                </div>
            ))}
        </React.Fragment>
    )
}

export default Budget
