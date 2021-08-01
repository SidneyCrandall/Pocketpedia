import React, { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getBugsFromApi, addBug } from "../../modules/bugManager";
import { getAllLocations } from "../../modules/locationManager";

const BugCard = ({ bug }) => {

    const [newBug, setNewBug] = useState({
        id: bug.id,
        acnhApiId: bug.acnhApiId,
        name: bug.name,
        imageUrl: bug.imageUrl,
        locationId: bug.locationId,
        caught: false
    });

    // const name = location.map((locationName => {
    //     return`${locationName.name}`
    // }))

    // useEffect(() => {
    //     getAllLocations()
    //         .then(locationsFromApi => {
    //             setLocations(locationsFromApi)
    //         });
    // }, []);


    const handleSaveBug = (evt) => {
        evt.preventDefault()
        addBug({
            id: newBug.id,
            acnhApiId: newBug.acnhApiId,
            name: newBug.name,
            imageUrl: newBug.imageUrl,
            locationId: newBug.locationId,
            caught: true,
            userProfileId: newBug.userProfileId
        })
            .then(() => { getBugsFromApi() })
    };

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
            <CardBody className="m-3">

                <img src={bug.imageUrl} alt={bug.name} />
                <p><b>Name: </b>{bug.name}</p>              
                <p><b>Location: </b>{bug.locationId.name}</p>                
                <button onClick={handleSaveBug} disabled={handleSaveBug ? false : true}>Caught!</button>

            </CardBody>
        </Card>
    )
};

export default BugCard;