import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { fetchScoreById } from '../api/scores';

const ScoreDetail = () => {
    const [score, setScore] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        loadScore();
    }, [id]);

    const loadScore = async () => {
        const data = await fetchScoreById(id);
        setScore(data);
    };

    if (!score) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Score Details</h1>
            <p>Team ID: {score.teamId}</p>
            <p>Set Number: {score.setNumber}</p>
            <p>Points: {score.points}</p>
            <Link to={`/scores/${score.id}/edit`}>Edit</Link>
        </div>
    );
};

export default ScoreDetail;