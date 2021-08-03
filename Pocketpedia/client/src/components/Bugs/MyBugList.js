import React, { useEffect, useState } from "react";
import MyBugCard from "./MyBugCard";
import { getUserBugs } from "../../modules/bugManager";

const MyBugList = ({ bug }) => {

    const [bugs, setBugs] = useState([]);

    const getAllMyBugs = () => {
        return getUserBugs()
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
                            <MyBugCard bug={bug} key={bug.id} />
                        ))}
                    </div>
                </div>
            </>
            );
        };

export default MyBugList;