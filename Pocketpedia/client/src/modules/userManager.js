import { getToken } from "./authManager";

const baseUrl = "api/userProfile";

export const getbyDisplayName = displayName => {
    return getToken().then(token =>
        fetch(`${baseUrl}/displayName/${displayName}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => res.json()));
}

// These cards
export const getAllUsers = () => {
    return getToken().then((token) => {
      return fetch(`${baseUrl}`, {
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
      return fetch(`${baseUrl}/GetByUserId/${id}`, {
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