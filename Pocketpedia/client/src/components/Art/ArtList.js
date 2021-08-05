import React, { useEffect, useState } from "react";
import { Button } from "reactstrap";
import { getArtFromApi } from "../../modules/artManager";
import ArtCard from "./ArtCard";
import { Link } from "react-router-dom";


// The program uses an external API in order to pull its data.
// AFter we have representation of the data we need to list it to the DOM.  
const ArtList = () => {

    // THis will set the arry to be ready to take in the collection from the external API call
    const [ arts, setArts ] = useState([]);

    // This function handles the info to display the desired response from the API
    const getArt = () => {
        getArtFromApi().then(arts => setArts(arts));
    };

    // Render the state
    useEffect(() => {
        getArt();
    }, []);

    // Take the card created on ARTCARD and iterate over the array to display them the way the program asks
    return (
        <>
            <Link to={`/art/GetUserArt`}>
                <Button className="btn" size="lg" style={{ backgroundColor: '#BCA4BF' }} href="#pablo">My Art Collection</Button>
            </Link>

            <div className="container">
                <div className="row justify-content-center">
                    {arts.map((art) => (
                        <ArtCard arts={art} key={art.acnhApiId} />
                    ))}
                </div>
            </div>

        </>
    );
};

export default ArtList;