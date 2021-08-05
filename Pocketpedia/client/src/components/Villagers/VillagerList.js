import React, { useEffect, useState } from "react";
import { getVillagersFromApi } from "../../modules/villagerManager";
import VillagerCard from "./VillagerCard";
import { Link } from 'react-router-dom';
import { Button } from "reactstrap";

const VillagerList = () => {

    const [villagers, setVillagers] = useState([]);


    const getVillagers = () => {
        getVillagersFromApi().then(villagers => setVillagers(villagers));
    }

    useEffect(() => {
        getVillagers();
    })

    return (
        <>
            <div className="row justify-content-center">
                <Link to={`/villagers/GetUserVillagers`}>
                    <Button style={{ backgroundColor: '#BCA4BF' }} href="#pablo" className="btn" size="lg">My Island Villagers</Button>
                </Link>
            </div>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {villagers.map((villager) => (
                        <VillagerCard villagers={villager} key={villager.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default VillagerList;