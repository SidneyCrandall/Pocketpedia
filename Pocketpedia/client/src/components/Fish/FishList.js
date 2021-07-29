import React, { useEffect, useState } from "react";
import { getFishFromApi } from "../../modules/fishManager";
import FishCard from "./FishCard";

const FishList = () => {

    const [ fish, setFish ] = useState([]);

    const getFish = () => {
        getFishFromApi().then(fish => setFish(fish));
    }

    useEffect(() => {
        getFish();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {fish.map((fish) => (
                        <FishCard fish={fish} key={fish.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default FishList;