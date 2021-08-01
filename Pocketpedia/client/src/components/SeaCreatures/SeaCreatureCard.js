import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { addSeaCreature, getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";

const SeaCreatureCard = ({ seacreatures }) => {

 

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seacreatures.imageUrl} alt={seacreatures.name} />
                <p><b>Name: </b>{seacreatures.name.toString()}</p>
                {/* <button onClick={handleSaveSeaCreature}>Caught</button> */}

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;