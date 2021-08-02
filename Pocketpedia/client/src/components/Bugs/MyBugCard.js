import React, { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getBugsByUser } from "../../modules/bugManager";
import { getAllLocations } from "../../modules/locationManager";



const AllMyBugs = () => {

    const [ bugs, setBugs ] = useState([]);

    const getAllMyBugs = () => {
        return getBugsByUser()
            .then(posts => setBugs(bugs))
    }


    useEffect(() => {
        getAllMyBugs();
    }, []);  


    return (
<>
            <h1>My Posts</h1>
            <div className="container">
                <div className="row justify-content-center">
                    {bugs.map((bug) => (
                        <Bug bug={bug} key={bug.id} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default AllMyBugs;