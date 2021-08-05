import React from "react";
import { CardBody, CardGroup, CardTitle, CardImg } from "reactstrap";
import "./Fossils.css";

// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const MyFossilsCard = ({ fossil }) => {

    return (
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">

                <CardImg src={fossil.imageUrl} alt={fossil.name} />
                <CardTitle><b>Name: </b>{fossil.name}</CardTitle>

            </CardBody>
        </CardGroup>

    );
};

export default MyFossilsCard;