import React, { useEffect, useState } from "react";
import { getFossilsFromApi } from "../../modules/fossilManager";
import FossilCard from "./FossilCard";

const FossilList = () => {

    const [ fossils, setFossils ] = useState([]);

    const getFossils = () => {
        getFossilsFromApi().then(fossils => setFossils(fossils));
    }

    useEffect(() => {
        getFossils();
    })

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    {fossils.map((fossil) => (
                        <FossilCard fossil={fossil} key={fossil.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default FossilList;