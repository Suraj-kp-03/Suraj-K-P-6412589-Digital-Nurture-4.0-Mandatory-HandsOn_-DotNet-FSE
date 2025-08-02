import React from 'react'
import { useState } from 'react';
import './App.css'

function App() {

  const [ isLoggedIn, setIsLoggedIn ] = useState(false);

  function LoginActive() {
    setIsLoggedIn(true);
  }

  function LogoutActive() {
    setIsLoggedIn(false);
  }

  function LoginButton () {
    return(
      <button onClick={LoginActive}> Login </button>
    )
  }

  function LogoutButton () {
    return(
      <button onClick={LogoutActive}> Logout </button>
    )
  }

  function Greeting(){
    // if login
    if ( isLoggedIn ){

      return (
      <div> 
      <p> Welcome, User </p>
      <LogoutButton />
      </div>
      )
    }
      return(
      <div> 
      <p> Please signUp  </p>
      <LoginButton />
      </div>
      )
    }
  
  return (
    <div className='App'>

      <Greeting />

    </div>
  )
}

export default App