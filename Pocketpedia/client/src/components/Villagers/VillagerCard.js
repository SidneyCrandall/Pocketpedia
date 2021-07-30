import React from "react";
import { Card, CardBody } from "reactstrap";

const VillagerCard = ({ villagers }) => {


    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={villagers.imageUrl} alt={villagers.name} />
                <p><b>Name: </b>{villagers.name}</p>
                <p><b>Birthday: </b>{villagers.birthday}</p>

            </CardBody>
        </Card>
    )
};

export default VillagerCard;