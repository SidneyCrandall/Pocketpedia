import React from "react";
import IsabelleLoFi from '../Images/IsabelleLoFi.JPG';


const IslanderWelcome = () => {

  return (
    <div className="welcomeContainer">
      <h3>{`Hello Islander!`}</h3>
      <h4>Welcome to Pocketpedia! How would you like to relax today?</h4>
      <span  style={{
      position: "fixed",
      left: 0,
      right: 0,
      marginTop: "-0.5rem",
      textAlign: "center",
    }}><img src={IsabelleLoFi} alt="Chill Lo-fi Girl" /></span>
    </div>
  );
};

export default IslanderWelcome;