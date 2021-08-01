import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { addSeaCreature, getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";

const SeaCreatureCard = ({ seacreatures }) => {

    const [ newSeacreature, setNewSeacreature ] = useState({
        id: seacreatures.id,
        acnhApiId: seacreatures.acnhApiId,
        name: seacreatures.name,
        imageUrl: seacreatures.imageUrl,
        Caught: false
    });

    const handleSaveSeaCreature = (evt) => {
        evt.preventDefault()
        addSeaCreature({
            id: newSeacreature.id,
            acnhApiId: newSeacreature.acnhApiId,
            name: newSeacreature.name,
            imageUrl: newSeacreature.imageUrl,
            Caught: true,
            userProfileId: newSeacreature.userProfileId
        })
            .then(() => { getSeaCreaturesFromApi() })
    };


    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seacreatures.imageUrl} alt={seacreatures.name} />
                <p><b>Name: </b>{seacreatures.name.toString()}</p>
                <button onClick={handleSaveSeaCreature}>Caught</button>

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;