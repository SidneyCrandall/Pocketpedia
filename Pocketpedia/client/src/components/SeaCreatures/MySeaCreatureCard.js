import React from "react";
import { CardGroup, CardBody, CardImg, CardTitle } from "reactstrap";
import "./SeaCreature.css";


// Styling for cards
const style = { width: "18rem" };


const MySeaCreatureCard = ({ seacreature }) => {

    return (
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">
                <CardImg src={seacreature.imageUrl} alt={seacreature.name} />
                <CardTitle><b>Name: </b>{seacreature.name}</CardTitle>
            </CardBody>
        </CardGroup>
    );
};

export default MySeaCreatureCard;