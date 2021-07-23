import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useHistory, Link } from "react-router-dom";
import { login } from "../modules/authManager";
import logo1 from "../images/logo1.png";

export default function Login() {
  const history = useHistory();

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (e) => {
    e.preventDefault();
    login(email, password)
      .then(() => history.push("/"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <Form onSubmit={loginSubmit} className="form">
      <img className="logo1" src={logo1} alt="logo1" />
      <fieldset className="loginform">
        <h3>User Login</h3>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input id="email" type="text" autoFocus onChange={e => setEmail(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </FormGroup>
        <br></br>
        <FormGroup>
          <Button className="loginbutton">Login</Button>
        </FormGroup>
        <em>
          Don't have an account? <Link to="register">Sign up here</Link>
        </em>
      </fieldset>
    </Form>
  );
}