import { getToken } from "./authManager";

const baseUrl = '/api/fish';

export const getFishFromApi = () => {
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
                throw new Error("An unknown error occured while trying to get fish.")
            }
        }))
};

export const addFish = (fish) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(fish)
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An unknown error occured while trying to add a Fish.")
            }
        });
    });
};

export const getAllFish = () => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}/GetAllFish`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("Something happened while attempting to fetch your fish")
            }
        })
    })
};