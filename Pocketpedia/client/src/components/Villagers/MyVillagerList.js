import React, { useState, useEffect } from 'react';
import { getUserVillagers } from '../../modules/villagerManager';
import MyVillagerCard from "./MyVillagerCard";

const MyVillagerList = () => {

    const [villagers, setVillagers] = useState([]);

    const getMyVillagers = () => {
        getUserVillagers().then(villagers => setVillagers(villagers));
    };

    useEffect(() => {
        getMyVillagers();
    }, []);

    return (
        <>
            <br />
            <h1 className="text-center">Villagers on my island!</h1>
            <br />
            <div className="container">
                <div className="row justify-content-center">
                    {villagers.map((villager) => (
                        <MyVillagerCard villagers={villager} key={villager.acnhApiId} />
                    ))}
                </div>
            </div>
        </>
    );
};

export default MyVillagerList;