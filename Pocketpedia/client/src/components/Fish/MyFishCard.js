import React from "react";
import { CardGroup, CardBody, CardTitle, CardImg } from "reactstrap";
import "./Fish.css";


// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
// Passing the prop of fish that carries properties of that fish.
const MyFishCard = ({ fish }) => {

    return (
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">

                <CardImg variant="top"  src={fish.imageUrl} alt={fish.name} />
                <CardTitle><b>Name: </b>{fish.name}</CardTitle>
                <p><b>Name: </b>{fish.name}</p>

                </CardBody>
        </CardGroup>
    );
};

export default MyFishCard;