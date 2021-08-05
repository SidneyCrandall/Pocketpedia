import React, { useState } from "react";
import { CardTitle, CardBody, CardGroup, Button, CardImg } from "reactstrap";
import { getBugsFromApi, addBug } from "../../modules/bugManager";



// Styling for the card container
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const BugCard = ({ bug }) => {

    const [newBug] = useState({
        id: bug.id,
        acnhApiId: bug.acnhApiId,
        name: bug.name,
        imageUrl: bug.imageUrl,
        locationId: bug.locationId,
        location: bug.locationName,
        caught: false
    });

    const handleSaveBug = (evt) => {
        evt.preventDefault()
        addBug({
            id: newBug.id,
            acnhApiId: newBug.acnhApiId,
            name: newBug.name,
            imageUrl: newBug.imageUrl,
            locationId: newBug.locationId,
            caught: true,
            userProfileId: newBug.userProfileId
        })
            // I would like the page to stay on the generated API list
            .then(() => { getBugsFromApi() })
    };


    return (

        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">
                <CardImg variant="top"  src={bug.imageUrl} alt={bug.name} />
                <CardTitle><b>Name: </b>{bug.name}</CardTitle>
                <CardTitle><b>Location: </b>{bug.locationName}</CardTitle>
                <br />
                <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" onClick={handleSaveBug} size="lg">Caught!</Button>
            </CardBody>
        </CardGroup>

    );
};

export default BugCard;