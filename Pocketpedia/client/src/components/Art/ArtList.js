import React, { useEffect, useState } from "react";
import { getArtFromApi } from "../../modules/artManager";
import ArtCard from "./ArtCard";
import { Link } from "react-router-dom";

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
            <Link to={`/art/GetUserArt`}>
                <button className="btn btn-light  m-2">My Art</button>
            </Link>
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