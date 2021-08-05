import { Container, Row, Col } from "reactstrap";
import React from "react";
import IsabelleLoFi from '../Images/IsabelleLoFi.JPG';


const IslanderWelcome = () => {

  return (
    <Container className="homePage">
      <Row className="justify-content-lg-center">
        <Col md="auto" className="py-2">
        <span className="welcome">
          <h3>Hello Islander!</h3>
          <h4>Welcome to Pocketpedia! How would you like to relax today?</h4>
          </span>
          </Col>
          <Col md="auto" className="py-2">
          <span className="lofi" ><img src={IsabelleLoFi} alt="Chill Lo-fi Girl" /></span>
        </Col>
      </Row>
    </Container>
  );
};

export default IslanderWelcome;