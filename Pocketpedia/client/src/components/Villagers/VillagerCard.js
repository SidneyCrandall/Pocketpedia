import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getVillagersFromApi, addVillager } from "../../modules/villagerManager";

const VillagerCard = ({ villagers }) => {

    const [villager, setVillager] = useState({
        id: villagers.id,
        acnhApiId: villagers.acnhApiId,
        name: villagers.name,
        imageUrl: villagers.imageUrl,
        birthday: villagers.birthday.birthday,
        isResiding: false
    });

    const handleSaveVillager = (evt) => {
        evt.preventDefault()
        addVillager({
            id: villager.id,
            acnhApiId: villager.acnhApiId,
            name: villager.name,
            imageUrl: villager.imageUrl,
            locationId: villager.locationId,
            isResiding: true,
            userProfileId: villager.userProfileId
        })
            .then(() => { getVillagersFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={villagers.imageUrl} alt={villagers.name} />
                <p><b>Name: </b>{villagers.name}</p>
                <p><b>Birthday: </b>{villagers.birthday}</p>

                <button onClick={handleSaveVillager}>Residing on my Island</button>

            </CardBody>
        </Card>
    )
};

export default VillagerCard;