import React, { useEffect, useState } from "react";
import MySeaCreatureCard from "./MySeaCreatureCard";
import { getUserSeaCreature } from "../../modules/seaCreatureManager";

// Handling of a user's Sea Creatures that have caught
const MySeaCreatureList = () => {

    const [seacreatures, setSeaCreatures] = useState([]);

    const getAllMySeaCreatures = () => {
         getUserSeaCreature().then(seacreatures => setSeaCreatures(seacreatures))
    };


    useEffect(() => {
        getAllMySeaCreatures();
    }, []);


        return (
            <>
                <h1>My Sea Creatures</h1>
                <div className="container">
                    <div className="row justify-content-center">
                        {seacreatures.map((seacreature) => (
                            <MySeaCreatureCard seacreature={seacreature} key={seacreature.id} />
                        ))}
                    </div>
                </div>
            </>
            );
        };
        

export default MySeaCreatureList;