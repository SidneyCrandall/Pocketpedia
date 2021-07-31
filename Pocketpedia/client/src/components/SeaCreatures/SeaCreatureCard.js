import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { addSeaCreature, getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";

const SeaCreatureCard = ({ seaCreatures }) => {

    const [ seaCreature, setSeaCreature ] = useState({
        id: seaCreature.id,
        acnhApiId: seaCreature.acnhApiId,
        name: seaCreature.name,
        imageUrl: seaCreature.imageUrl,
        Caught: false
    });

    const handleSaveSeaCreature = (evt) => {
        evt.preventDefault()
        addSeaCreature({
            id: seaCreature.id,
            acnhApiId: seaCreature.acnhApiId,
            name: seaCreature.name,
            imageUrl: seaCreature.imageUrl,
            Caught: true,
            userProfileId: seaCreature.userProfileId
        })
            .then(() => { getSeaCreaturesFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seaCreatures.imageUrl} alt={seaCreatures.name} />
                <p><b>Name: </b>{seaCreatures.name}</p>
                <button onClick={handleSaveSeaCreature}>Caught</button>

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;