import React, { useEffect, useState } from "react";
import MyArtCard from "./MyArtCard";

import { getUserArt } from "../../modules/artManager";

const MyArtList = () => {

    const [arts, setArts] = useState([]);

    // This time instead of getting the art from the API, it needs to be pulled for a specific user, 
    const getMyArt = () => {
        getUserArt().then(arts => setArts(arts))
    };


    useEffect(() => {
        getMyArt();
    }, []);


    return (
        <>
          <br />
            <h1 className="text-center">My Gallery</h1>
            <br />
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