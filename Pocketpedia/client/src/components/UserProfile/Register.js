import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useHistory } from "react-router-dom";
import { register } from "../modules/authManager";
import logo1 from "../images/logo1.png";


export default function Register() {
  const history = useHistory();

  const [displayName, setDisplayName] = useState();
  const [email, setEmail] = useState();
  const [islandName, setIslandName] = useState();
  const [islandPhrase, setIslandPhrase] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match. Please try again.");
    } else {
      const userProfile = { displayName, islandName, islandPhrase, email };
      register(userProfile, password)
        .then(() => history.push("/"));
    }
 };

  return (
    <Form onSubmit={registerClick} className="form">
      <img className="logo1" src={logo1} alt="logo1" />
      <fieldset className="loginform">
        <FormGroup>
          <Label htmlFor="displayName">Display Name</Label>
          <Input id="displayName" type="text" onChange={e => setDisplayName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input id="email" type="text" onChange={e => setEmail(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="islandName">Animal Crossing Island Name</Label>
          <Input id="islandName" type="text" onChange={e => setIslandName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="islandPhrase">Animal Crossing Island Phrase</Label>
          <Input id="islandPhrase" type="text" onChange={e => setIslandPhrase(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="confirmPassword">Confirm Password</Label>
          <Input id="confirmPassword" type="password" onChange={e => setConfirmPassword(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Button className="loginbutton">Register</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}