import React, { useEffect, useState } from "react";
import { getArtFromApi } from "../../modules/artManager";
import ArtCard from "./ArtCard";

const ArtList = () => {

    const [ arts, setArts ] = useState([]);


    const getArt = () => {
        getArtFromApi().then(arts => setArts(arts));
    }

    useEffect(() => {
        getArt();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {arts.map((art) => (
                        <ArtCard arts={art} key={art.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default ArtList;