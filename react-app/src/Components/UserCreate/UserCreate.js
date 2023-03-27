import React from 'react'

const UserCreate = ({ addUser }) => {

    const handleSubmit = (e) => {
        e.preventDefault()
        const { value } = e.target.elements.login

        const user = { url: value }

        const createUser = async () => {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)
            }

            const response = await fetch("https://localhost:7190/api/users/", requestOptions)

            return await response.json()
            .then((data) => {
                console.log(data)
                // response.status === 201 && addUser(data)
                if (response.ok) {
                    addUser(data)
                    e.target.elements.login.value = ""
                }
            },
                (error) => console.log(error)
            )
        }
        createUser()
    }

    return (
        <React.Fragment>
            <h3>Создание нового пользователя</h3>
            <form onSubmit={handleSubmit}>
                <label>Login: </label>
                <input type="text" name="login" placeholder="Введите Login:" />
                <button type="submit">Создать</button>
            </form>
        </React.Fragment >
    )
}
export default UserCreate
