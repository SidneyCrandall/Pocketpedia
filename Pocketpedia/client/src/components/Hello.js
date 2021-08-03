import React from "react";
import ACNHLoFi from '../Images/ACNHLoFi.jpg';


const IslanderWelcome = () => {

  return (
    <div className="welcomeContainer">
      <h3>{`Hello !`}</h3>
      <h4>Welcome to Pocketpedia! How would you like to relax today?</h4>
      <span><img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl" /></span>
    </div>
  );
};

export default IslanderWelcome;