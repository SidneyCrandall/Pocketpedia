import React, { useEffect, useState } from "react";
import MyFossilsCard from "./MyFossilCard";
import { getUserFossils } from "../../modules/fossilManager";


// This page controls the render of a list of user specific info. 
const MyFossilList = () => {

    const [fossils, setFossils] = useState([]);


    const getAllMyFossils = () => {
        getUserFossils().then(fossils => setFossils(fossils))
    };


    useEffect(() => {
        getAllMyFossils();
    }, []);


    return (
        <>
          <br />
            <h1 className="text-center">Unearthed Fossils</h1>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {fossils.map((fossil) => (
                        <MyFossilsCard fossil={fossil} key={fossil.id} />
                    ))}
                </div>
            </div>
        </>
    );
};


export default MyFossilList;