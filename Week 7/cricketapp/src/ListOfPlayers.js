import React from "react";

const players = [
  { name: "K L Rahul", score: 92 },
  { name: "Rohit", score: 45 },
  { name: "Virat", score: 89 },
  { name: "Iyer", score: 66 },
  { name: "Raina", score: 35 },
  { name: "Yuvi", score: 77 },
  { name: "Dhoni", score: 54 },
  { name: "Jadeja", score: 81 },
  { name: "Hardik", score: 70 },
  { name: "Shami", score: 49 },
  { name: "Bhuvi", score: 49 },
];

export const ListOfPlayers = () => {
  return players.map((player) => {
    return (
      <div>
        <li>
          Mr. {player.name}
          <span> {player.score}</span>
        </li>
      </div>
    );
  });
};

export const FilteredPlayers = () => {
  return players.map((player) => {
    if (player.score <= 70) {
      return (
        <div>
          <li>
            Mr. {player.name}
            <span> {player.score}</span>
          </li>
        </div>
      );
    }
  });
};
