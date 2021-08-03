import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
//import Hello from "./Hello";
import Login from "./Login";
import Register from "./Register";

import NotesList from "./Notes/NotesList";
import NotesDetails from "./Notes/NotesDetails";
import NotesForm from "./Notes/NotesForm";
import NotesEdit from "./Notes/NotesEdit";

import BugList from "./Bugs/BugList";
import FishList from "./Fish/FishList";
import ArtList from "./Art/ArtList";
import FossilList from "./Fossils/FossilList";
import SeaCreatureList from "./SeaCreatures/SeaCreatureList";
import VillagerList from "./Villagers/VillagerList";
import { IslanderWelcome } from "./Hello";
import MyVillagerList from "./Villagers/MyVillagerList";
import MyBugList from "./Bugs/MyBugList";


//EXACT PATH can be used when routes begin the same
export default function ApplicationViews({ isLoggedIn }) {
    return (
        <main>
            <Switch>

                <Route path="/login">
                    <Login />
                </Route>

                <Route path="/register">
                    <Register />
                </Route>

                {/* For now this will be what users see */}
                <Route path="/" exact>
                    {isLoggedIn ? <IslanderWelcome /> : <Redirect to="/login" />}
                </Route>

                {/* Notes route */}
                <Route path="/notes" exact>
                    {isLoggedIn ? <NotesList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/notes/details/:id" exact>
                    {isLoggedIn ? <NotesDetails /> : <Redirect to="/login" />}
                </Route>

                <Route path="/notes/add" exact>
                    {isLoggedIn ? <NotesForm /> : <Redirect to="/login" />}
                </Route>

                <Route path="/notes/edit/:id" exact>
                    {isLoggedIn ? <NotesEdit /> : <Redirect to="/login" />}
                </Route>

                <Route path="/bugs" exact>
                    {isLoggedIn ? <BugList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/fish" exact>
                    {isLoggedIn ? <FishList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/art" exact>
                    {isLoggedIn ? <ArtList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/fossils" exact>
                    {isLoggedIn ? <FossilList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/seaCreatures" exact>
                    {isLoggedIn ? <SeaCreatureList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/villagers" exact>
                    {isLoggedIn ? <VillagerList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/villagers/GetUserVillagers">
                    {isLoggedIn ? <MyVillagerList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/bugs/GetUserBugs">
                    {isLoggedIn ? <MyBugList /> : <Redirect to="/login" />}
                </Route>

            </Switch>
        </main>
    );
}