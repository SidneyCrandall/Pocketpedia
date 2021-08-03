import { getToken } from "./authManager";

const baseUrl = '/api/bugs';

export const getBugsFromApi = () => {
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
                throw new Error("An unknown error occured while trying to get bugs.")
            }
        }))};


export const addBug = (bug) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}`, {
            method: "POST", 
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(bug)
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("An unknown error occured while trying to add a Bug.")
            }
        });
    });
};


export const getUserBugs = () => {
    return getToken().then((token) => {
      return fetch(`${baseUrl}/GetUserBugs`, {
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