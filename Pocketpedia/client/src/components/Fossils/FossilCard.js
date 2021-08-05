import React, { useState } from "react";
import { CardGroup, CardBody, CardTitle, Button, CardImg } from "reactstrap";
import { addFossil, getFossilsFromApi } from "../../modules/fossilManager";
import "./Fossils.css";

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

        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">
                <CardImg variant="top" src={fossils.imageUrl} alt={fossils.name} />
                <CardTitle><b>Name: </b>{fossils.name}</CardTitle>
                <br />
                <Button onClick={handleSaveFossil}  style={{ backgroundColor: '#BCA4BF' }} href="#pablo">Discovered!</Button>          
            </CardBody>
        </CardGroup>
        
    )
};

export default FossilCard;