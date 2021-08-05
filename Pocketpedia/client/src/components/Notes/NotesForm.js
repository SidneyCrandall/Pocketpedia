import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { addNotes } from '../../modules/notesManager';
import "./Note.css";

const NotesForm = () => {

    // We want to set the state of the form 
    const emptyNote = {
        title: '',
        message: ''
    };

    const [ newNote, setNewNote ] = useState(emptyNote);

    // where to taek the user's view after adding a note
    const history = useHistory();

    // The user needs the ability to insert values for the key 
    const handleInputChange = (evt) => {
        // what will be input from the emptyNote()
        const value = evt.target.value;
        // the Notes id 
        const key = evt.target.id;
        // Copy the array of notes so we can add a new note.
        const notesCopy = { ...newNote };
        // Take the key that represents the object of notes and have its value ready 
        notesCopy[key] = value;
        // Set the newly made copy of notes ready for rendering
        setNewNote(notesCopy);
    };

    const handleSave = (evt) => {
        evt.preventDefault();

        if ( newNote.title === '' || newNote.message === '' )
        {
            window.alert('The title and message are required.')

            setNewNote({

                title: '',
                message: ''
            })

            return history.push(`/notes/add`)

        } else {

            addNotes(newNote).then((n) => {
                history.push(`/notes/details/${n.id}`)
            });
        }
    };

    return (
        
        <Form className="noteForm">
            <h2 className="text-center">New Note</h2>
            <br/>
            <FormGroup>
                <Label for="title"><b>Title</b></Label>
                <Input type="text" name="title" id="title" placeholder="Title of note" value={newNote.title} onChange={handleInputChange} size="20"/>
            </FormGroup>
            <br/>
            <FormGroup>        
                <textarea  type="text" name="message" id="message" placeholder="Your note goes here" value={newNote.message} onChange={handleInputChange} rows="10" cols="135" />                   
            </FormGroup>
       
            <Button className="btn" style={{ backgroundColor: '#BCA4BF' }} onClick={handleSave}>Submit</Button>
            <Button className="btn" onClick={() => history.push(`/`)}>Cancel</Button>
    
        </Form>
    );
};

export default NotesForm