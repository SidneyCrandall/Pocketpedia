import React, { useEffect, useState } from "react";
import MyBugCard from "./MyBugCard";
import { getUserBugs } from "../../modules/bugManager";

// The current logged in users Bug list.
const MyBugList = () => {

    const [bugs, setBugs] = useState([]);

    
    const getAllMyBugs = () => {
        getUserBugs().then(bugs => setBugs(bugs))
    };


    useEffect(() => {
        getAllMyBugs();
    }, []);


    return (
        <>
          <br />
            <h1 className="text-center">Captured Bugs</h1>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {bugs.map((bug) => (
                        <MyBugCard bug={bug} key={bug.id} />
                    ))}
                </div>
            </div>
        </>
    );
};


export default MyBugList;