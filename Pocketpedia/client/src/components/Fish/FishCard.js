import React, {useState} from "react";
import { CardGroup, CardBody, CardText, CardTitle, Button, CardImg } from "reactstrap";
import { addFish, getFishFromApi } from "../../modules/fishManager";
import "./Fish.css";


// Styling for cards
const style = { width: "18rem" };


// This page is responsible for handling the save feature of the app. 
// And it will also be a representation of how the data will be displayed
// Passing the prop of fish that carries properties of that fish.
const FishCard = ({ fish }) => {


    const [ newFish ] = useState({
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
        <CardGroup style={style} className="card-deck">
            <CardBody className="m-3">

                <CardImg variant="top"  src={fish.imageUrl} alt={fish.name} />
                <CardTitle><b>Name: </b>{fish.name}</CardTitle>
                <CardText><b>Location: </b>{fish.locationName}</CardText>
                <br />
                <Button className="btn m-3" style={{ backgroundColor: '#BCA4BF' }} href="#pablo" onClick={handleSaveFish}>Caught</Button>
            </CardBody>
        </CardGroup>
    );
};


export default FishCard;