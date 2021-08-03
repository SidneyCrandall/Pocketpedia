import React, { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";

const MyArtCard = ({ art }) => {


    return (
        
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={art.imageUrl} alt={art.name} />
                <p><b>Name: </b>{art.name}</p>

            </CardBody>
        </Card>

    );
};

export default MyArtCard;