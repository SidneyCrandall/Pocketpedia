import { getToken } from "./authManager";

const baseUrl = '/api/location';

export const getAllLocations = () => {
    return getToken().then((token) => {
        fetch(`${baseUrl}`, {
            method:"GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(resp => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occured while trying to get locatioms.") 
            }
        })
    })
}