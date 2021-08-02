import React, { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";
import { getBugsByUser } from "../../modules/bugManager";
import AllBugList from "./AllBugList";



const MyBugCard = () => {

    const [bugs, setBugs] = useState([]);

    const getAllMyBugs = () => {
        return getBugsByUser()
            .then(bugs => setBugs(bugs))
    }


    useEffect(() => {
        getAllMyBugs();
    }, []);


    return (
        <>
            <h1>My Bugs</h1>
            <div className="container">
                <div className="row justify-content-center">
                    {bugs.map((bug) => (
                        <AllBugList bug={bug} key={bug.id} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default MyBugCard;