import React, { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";
import { allBugCard } from "./BugCard";

// export default function allBugCard({ isLoggedIn }) {
//     return (
//         <main>
//             <Switch>

//                 <Route path="/allBugCard">
//                     <allBugCard />
//                 </Route>

//                 </Switch>
//         </main>
//     )};

const AllBugList = ({ bug }) => {

    return (
        <Card className="m-2 p-2 w-50 mx-auto">
        <CardBody className="m-3">

            <img src={bug.imageUrl} alt={bug.name} />
            <p><b>Name: </b>{bug.name}</p>                             

        </CardBody>
    </Card>
    );
};

export default AllBugList;