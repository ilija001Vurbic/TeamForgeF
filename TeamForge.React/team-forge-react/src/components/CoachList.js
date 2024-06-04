import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { fetchAllCoaches, deleteCoach } from '../api/coaches';

const CoachList = () => {
    const [coaches, setCoaches] = useState([]);

    useEffect(() => {
        loadCoaches();
    }, []);

    const loadCoaches = async () => {
        const data = await fetchAllCoaches();
        setCoaches(data);
    };

    const handleDelete = async (id) => {
        await deleteCoach(id);
        loadCoaches();
    };

    return (
        <div>
            <h1>Coaches</h1>
            <Link to="/coaches/new">Add Coach</Link>
            <ul>
                {coaches.map((coach) => (
                    <li key={coach.id}>
                        <Link to={`/coaches/${coach.id}`}>{coach.name}</Link>
                        <button onClick={() => handleDelete(coach.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CoachList;