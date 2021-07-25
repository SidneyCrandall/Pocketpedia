import React, { useEffect, useState } from "react";
import { Card, CardBody, CardHeader, CardFooter } from "reactstrap";
import { useParams } from "react-router-dom";
import { getUserById } from "../../modules/userManager";

const UserCard = () => {

    const [ user, setUser ] = useState();

    const { id } = useParams();
    
    useEffect(() => {
        getUserById(id).then(setUser);
    }, []);

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
                    <strong>{user.fullName}</strong>
                  </h3>
                  <img
                    className="d-flex justify-content-end"
                    src={`${
                      user.imageLocation
                        ? user.imageLocation
                        : "https://robohash.org/d.png?size=150x150&set=set2"
                    } `}
                  />
                </div>
              </CardHeader>
              <CardBody>
                <h4 className="mb-4">
                  DisplayName: <strong>{user.displayName}</strong>
                </h4>
                <h4 className="mb-4">
                  Email: <strong>{user.email}</strong>
                </h4>
                <CardFooter>
                  <div className="row justify-content-between">
                    <h4>Registration Date: {`${MM}/${DD}/${YYYY} `}</h4>
  
                    <h4 className="mx-1">{user.userType.name}</h4>
                  </div>
                </CardFooter>
              </CardBody>
            </Card>
          </div>
        </div>
      </div>
    );
};