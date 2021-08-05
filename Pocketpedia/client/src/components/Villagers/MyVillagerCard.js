import React from "react";
import { CardImg, CardBody, CardGroup, CardTitle, CardText } from "reactstrap";
import "./Villagers.css";

// Styling for cards
const style = { width: "18rem" };

const MyVillagerCard = ({ villagers }) => {

    return (
        <>
        <br />
        <CardGroup style={style} className="card-deck">
            <CardBody id="cardContainer" className="m-3">
                <CardImg variant="top" src={villagers.imageUrl} alt={villagers.name} />
                <CardTitle><b>Name: </b>{villagers.name}</CardTitle>
                <CardText><b>Birthday: </b>{villagers.birthday}</CardText>
            </CardBody>
        </CardGroup>
        </>
    );
};

export default MyVillagerCard;