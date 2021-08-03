import React from "react";
import { Card, CardBody } from "reactstrap";

const MyFishCard = ({ fish }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={fish.imageUrl} alt={fish.name} />
                <p><b>Name: </b>{fish.name}</p>

            </CardBody>
        </Card>

    );
};

export default MyFishCard;