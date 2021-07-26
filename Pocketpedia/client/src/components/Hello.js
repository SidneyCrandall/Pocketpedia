import React from "react";
import UserCard from "./UserProfile/UserCard";
//import ACNHLoFi from '../Images/ACNHLoFi.jpg';

export default function Hello() {
  return (
    <>
      <span style={{
        position: "fixed",
        left: 0,
        right: 0,
        top: "50%",
        marginTop: "-0.5rem",
        textAlign: "center",
      }}>Hello, Welcome to Pocketpedia</span>
      <UserCard />
      {/* <img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl" /> */}
    </>
  );
}