import { getToken } from "./authManager";

const baseUrl = '/api/fossils';

export const getFossilsFromApi = () => {
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
                throw new Error("An unknown error occured while trying to get fossils.")
            }
        }))
}