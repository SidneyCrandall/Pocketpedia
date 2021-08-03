import { getToken } from "./authManager";

const baseUrl = '/api/villagers';

export const getVillagersFromApi = () => {
    return getToken().then((token) =>
        fetch(`${baseUrl}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(resp => {
           
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occured while trying to get villagers.")
            }
        })
    )};

export const addVillager = (villager) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}`, {
            method: "POST", 
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(villager)
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An unknown error occured while trying to add a villager.")
            }
        });
    });
};

export const getUserVillagers = () => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}/GetUserVillagers`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An unknown error occurred while grabbing your Villagers.")
            }
        })
    })
}