import React from "react";
import { Card, CardBody } from "reactstrap";
import { useState, useEffect } from "react";
import { useParams } from "react-router";
import { getNotesById } from "../../modules/notesManager";

const NotesDetails = () => {

    // We just need to set the state of ome note to diaply there details
    const [ notesDetails, setNotesDetails ] = useState({});

    // lets carry that id so it knows which to render
    const { id } = useParams();

    // called from the fetch in Notes manager and which will interact with the backend
    const getNotesDetails = () => {
        getNotesById(id)
            .then(setNotesDetails)
    }

    // what we want rendered
    useEffect(() => {
        getNotesDetails();
    }, []);

    
    return (
        <>
        <h2 className="text-center">Island Note Details</h2>
        <Card className="w-75 mx-auto">
            <CardBody>               
                <p><b>Title: </b>{notesDetails.title}</p>
                <p><b>Message: </b>{notesDetails.message}</p>
            </CardBody>
        </Card >
        </>
    );
};

export default NotesDetails;