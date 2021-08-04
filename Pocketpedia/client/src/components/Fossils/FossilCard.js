import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { addFossil, getFossilsFromApi } from "../../modules/fossilManager";

// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const FossilCard = ({ fossils }) => {

    const [fossil] = useState({
        id: fossils.id,
        name: fossils.name,
        imageUrl: fossils.imageUrl,
        discovered: false
    });


    const handleSaveFossil = (evt) => {
        evt.preventDefault()
        addFossil({
            id: fossil.id,
            name: fossil.name,
            imageUrl: fossil.imageUrl,
            discovered: true,
            userProfileId: fossil.userProfileId
        })
            .then(() => { getFossilsFromApi() })
    };

    return (
        <Card style={style}>
            <CardBody className="m-3">

                <img src={fossils.imageUrl} alt={fossils.name} />
                <p><b>Name: </b>{fossils.name}</p>
                <button onClick={handleSaveFossil} disabled={handleSaveFossil ? false : true}>Discovered!</button>
                
            </CardBody>
        </Card>
    )
};

export default FossilCard;