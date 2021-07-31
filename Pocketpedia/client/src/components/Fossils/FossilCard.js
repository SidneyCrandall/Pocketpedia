import React, { useState } from "react";
import { Card, CardBody } from "reactstrap";
import { addFossil, getFossilsFromApi } from "../../modules/fossilManager";

const FossilCard = ({ fossils }) => {

    const [fossil, setFossil] = useState({
        id: fossils.id,
        name: fossils.name,
        imageUrl: fossils.imageUrl,
        discovered: false
    });

    const handleSaveFossil = (evt) => {
        evt.preventDefault()
        addFossil({
            id: fossil.id,
            name: fossil.name,
            imageUrl: fossil.imageUrl,
            discovered: true,
            userProfileId: fossil.userProfileId
        })
            .then(() => { getFossilsFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={fossils.imageUrl} alt={fossils.name} />
                <p><b>Name: </b>{fossils.name}</p>
                <button onClick={handleSaveFossil} disabled={handleSaveFossil ? false : true}>Discovered!</button>
                
            </CardBody>
        </Card>
    )
};

export default FossilCard;