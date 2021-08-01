import React, { useState, useEffect } from "react";
import { getFishFromApi } from "../../modules/fishManager";
import FishCard from "./FishCard";

const FishList = () => {

    const [ fishes, setFishes ] = useState([]);

    const getFish = () => {
        getFishFromApi().then(fishes => setFishes(fishes));
    }

    useEffect(() => {
        getFish();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {fishes.map((fish) => (
                        <FishCard fish={fish} key={fish.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default FishList;