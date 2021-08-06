import React, { useEffect, useState } from "react";
import { getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";
import SeaCreatureCard from "./SeaCreatureCard";
import { Link } from "react-router-dom";
import { Button } from "reactstrap";


// The program uses an external API in order to pull its data.
// After we have representation of the data we need to list it to the DOM.  
const SeaCreatureList = () => {

    const [seaCreatures, setSeaCreatures] = useState([]);

    const getSeaCreatures = () => {
        getSeaCreaturesFromApi().then(seaCreatures => setSeaCreatures(seaCreatures));
    }

    useEffect(() => {
        getSeaCreatures();
    }, []);

    return (
        <>
          <br />
            <Link to={`/seaCreatures/GetUserSeaCreature`}>
                <Button className="btn" style={{ backgroundColor: '#BCA4BF' }} href="#pablo" size="lg">My Found Sea Creatures</Button>
            </Link>
            <br />
            <h1 className="text-center">Sea Creatures to Catch</h1>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {seaCreatures.map((seaCreature) => (
                        <SeaCreatureCard seacreatures={seaCreature} key={seaCreature.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default SeaCreatureList;