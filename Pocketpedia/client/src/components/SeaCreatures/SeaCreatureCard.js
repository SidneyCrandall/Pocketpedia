import React from "react";
import { Card, CardBody } from "reactstrap";

const SeaCreatureCard = ({ seacreatures }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seacreatures.imageUrl} alt={seacreatures.name} />
                <p><b>Title: </b>{seacreatures.name}</p>

            </CardBody>
        </Card>
    )
};

export default SeaCreatureCard;