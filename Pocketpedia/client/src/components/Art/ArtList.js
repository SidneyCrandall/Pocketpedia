import React, { useEffect, useState } from "react";
import { getArtFromApi } from "../../modules/artManager";
import ArtCard from "./ArtCard";

const ArtList = () => {

    const [ art, setArt ] = useState([]);

    const getArt = () => {
        getArtFromApi().then(art => setArt(art));
    }

    useEffect(() => {
        getArt();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {art.map((art) => (
                        <ArtCard art={art} key={art.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default ArtList;