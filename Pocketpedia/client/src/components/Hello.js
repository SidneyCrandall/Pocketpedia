import React from "react";
import ACNHLoFi from '../Images/ACNHLoFi.jpg';

export default function Hello() {
  return (
    <>
      <h1>Hello, Welcome to Pocketpedia</h1>
      <span style={{
        position: "fixed",
        left: 0,
        right: 0,
        top: "50%",
        marginTop: "-0.5rem",
        textAlign: "center",
      }}> <img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl" /></span>
     {/* <img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl" />  */}
    </>
  );
}