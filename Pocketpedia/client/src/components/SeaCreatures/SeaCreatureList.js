import React, { useEffect, useState } from "react";
import { getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";
import SeaCreatureCard from "./SeaCreatureCard";

const SeaCreatureList = () => {

    const [ seaCreatures, setSeaCreatures ] = useState([]);

    const getSeaCreatures = () => {
        getSeaCreaturesFromApi().then(seaCreatures => setSeaCreatures(seaCreatures));
    }

    useEffect(() => {
        getSeaCreatures();
    })

    return (
        <>
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