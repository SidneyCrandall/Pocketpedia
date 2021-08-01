import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getFishFromApi, addFish } from "../../modules/fishManager";

const FishCard = ({ fish }) => {

    const [newFish, setNewFish] = useState({
        id: fish.id,
        acnhApiId: fish.acnhApiId,
        name: fish.name,
        imageUrl: fish.imageUrl,
        locationId: fish.locationId,
        caught: false
    });

    const handleSaveFish = (evt) => {
        evt.preventDefault()
        
        addFish({
            id: newFish.id,
            acnhApiId: newFish.acnhApiId,
            name: newFish.name,
            imageUrl: newFish.imageUrl,
            locationId: newFish.locationId,
            caught: true,
            userProfileId: newFish.userProfileId
           
        })
            .then(() => { getFishFromApi() })        
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={fish.imageUrl} alt={fish.name} /> 
                <p><b>Name: </b>{fish.name}</p>
                <p><b>Location: </b>{fish.locationId}</p>
                <button onClick={handleSaveFish}>Caught!</button>

            </CardBody>
        </Card>
    )
};

export default FishCard;