import React, { useState } from "react";
import { Button, CardBody, CardImg, CardText, CardTitle, CardGroup } from "reactstrap";
import { addArt, getArtFromApi } from "../../modules/artManager";
import "./Art.css";


// Styling for cards
const style = { width: "18rem" };


// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const ArtCard = ({ arts }) => {

    // We need to render what state the object will be when it is presented to us before we send it to the database.
    const [art] = useState({
        id: arts.id,
        acnhApiId: arts.acnhApiId,
        name: arts.name,
        imageUrl: arts.imageUrl,
        hasFake: arts.hasFake,
        obtained: false
    });

    // The onClick handle feature that will snapshot our info to be sent to our sql database
    const handleSaveArt = (evt) => {
        evt.preventDefault()
        addArt({
            id: art.id,
            acnhApiId: art.acnhApiId,
            name: art.name,
            imageUrl: art.imageUrl,
            userProfileId: art.userProfileId,
            hasFake: art.hasFake,
            obtained: true
        })
            .then(() => { getArtFromApi() })
    };

    return (

        <CardGroup style={style} className="card-deck">
            <CardBody id="cardContainer" className="m-3">
                <CardImg variant="top" src={arts.imageUrl} alt={arts.name} ></CardImg>
                <CardTitle><b>Name: </b>{arts.name.toUpperCase()}</CardTitle>
                <CardText><b>Redd sales a fake: </b>{arts.hasFake.toString()}</CardText>
                <br />
                <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" onClick={handleSaveArt}>Purchased</Button>
            </CardBody>
        </CardGroup>

    );
};

export default ArtCard;