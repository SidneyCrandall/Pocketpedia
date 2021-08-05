import React from "react";
import { CardBody, CardImg, CardTitle, CardGroup } from "reactstrap";
import "./Art.css";


// Styling for cards
const style = { width: "18rem" };


// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
// A user a specific info page that displays that Current logged in user's Art that they have collected.
const MyArtCard = ({ art }) => {


    return (     
       <CardGroup style={style} className="card-deck">
            <CardBody id="cardContainer" className="m-3">
                <CardImg variant="top" src={art.imageUrl} alt={art.name} ></CardImg>
                <CardTitle><b>Name: </b>{art.name}</CardTitle>
            </CardBody>
        </CardGroup>   
    );
};

export default MyArtCard;