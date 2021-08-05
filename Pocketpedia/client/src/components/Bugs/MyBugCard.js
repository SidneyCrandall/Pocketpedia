import React from "react";
import { CardTitle, CardBody, CardGroup, CardImg } from "reactstrap";
import "./Bug.css";

// Styling for the card container
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const MyBugCard = ({ bug }) => {


    return (
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">
                <CardImg variant="top" src={bug.imageUrl} alt={bug.name} />
                <CardTitle><b>Name: </b>{bug.name}</CardTitle>
            </CardBody>
        </CardGroup>
    );
};

export default MyBugCard;