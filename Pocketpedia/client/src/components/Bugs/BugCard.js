import React from "react";
import { Card, CardBody } from "reactstrap";

const BugCard = ({ bug }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
        <CardBody className="m-3">

        <img src={bug.imageUrl} alt={bug.name} />
                <p><b>Title: </b>{bug.name}</p>
                <p><b>Location: </b>{bug.location}</p>

        </CardBody>
    </Card>
    )
};

export default BugCard;