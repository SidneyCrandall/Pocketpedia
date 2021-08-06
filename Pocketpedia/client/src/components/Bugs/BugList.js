import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Button } from "reactstrap";
import { getBugsFromApi } from "../../modules/bugManager";
import BugCard from "./BugCard";

const BugList = () => {

    const [bugs, setBugs] = useState([]);

    const getBugs = () => {
        getBugsFromApi().then(bugs => setBugs(bugs));
    };

    useEffect(() => {
        getBugs();
    }, []);

    return (
        <>
          <br />
            <Link to={`/bugs/GetUserBugs`}>
                <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" className="btn" size="lg">My Caught Bugs</Button>
            </Link>
            <br />
            <h1 className="text-center">Bug List</h1>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {bugs.map((bug) => (
                        <BugCard bug={bug} key={bug.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default BugList;