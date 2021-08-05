import React from "react";
import { CardBody, CardText, CardTitle, CardGroup } from "reactstrap";
import { useState, useEffect } from "react";
import { useParams } from "react-router";
import { getNotesById } from "../../modules/notesManager";
import "./Note.css";


// Styling for cards
const style = { width: "50rem" };


const NotesDetails = () => {

    // We just need to set the state of ome note to diaply there details
    const [ notesDetails, setNotesDetails ] = useState({});

    // lets carry that id so it knows which to render
    const { id } = useParams();

    // called from the fetch in Notes manager and which will interact with the backend
    const getNotesDetails = () => {
        getNotesById(id)
            .then(setNotesDetails)
    };

    // what we want rendered
    useEffect(() => {
        getNotesDetails();
    }, []);


    return (
        <>
        <h2 className="text-center">Island Note Details</h2>
        <CardGroup style={style} className="card-deck">
            <CardBody>               
            <CardTitle className="noteTitle"><b>Title: </b>{notesDetails.title}</CardTitle>
                <CardText><b>Message: </b>{notesDetails.message}</CardText>
            </CardBody>
            </CardGroup>
        </>
    );
};

export default NotesDetails;