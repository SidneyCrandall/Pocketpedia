import React, { useEffect, useState } from "react";
import { Card, CardBody, CardHeader } from "reactstrap";
import { useParams } from "react-router-dom";
import { getUserById } from "../../modules/userManager";

const UserCard = () => {

    const [ user, setUser ] = useState();

    const { id } = useParams();
    
    useEffect(() => {
        getUserById(id).then(setUser);
    }, [id]);

    if (!user) {
        return null;
    }

    return (
        <div className="container">
        <div className="row justify-content-center">
          <div className="col-sm-12 col-lg-6">
            <Card>
              <CardHeader>
                <div className="row justify-content-between">
                  <h3 className="d-flex align-items-center ml-3">
                    <strong>Hello!!! {user.displayName}</strong>
                  </h3>
                </div>
              </CardHeader>
              <CardBody>
                <h4 className="mb-4">
                 Island's Name: <strong>{user.islandName}</strong>
                </h4>
                <h4 className="mb-4">
                  Catchphrase: <strong>{user.islandPhrase}</strong>
                </h4>
              </CardBody>
            </Card>
            <img className="d-flex justify-content-end" src={'./ACNHLo-Fi.jpg'} alt="Chill Lo-fi Girl"/>
          </div>
        </div>
      </div>
    );
};

export default UserCard;