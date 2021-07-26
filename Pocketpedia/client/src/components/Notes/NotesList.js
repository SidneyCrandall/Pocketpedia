import React, { useEffect, useState } from "react";
import Notes from './Notes';
import { getAllNotes } from "../../modules/notesManager";


const NotesList = () => {

    const [ notes, setNotes ] = useState([]);

    const getNotes = () => {
        getAllNotes().then(note => setNotes(note));
    };

    useEffect(() => {
        getNotes();
    }, []);
    
    return (
        <div className="m-3">
            <div className="container">
                <div className="row m-3 justify-content-center">
                    {notes.map((note) => (
                        <Notes note={note} key={note.id} editAndDeleteButton={false}/>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default NotesList;