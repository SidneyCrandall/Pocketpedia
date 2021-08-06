import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useHistory } from "react-router-dom";
import { register } from "../modules/authManager";


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
    <Form onSubmit={registerClick} className="registerForm">
      <fieldset className="loginform">
        <FormGroup>
          <Label htmlFor="displayName">User Name</Label>
          <Input id="displayName" type="text" onChange={e => setDisplayName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input id="email" type="text" onChange={e => setEmail(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="islandName"> Your Animal Crossing Island Name</Label>
          <Input id="islandName" type="text" onChange={e => setIslandName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="islandPhrase"> Your Animal Crossing Island Title</Label>
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
          <Button className="loginbutton" style={{ backgroundColor: '#BCA4BF' }}>Register</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}