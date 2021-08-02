import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom"
import { getBugsFromApi } from "../../modules/bugManager";
import BugCard from "./BugCard";

const BugList = () => {

    const [bugs, setBugs] = useState([]);

    const getBugs = () => {
        getBugsFromApi().then(bugs => setBugs(bugs));
    }

    useEffect(() => {
        getBugs();
    })

    return (
        <>
            <Link to={`/bugs/GetBugByUser`}>
                <button>Bug</button>
            </Link>
            <div className="container">
                <div className="row justify-content-center">
                    {bugs.map((bug) => (
                        <BugCard bug={bug} key={bug.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default BugList;