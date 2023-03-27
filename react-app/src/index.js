import React, { useState } from 'react'
import ReactDOM from "react-dom/client"

import User from './Components/User/User'
import UserCreate from './Components/UserCreate/UserCreate'

const App = () => {

  const [users, setUsers] = useState([])
  const addUser = (user) => setUsers([...users, user])
  const removeUser = (removeId) => setUsers(users.filter(({ Id }) => Id !== removeId));

  return (
    <div>
      <UserCreate
        addUser={addUser}
      />
      <User
        users={users}
        setUsers={setUsers}
        removeUser={removeUser}
      />
    </div>
  )
}

const root = ReactDOM.createRoot(document.getElementById("root"))
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)
