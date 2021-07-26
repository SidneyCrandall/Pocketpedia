import React, { useEffect, useState } from "react";
import Notes from './Notes';
import { getAllNotes } from "../../modules/notesManager";
import { Link } from 'react-router-dom';


const NotesList = () => {

    const [notes, setNotes] = useState([]);

    const getNotes = () => {
        getAllNotes().then(notes => setNotes(notes));
    };

    useEffect(() => {
        getNotes();
    }, []);

    return (
        <>
            <section className="section-content">
            <Link to={`/notes/add`}>
                <button className="btn btn-light  m-2">Add a Note</button>
            </Link>
            </section>
            <div className="m-3">
                <div className="container">
                    <div className="row m-3 justify-content-center">
                        {notes.map((notes) => (
                            <Notes notes={notes} key={notes.id}  />
                        ))}
                    </div>
                </div>
            </div>
        </>
    );
};

export default NotesList;