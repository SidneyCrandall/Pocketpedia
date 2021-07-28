import React from "react";
import { Card, CardBody, CardHeader } from "reactstrap";
//import ACNHLoFi from './ACNHLoFi.jpg';

const UserCard = () => {

 const currentUser = JSON.parse(sessionStorage.getItem("doesUserExist"));

    return (
        <div className="container">
        <div className="row justify-content-center">
          <div className="col-sm-12 col-lg-6">
            <Card>
              <CardHeader>
                <div className="row justify-content-between">
                  <h3 className="d-flex align-items-center ml-3">
                    <strong>Hello!!! {currentUser.DisplayName}</strong>
                  </h3>
                </div>
              </CardHeader>
              <CardBody>
                <h4 className="mb-4">
                 Island's Name: <strong>{currentUser.IslandName}</strong>
                </h4>
                <h4 className="mb-4">
                  Catchphrase: <strong>{currentUser.IslandPhrase}</strong>
                </h4>
              </CardBody>
            </Card>
            {/* <img className="d-flex justify-content-end" src={ACNHLoFi} alt="Chill Lo-fi Girl"/>  */}
          </div>
        </div>
      </div>
    );
};

export default UserCard;