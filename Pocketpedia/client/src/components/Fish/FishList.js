import React, { useEffect, useState } from "react";
import { getFishFromApi } from "../../modules/fishManager";
import FishCard from "./FishCard";

const FishList = () => {

    const [ fishs, setFishs ] = useState([]);


    const getFish = () => {
        getFishFromApi().then(fishs => setFishs(fishs));
    }

    useEffect(() => {
        getFish();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {fishs.map((fish) => (
                        <FishCard fish={fish} key={fish.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};
export default FishList;