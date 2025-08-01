import React from "react";
import { ListOfPlayers, FilteredPlayers } from "./ListOfPlayers";
import { OddPlayers, EvenPlayers, IndianPlayers, ListofIndianPlayers } from "./IndianPlayers";

function App() {
  var flag = false;

  if (flag === true) {
    return (
      <div>
        <h1>Indian Team</h1>
        <h1>List of Players</h1>
        <ListOfPlayers />
        <hr />
        <h1>List of Players having Scores Less than 70</h1>
        <FilteredPlayers />
      </div>
    );
  } 
  else {
    return (
      <div>
        <div>
          <h1>Indian Team</h1>
          <h1>Odd Players</h1>
          <OddPlayers />
          <hr />
          <h1>Even Players</h1>
          <EvenPlayers />
        </div>
        <hr />
        <div>
          <h1>List of Indian Players Merged:</h1>
          <ListofIndianPlayers IndianPlayers={IndianPlayers} />
        </div>
      </div>
    );
  }
}

export default App;
