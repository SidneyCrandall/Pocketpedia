import React, { useEffect, useState } from "react";
import Notes from './Notes';
import { getByUser } from "../../modules/notesManager";
import { Link } from 'react-router-dom';
import { Button } from "reactstrap";


const NotesList = () => {

    const [notes, setNotes] = useState([]);

    const getNotes = () => {
        getByUser().then(notes => setNotes(notes));
    };

    useEffect(() => {
        getNotes();
    }, []);

    return (
        <>
            <section className="section-content">
                <Link to={`/notes/add`}>
                    <Button className="btn" style={{ backgroundColor: '#BCA4BF' }} href="#pablo" size="lg">Add a Note</Button>
                </Link>
            </section>
            <div className="m-3">
                <div className="container">
                    <div className="row m-3 justify-content-center">
                        {notes.map((notes) => (
                            <Notes notes={notes} key={notes.id} />
                        ))}
                    </div>
                </div>
            </div>
        </>
    );
};

export default NotesList;