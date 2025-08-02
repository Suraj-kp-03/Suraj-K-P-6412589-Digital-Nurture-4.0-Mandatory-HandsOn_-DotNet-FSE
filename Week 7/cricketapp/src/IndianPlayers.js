import React from "react";

const IndianTeam = [
  "Sachin1",
  "Dhoni2",
  "Virat3",
  "Rohit4",
  "Yuvaraj5",
  "Raina6"
];

const T20Players = ["First Player", "Second Player", "Third Player"];
const RanjiTrophyPlayers = ["Fourth Player", "Fifth Player", "Sixth Player"];
export const IndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

export const OddPlayers = () => {
  const [first, , third, , fifth] = IndianTeam;

  return (
    <div>
      <li>First : {first}</li>
      <li>Third : {third}</li>
      <li>Fifth : {fifth}</li>
    </div>
  );
};

export const EvenPlayers = () => {
  const [, second, , fourth, , sixth] = IndianTeam;

  return (
    <div>
      <li>Second : {second}</li>
      <li>Fourth : {fourth}</li>
      <li>Sixth : {sixth}</li>
    </div>
  );
};

export const ListofIndianPlayers = ({ IndianPlayers }) => {
  return IndianPlayers.map((player) => {
    return (
      <div>
        <li>Mr. {player}</li>
      </div>
    );
  });
};
