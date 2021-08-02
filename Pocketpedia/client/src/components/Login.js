import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useHistory, Link } from "react-router-dom";
import { login } from "../modules/authManager";
import { getAllUsers, getUserById } from "../modules/authManager";

export default function Login() {
  const history = useHistory();

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (evt) => {
    evt.preventDefault();
    login(email, password)
      .then(() => history.push("/"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <Form onSubmit={loginSubmit} className="form">
      <fieldset className="loginform">
        <h3>User Login</h3>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input id="email" type="text" autoFocus onChange={evt => setEmail(evt.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input id="password" type="password" onChange={evt => setPassword(evt.target.value)} />
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