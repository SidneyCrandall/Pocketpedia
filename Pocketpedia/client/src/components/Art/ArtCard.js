import React, {useState} from "react";
import { Card, CardBody } from "reactstrap";
import { addArt, getArtFromApi } from "../../modules/artManager";

// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
const ArtCard = ({ arts }) => {

    // We need to render what state the object will be when it is presented to us before we send it to the database.
    const [ art, setArt ] = useState({
        id: arts.id,
        acnhApiId: arts.acnhApiId,
        name: arts.name,
        imageUrl: arts.imageUrl,
        hasFake: arts.hasFake,
        obtained: false
    });

    // The onClick handle feature that will snapshot our info to be sent to our sql database
    const handleSaveArt = (evt) => {
        evt.preventDefault()
        addArt({
            id: art.id,
            acnhApiId: art.acnhApiId,
            name: art.name,
            imageUrl: art.imageUrl,
            userProfileId: art.userProfileId,
            hasFake: art.hasFake,
            obtained: true
        })
            .then(() => { getArtFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={arts.imageUrl} alt={arts.name} />
                <p><b>Name: </b>{arts.name.toUpperCase()}</p>
                <p><b>There is a fake: </b>{arts.hasFake.toString()}</p>
                <br/>
                <button onClick={handleSaveArt}>Purchased</button>

            </CardBody>
        </Card>
    );
};

export default ArtCard;