import React, { useState } from "react";
import { CardImg, CardBody, CardGroup, Button, CardTitle } from "reactstrap";
import { getVillagersFromApi, addVillager } from "../../modules/villagerManager";

// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const VillagerCard = ({ villagers }) => {

    const [ villager ] = useState({
        id: villagers.id,
        acnhApiId: villagers.acnhApiId,
        name: villagers.name,
        imageUrl: villagers.imageUrl,
        birthday: villagers.birthday,
        isResiding: false
    });

    const handleSaveVillager = (evt) => {
        evt.preventDefault()
        addVillager({
            id: villager.id,
            acnhApiId: villager.acnhApiId,
            name: villager.name,
            imageUrl: villager.imageUrl,
            birthday: villager.birthday,
            isResiding: true,
            userProfileId: villager.userProfileId
        })
            .then(() => { getVillagersFromApi() })
    };

    return (
     
            <CardGroup style={style} className="card-deck">
                <CardBody id="cardContainer" className="m-3">
                    <CardImg variant="top" src={villagers.imageUrl} alt={villagers.name} />
                    <CardTitle><b>Name: </b>{villagers.name}</CardTitle>
                    <p><b>Birthday: </b>{villagers.birthday}</p>
                    <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" onClick={handleSaveVillager}>My neighbor</Button>
                </CardBody>
            </CardGroup>
    
    );
};

export default VillagerCard;