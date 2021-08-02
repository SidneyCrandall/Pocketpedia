import React, { useEffect, useState } from "react";
import ACNHLoFi from '../Images/ACNHLoFi.jpg';
import { _doesUserExist } from "../modules/authManager";
import firebase from "firebase/app";
import "firebase/auth";

export const IslanderWelcome = () => {
  const [currentUser, setCurrentUser] = useState({ DisplayName: "" });

  const user = firebase.auth().currentUser;

  const getIslander = () => {
    if (firebase.auth().currentUser !== null) {
      _doesUserExist(firebase.auth().currentUser.id)
        .then(user => {
          setCurrentUser(user);
        })
    }
  }

  useEffect(() => {
    getIslander();
  }, [])

  return (
    <div className="welcomeContainer">
      <h3>{`Hello ${currentUser?.DisplayName}!`}</h3>
      <h4>Welcome to Pocketpedia! How would you like to relax today?</h4>
      <span><img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl" /></span>
    </div>
  );
};