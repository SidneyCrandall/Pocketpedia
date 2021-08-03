import React from "react";
import { Card, CardBody } from "reactstrap";


const MySeaCreatureCard = ({ seacreature }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={seacreature.imageUrl} alt={seacreature.name} />
                <p><b>Name: </b>{seacreature.name}</p>

            </CardBody>
        </Card>
    );
};

export default MySeaCreatureCard;