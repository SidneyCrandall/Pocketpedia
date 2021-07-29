import React from "react";
import { Card, CardBody } from "reactstrap";

const SeaCreatureCard = ({ seaCreature }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seaCreature.imageUrl} alt={seaCreature.name} />
                <p><b>Title: </b>{seaCreature.name}</p>

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;