import React from "react";
import "./App.css"; 
import image from './image.png'


// Ive designed like an realtime rental app fetching more than 1 setupspace from an array.
const App = () => {
  const element = "Office Space";

  const sr = image; 
  const jsxatt = <img src={sr} width="25%" height="25%" alt="Office Space" />;

  const officeList = [
    { Name: "DBS", Rent: 50000, Address: "Chennai" },
    { Name: "CTS", Rent: 62000, Address: "Bangalore" }
  
  ];

  return (
    <div className="App">
      <h1>{element}, at Affordable Range</h1>
      <br />
      <h2>Available Office Spaces:</h2>
      {officeList.map((item, index) => {
        let colors = [];
        if (item.Rent <= 60000) {
          colors.push("textRed");
        } else {
          colors.push("textGreen");
        }

        return (
          <div key={index} className="officeDesign">
            {jsxatt}
            <h3>Name: {item.Name} </h3>
            <h3 className={colors.join(" ")}>
              Rent: Rs. {item.Rent}
            </h3>
            <h3>Address: {item.Address} </h3>
          </div>
        );
      })}
    </div>
  );
};

export default App;
