import React, { useEffect, useState } from 'react'
import ReactDOM from "react-dom/client"
import { BrowserRouter, Route, Routes } from "react-router-dom"

import Budget from './Components/Budget/Budget'
import BudgetCreate from './Components/BudgetCreate/budgetCreate'
import Layout from "./Components/Layout/Layout"
import LogIn from "./Components/LogIn/LogIn"
import LogOff from "./Components/LogOff/LogOff"
import Register from './Components/Register/Register'

const App = () => {

  const [budgets, setBudgets] = useState([])
  const addBudget = (budget) => setBudgets([...budgets, budget])
  const removeBudget = (removeId) => setBudgets(budgets.filter(({ Id }) => Id !== removeId));
  const [user, setUser] = useState({
    isAuthenticated: false,
    userName:"",
    userRole: ""
  })

  useEffect(() => {
    const getUser = async () => {
      return await fetch("api/account/isauthenticated")
      .then((response) => {
      response.status === 401 &&
      setUser({ isAuthenticated: false, userName: "", userRole: "" })
      return response.json()
      })
      .then(
        (data) => {
          if (
          typeof data !== "undefined" &&
          typeof data.userName !== "undefined" &&
          typeof data.userRole !== "undefined"
          ) {
            setUser({ isAuthenticated: true, userName: data.userName, userRole: data.userRole })
          }
        },
        (error) => {
          console.log(error)
        }
      )
    }
    getUser()
    }, [setUser])
    

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout user={user} />}>
          <Route index element={<h3>Главная страница</h3>} />
          <Route
            path="/budgets"
            element={
              <>
                <BudgetCreate user={user} addBudget={addBudget} />
                <Budget
                  user={user}
                  budgets={budgets}
                  setBudgets={setBudgets}
                  removeBudget={removeBudget}
                />
              </>
            }
          />
          <Route
            path="/register"
            element={<Register user={user} setUser={setUser} />}
          />
          <Route
            path="/login"
            element={<LogIn user={user} setUser={setUser} />}
          />
          <Route path="/logoff" element={<LogOff setUser={setUser} />} />
          <Route path="/budgets" element={<h3>404</h3>} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

const root = ReactDOM.createRoot(document.getElementById("root"))
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)
