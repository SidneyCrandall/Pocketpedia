import React, { useEffect, useState } from "react";
import { getFishFromApi } from "../../modules/fishManager";
import FishCard from "./FishCard";
import { Link } from "react-router-dom";

const FishList = () => {

    const [fishs, setFishs] = useState([]);


    const getFish = () => {
        getFishFromApi().then(fishs => setFishs(fishs));
    };

    useEffect(() => {
        getFish();
    }, []);

    return (
        <>

            <Link to={`/fish/GetUserFish`}>
                <button className="btn btn-light  m-2">My Fish</button>
            </Link>

            <div className="container">
                <div className="row justify-content-center">
                    {fishs.map((fish) => (
                        <FishCard fish={fish} key={fish.acnhApiId} />
                    ))}
                </div>
            </div>
            
        </>
    );
};


export default FishList;