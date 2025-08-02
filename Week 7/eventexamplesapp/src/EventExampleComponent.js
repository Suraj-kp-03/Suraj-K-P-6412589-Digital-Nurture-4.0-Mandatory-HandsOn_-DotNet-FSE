import React from 'react'
import { useState } from 'react';

function EventExampleComponent() {

    const [count, setCount] = useState(0);
    const welcome = "This is Welcome Message";
    const incAlert = " Increment was done";

    const incrementCount = () => {
        setCount(prevCount => prevCount+1);

    };
    function alertForIncerement() {
        alert(incAlert);
    }

    const incerement = () => {
        incrementCount();
        alertForIncerement();
    };

    function WelcomeMsg(){
        alert(welcome);
    }
    function clickOn() {
        alert("I was Clicked");
    }
    function decrement() {
        setCount(prevCount => prevCount-1);

    }
  return (
    <>
    {count}
    <br />
    <button onClick={incerement}> incerement </button>  
    <br />
    <button onClick={decrement}> decrement </button>  
    <br />
    <button onClick={WelcomeMsg}> Welcome </button> 
    <br />
    <button onClick={clickOn}> Click on me </button>
    <br />
    </> 
)
}

export default EventExampleComponent