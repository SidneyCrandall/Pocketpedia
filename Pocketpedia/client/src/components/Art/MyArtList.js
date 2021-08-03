import React, { useEffect, useState } from "react";
import MyArtCard from "./MyArtCard";

import { getUserArt } from "../../modules/artManager";

const MyArtList = () => {

    const [arts, setArts] = useState([]);

    const getMyArt = () => {
         getUserArt().then(arts => setArts(arts))
    };


    useEffect(() => {
        getMyArt();
    }, []);


        return (
            <>
            <h1>My Art</h1>
                <div className="container">
                    <div className="row justify-content-center">
                        {arts.map((art) => (
                            <MyArtCard art={art} key={art.id} />
                        ))}
                    </div>
                </div>
            </>
            );
        };
        

export default MyArtList;