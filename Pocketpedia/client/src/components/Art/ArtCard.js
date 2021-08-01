import React, {useState} from "react";
import { Card, CardBody } from "reactstrap";
import { addArt, getArtFromApi } from "stream";

const ArtCard = ({ art }) => {

    const [newArt, setNewArt] = useState({
        id: art.id,
        acnhApiId: art.acnhApiId,
        name: art.name,
        imageUrl: art.imageUrl,
        hasFake: art.hasFake,
        obtained: false
    });

    const handleSaveArt = (evt) => {
        evt.preventDefault()
        addArt({
            id: newArt.id,
            acnhApiId: newArt.acnhApiId,
            name: newArt.name,
            imageUrl: newArt.imageUrl,
            hasFake: newArt.hasFake,
            obtained: true,
            userProfileId: newArt.userProfileId
        })
            .then(() => { getArtFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={art.imageUrl} alt={art.name} />
                <p><b>Name: </b>{art.name}</p>
                <p><b>There is a fake: </b>{art.hasFake.toString()}</p>
                <button onClick={handleSaveArt}>Purchased!</button>

            </CardBody>
        </Card>
    )
};

export default ArtCard;