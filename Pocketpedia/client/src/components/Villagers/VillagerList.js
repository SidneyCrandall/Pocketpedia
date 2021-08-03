import React, { useEffect, useState } from "react";
import { getVillagersFromApi } from "../../modules/villagerManager";
import VillagerCard from "./VillagerCard";
import { Link } from 'react-router-dom';

const VillagerList = () => {

    const [ villagers, setVillagers ] = useState([]);


    const getVillagers = () => {
        getVillagersFromApi().then(villagers => setVillagers(villagers));
    }

    useEffect(() => {
        getVillagers();
    })

    return (
        <>
            <Link to={`/villagers/GetUserVillagers`}>
                <button className="btn btn-light  m-2">My Villagers</button>
            </Link>
            <div className="container">
                <div className="row justify-content-center">
                    {villagers.map((villager) => (
                        <VillagerCard villagers={villager} key={villager.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    )
};

export default VillagerList;