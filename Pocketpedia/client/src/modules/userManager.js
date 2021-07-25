import { getToken } from "./authManager";

const apiUrl = "/api";


export const getAllUsers = () => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else {
          throw new Error("An unknown error occurred while trying to get Users.");
        }
      });
    });
  };


export const getUserById = (id) => {
    return getToken().then((token) => {
      return fetch(`${apiUrl}/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else {
          throw new Error(
            "An unknown error occurred while trying to get User Profile."
          );
        }
      });
    });
  };