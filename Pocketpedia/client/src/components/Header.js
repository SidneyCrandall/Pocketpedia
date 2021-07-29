import React, { useState } from 'react';
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { logout } from '../modules/authManager';

export default function Header({ isLoggedIn }) {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand tag={RRNavLink} to="/">Pocketpedia</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            { /* When isLoggedIn === true, we will render the Home link */}
            {isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/notes">Notes</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/bugs">Bugs</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/fish">Fish</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/art">Art</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/fossils">Fossils</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/seaCreatures">Sea Creatures</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/villager">Villagers</NavLink>
                </NavItem>
              </>
            }
          </Nav>
          <Nav navbar>
            {isLoggedIn &&
              <>
                <NavItem>
                  <a aria-current="page" className="nav-link"
                    style={{ cursor: "pointer" }} onClick={logout}>Logout</a>
                </NavItem>
              </>
            }
            {!isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                </NavItem>
              </>
            }
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}