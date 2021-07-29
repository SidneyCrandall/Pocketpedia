import React, { useEffect, useState } from "react";
import { getSeaCreaturesFromApi } from "../../modules/seaCreatureManager";
import SeaCreatureCard from "./SeaCreatureCard";

const SeaCreatureList = () => {

    const [ seacreatures, setSeaCreatures ] = useState([]);

    const getSeaCreatures = () => {
        getSeaCreaturesFromApi().then(seacreatures => setSeaCreatures(seacreatures));
    }

    useEffect(() => {
        getSeaCreatures();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {seacreatures.map((seacreatures) => (
                        <SeaCreatureCard seacreatures={seacreatures} key={seacreatures.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default SeaCreatureList;