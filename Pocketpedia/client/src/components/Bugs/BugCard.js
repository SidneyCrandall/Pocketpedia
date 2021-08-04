import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getBugsFromApi, addBug } from "../../modules/bugManager";

// Styling for the card container
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const BugCard = ({ bug }) => {

    const [newBug, setNewBug] = useState({
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
        <Card style={style}>
            <CardBody className="m-3">

                <img src={bug.imageUrl} alt={bug.name} />
                <p><b>Name: </b>{bug.name}</p>              
                <p><b>Location: </b>{bug.locationName}</p>    
                            
                <button onClick={handleSaveBug}>Caught!</button>

            </CardBody>
        </Card>
    )
};

export default BugCard;