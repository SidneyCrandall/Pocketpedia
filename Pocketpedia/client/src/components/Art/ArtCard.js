import React from "react";
import { Card, CardBody } from "reactstrap";

const ArtCard = ({ art }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={art.imageUrl} alt={art.name} />
                <p><b>Title: </b>{art.name}</p>
                <p><b>Has a Fake: </b>{art.hasFake}</p>

            </CardBody>
        </Card>
    )
};

export default ArtCard;