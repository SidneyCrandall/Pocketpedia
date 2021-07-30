import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getBugsFromApi, addBug } from "../../modules/bugManager";

const BugCard = ({ bug }) => {

    const [ newBug, setNewBug ] = useState({
        id: bug.id, 
        acnhApiId: bug.acnhApiId,
        name : bug.name,
        imageUrl: bug.imageUrl,
        locationId: bug.locationId,
        caught: false
    });

    const handleSaveBug = (evt) => {
       evt.preventDefault()
        addBug({
            id: newBug.id,
            acnhApiId: newBug.acnhApiId,
            name : newBug.name,
            imageUrl: newBug.imageUrl,
            locationId: newBug.locationId,
            caught: true,
            userProfileId: newBug.userProfileId
        })
           .then(() => { getBugsFromApi()})
    }

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={bug.imageUrl} alt={bug.name} />
                <p><b>Title: </b>{bug.name}</p>
                <p><b>Location: </b>{bug.locationId}</p>
                <button onClick={handleSaveBug} >Caught!</button>

            </CardBody>
        </Card>
    )
};

export default BugCard;