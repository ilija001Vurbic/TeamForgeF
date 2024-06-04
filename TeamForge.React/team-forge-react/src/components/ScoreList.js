import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { fetchAllScores, deleteScore } from '../api/scores';

const ScoreList = () => {
    const [scores, setScores] = useState([]);

    useEffect(() => {
        loadScores();
    }, []);

    const loadScores = async () => {
        const data = await fetchAllScores();
        setScores(data);
    };

    const handleDelete = async (id) => {
        await deleteScore(id);
        loadScores();
    };

    return (
        <div>
            <h1>Scores</h1>
            <Link to="/scores/new">Add Score</Link>
            <ul>
                {scores.map((score) => (
                    <li key={score.id}>
                        <Link to={`/scores/${score.id}`}>{`Team: ${score.teamId}, Set: ${score.setNumber}, Points: ${score.points}`}</Link>
                        <button onClick={() => handleDelete(score.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ScoreList;