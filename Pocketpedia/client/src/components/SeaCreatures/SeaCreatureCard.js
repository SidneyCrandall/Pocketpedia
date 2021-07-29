import React from "react";
import { Card, CardBody } from "reactstrap";

const SeaCreatureCard = ({ seaCreatures }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                {/* //<img src={seaCreatures.imageUrl} alt={seaCreatures.name} /> */}
                <p><b>Title: </b>{seaCreatures.name}</p>

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;