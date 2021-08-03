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
        })
    )
};

export const addFossil = (fossil) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(fossil)
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An error occured trying to add Fossils.")
            }
        });
    });
};

export const getUserFossils = () => {
    return getToken().then((token) => {
      return fetch(`${baseUrl}/GetUserFossil`, {
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