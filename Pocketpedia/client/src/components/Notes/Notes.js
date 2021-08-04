import React from "react";
import { Card, CardBody } from "reactstrap";
import { Link } from 'react-router-dom';
import { useHistory } from "react-router";
import { deleteNotes } from "../../modules/notesManager";
import "./Note.css";



const Notes = ({ notes }) => {

    // Variable used to hold on to the info of that particukar note
    const notesId = notes.id;

    // this will be invoked in order to display the edit form
    const history = useHistory();

    // The list will contain a button that will allow a user to delete any note they wish
    const handleDeleteNote = (id) => {
        // Offer of confirmation to delete the note. The user cna cancel the deletion when the window pops up
        if (window.confirm("Are you sure you would like to delete this Note?")) {
            deleteNotes(id)
                .then((n) => {
                    history.push(`/`);
            })
        }
    };

    // From the brief preview of a note, a user should see an edit or delete button
    return (
        <Card className="noteContainer">
            <CardBody className="m-3">
                <Link to={`/notes/details/${notesId}`}>
                    <p><b>Title: </b>{notes.title}</p>
                </Link>

                <div>
                    <button className="btn btn-danger" onClick={() => handleDeleteNote(notes.id)}>Delete</button>
                    <Link to={`/notes/edit/${notesId}`}>
                        <button className="btn btn-light  m-2">Edit</button>
                    </Link>
                </div>

            </CardBody>
        </Card>
    );
};

export default Notes;