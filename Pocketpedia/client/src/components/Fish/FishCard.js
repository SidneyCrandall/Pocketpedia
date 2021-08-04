import React, {useState} from "react";
import { Card, CardBody } from "reactstrap";
import { addFish, getFishFromApi } from "../../modules/fishManager";


// Styling for cards
const style = { width: "18rem" };


// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
// Passing the prop of fish that carries properties of that fish.
const FishCard = ({ fish }) => {


    const [newFish, setNewFish] = useState({
        id: fish.id,
        acnhApiId: fish.acnhApiId,
        name: fish.name,
        imageUrl: fish.imageUrl,
        locationId: fish.locationId,
        location: fish.locationName,
        Caught: false
    });


    const handleSaveFish = (evt) => {
        evt.preventDefault()
        addFish({
            id: newFish.id,
            acnhApiId: newFish.acnhApiId,
            name: newFish.name,
            imageUrl: newFish.imageUrl,
            userProfileId: newFish.userProfileId,
            locationId: newFish.locationId,
            caught: true
        })
            .then(() => { getFishFromApi() })
    };

    return (
        <Card style={style}>
            <CardBody className="m-3">

                <img src={fish.imageUrl} alt={fish.name} />
                <p><b>Name: </b>{fish.name}</p>
                <p><b>Location: </b>{fish.locationName}</p>

                <button onClick={handleSaveFish}>Caught</button>

            </CardBody>
        </Card>
    );
};


export default FishCard;