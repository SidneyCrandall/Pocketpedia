import { getToken } from "./authManager";

const baseUrl = '/api/seaCreatures';

export const getSeaCreaturesFromApi = () => {
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
                throw new Error("An unknown error occured while trying to get sea creatures.")
            }
        })
    )
};

export const addSeaCreature = (seaCreature) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(seaCreature)
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An unknown error occured while trying to adding a Sea Creature.")
            }
        });
    });
}


export const getUserSeaCreature = () => {
    return getToken().then((token) => {
      return fetch(`${baseUrl}/GetUserSeaCreature`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).then(res => {
        if (res.ok) {
          return res.json();
        } else {
          throw new Error("An unknown error occorred while trying to fetch your posts");
        }
      });
    });
  };