import React, { useState } from "react";
import { Card, CardBody, CardGroup } from "reactstrap";
import { getVillagersFromApi, addVillager } from "../../modules/villagerManager";

// Styling for cards
const style = { width: "18rem" };

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const VillagerCard = ({ villagers }) => {

    const [villager, setVillager] = useState({
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
        <Card stlye={style}>
            <CardGroup className="card-deck">
                <CardBody id="cardContainer" className="m-3">
                    <img src={villagers.imageUrl} alt={villagers.name} />
                    <p><b>Name: </b>{villagers.name}</p>
                    <p><b>Birthday: </b>{villagers.birthday}</p>

                    <button onClick={handleSaveVillager}>Residing on my Island</button>
                </CardBody>
            </CardGroup>
        </Card>
    )
};

export default VillagerCard;