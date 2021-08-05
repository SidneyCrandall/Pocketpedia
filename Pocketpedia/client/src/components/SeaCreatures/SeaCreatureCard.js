import React, { useState } from "react";
import { CardGroup, CardBody, CardImg, CardTitle, Button } from "reactstrap";
import { addSeaCreature, getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";
import "./SeaCreature.css";


// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const SeaCreatureCard = ({ seacreatures }) => {

    const [ newSeacreature ] = useState({
        id: seacreatures.id,
        acnhApiId: seacreatures.acnhApiId,
        name: seacreatures.name,
        imageUrl: seacreatures.imageUrl,
        Caught: false
    });

    const handleSaveSeaCreature = (evt) => {
        evt.preventDefault()
        addSeaCreature({
            id: newSeacreature.id,
            acnhApiId: newSeacreature.acnhApiId,
            name: newSeacreature.name,
            imageUrl: newSeacreature.imageUrl,
            Caught: true,
            userProfileId: newSeacreature.userProfileId
        })
            .then(() => { getSeaCreaturesFromApi() })
    };


    return (
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">
                <CardImg src={seacreatures.imageUrl} alt={seacreatures.name} />
                <CardTitle><b>Name: </b>{seacreatures.name}</CardTitle>
                <br />
                <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" onClick={handleSaveSeaCreature}>Caught</Button>
            </CardBody>
        </CardGroup>
    );
};

export default SeaCreatureCard;