import React, { useEffect, useState } from "react";
import MyFishCard from "./MyFishCard";
import { getUserFish } from "../../modules/fishManager";

// Handling of the currently looged in user's fish list
const MyFishList = () => {


    const [fishs, setFishs] = useState([]);


    const getAllMyFish = () => {
        getUserFish().then(fishs => setFishs(fishs))
    };

    useEffect(() => {
        getAllMyFish();
    }, []);


    return (
        <>
            <h1 className="text-center">My Fish</h1>
            <div className="container">
                <div className="row justify-content-center">
                    {fishs.map((fish) => (
                        <MyFishCard fish={fish} key={fish.id} />
                    ))}
                </div>
            </div>
        </>
    );
};


export default MyFishList;