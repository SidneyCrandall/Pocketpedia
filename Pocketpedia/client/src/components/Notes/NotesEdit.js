import React, { useState, useEffect } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { updateNotes, getNotesById } from '../../modules/notesManager';

const NotesEdit = () => {

    const [editNotes, setEditNotes] = useState([]);

    const [isLoading, setIsLoading] = useState(false);

    const { id } = useParams();

    const history = useHistory();

    const handleInputChange = (evt) => {
        // The "value" will change as we edit. The databade consists of key/values.
        const value = evt.target.value;
        // The key is the item from the tablw we will be asking to edit. 
        const key = evt.target.id;
        // Make a variable and copy the data, then hold on to it
        const notesCopy = { ...editNotes };
        // We need to have the key/value pair link up.
        notesCopy[key] = value;
        // Now that a user has input the edited values we need to set the state for future use
        setEditNotes(notesCopy);
    };

    const handleUpdate = (evt) => {
        evt.preventDefault();

        setIsLoading(true);
        // This is what will be edited. 
        const editedNotes = {
            id: id,
            title: editedNotes.title,
            message: editedNotes.message
        };
        // fetch call in order to pass the edited state of the note to data 
        updateNotes(editedNotes)
            .then((n) => {
                // Once the note has been edited and update, take the user back to the details of that note
                history.push(`/notes/details/${editedNotes.id}`)
            });
    };

    // The state was set now we need to put the action in to use in order to render that page
    useEffect(() => {
        getNotesById(id)
            .then(n => {
                setEditNotes(n);
                setIsLoading(false);
            });
    }, [id]);

    return (
        <Form className="container w-75">
            <h2 className="text-center">Edit Island Notes</h2>
            <FormGroup>
                <Label for="title">Title</Label>
                <Input type="text" name="title" id="title" placeholder="post title"
                    value={editNotes.title}
                    onChange={handleInputChange} />
            </FormGroup>
            <FormGroup>
                <Label for="message">Message</Label>
                <textarea type="text" name="message" id="message" placeholder="message"
                    value={editNotes.message}
                    rows="10" cols="145"
                    onChange={handleInputChange} />
            </FormGroup>
            {/* When the user hits submit the details of the newly edited note will render*/}
            <Button className="btn btn-primary" onClick={handleUpdate}>Submit</Button>
            {/* When the user hits cancel the notes page will render, taking the user back to their list of notes*/}
            <Button className="btn btn-primary" onClick={() => history.push(`/notes`)}>Cancel</Button>

        </Form>
    );
};

export default NotesEdit;