import React, { useEffect, useState } from "react";
import { getFossilsFromApi } from "../../modules/fossilManager";
import FossilCard from "./FossilCard";
import { Link } from "react-router-dom";
import { Button } from "reactstrap";


const FossilList = () => {

    const [fossils, setFossils] = useState([]);

    const getFossils = () => {
        getFossilsFromApi().then(fossils => setFossils(fossils));
    };

    useEffect(() => {
        getFossils();
    }, []);

    return (
        <>
            <Link to={`/fossils/GetUserFossil`}>
                <Button className="btn" style={{ backgroundColor: '#BCA4BF' }} href="#pablo" size="lg">My Discovered Fossils</Button>
            </Link>

            <div className="container">
                <div className="row justify-content-center">
                    {fossils.map((fossil) => (
                        <FossilCard fossils={fossil} key={fossil.name} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default FossilList;
