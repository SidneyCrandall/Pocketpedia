import React, { useEffect, useState } from "react";
import { getFishFromApi } from "../../modules/fishManager";
import FishCard from "./FishCard";
import { Link } from "react-router-dom";
import { Button } from "reactstrap";

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
                <Button className="btn" style={{ backgroundColor: '#BCA4BF' }} href="#pablo">My Fish</Button>
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