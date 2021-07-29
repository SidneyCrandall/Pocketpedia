import React from "react";
import { Card, CardBody } from "reactstrap";

const FishCard = ({ fish }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={fish.imageUrl} alt={fish.name} />
                <p><b>Title: </b>{fish.name}</p>
                <p><b>Location: </b>{fish.location}</p>

            </CardBody>
        </Card>
    )
};

export default FishCard;