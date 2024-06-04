import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { fetchCoachById } from '../api/coaches';

const CoachDetail = () => {
    const [coach, setCoach] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        loadCoach();
    }, [id]);

    const loadCoach = async () => {
        const data = await fetchCoachById(id);
        setCoach(data);
    };

    if (!coach) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Coach Details</h1>
            <p>Name: {coach.name}</p>
            <p>Specialization: {coach.specialization}</p>
            <p>Experience Years: {coach.experienceYears}</p>
            <p>Contact Info: {coach.contactInfo}</p>
            <Link to={`/coaches/${coach.id}/edit`}>Edit</Link>
        </div>
    );
};

export default CoachDetail;
