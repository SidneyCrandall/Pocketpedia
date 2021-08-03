import React from "react";
import { Card, CardBody } from "reactstrap";

const MyFossilsCard = ({ fossil }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={fossil.imageUrl} alt={fossil.name} />
                <p><b>Name: </b>{fossil.name}</p>

            </CardBody>
        </Card>

    );
};

export default MyFossilsCard;