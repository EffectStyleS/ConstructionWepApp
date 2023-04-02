import React from 'react'

const BudgetCreate = ({ user, addBudget }) => {

    const handleSubmit = (e) => {
        e.preventDefault()
        const { value } = e.target.elements.startDate

        const budget = { startDate: value }

        const createBudget = async () => {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(budget)
            }

            const response = await fetch("api/budgets", requestOptions)

            return await response.json()
            .then((data) => {
                console.log(data)
                // response.status === 201 && addBudget(data)
                if (response.ok) {
                    addBudget(data)
                    e.target.elements.startDate.value = ""
                }
            },
                (error) => console.log(error)
            )
        }
        createBudget()
    }

    return (
        <React.Fragment>
            {user.isAuthenticated ? (
            <>
                <h3>Создание нового бюджета</h3>
                <form onSubmit={handleSubmit}>
                    <label>StartDate: </label>
                    <input type="date" name="startDate" placeholder="Введите дату начала:" />
                    <button type="submit">Создать</button>
                </form>
                </>
            ) : ( 
                ""
            )}
        </React.Fragment>
    )
}
export default BudgetCreate
