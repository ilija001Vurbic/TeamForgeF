import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { fetchScoreById, createScore, updateScore } from '../api/scores';

const ScoreForm = ({ editMode = false }) => {
    const [score, setScore] = useState({
        id: '',
        teamId: '',
        setNumber: 0,
        points: 0,
    });
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (editMode && id) {
            loadScore();
        }
    }, [editMode, id]);

    const loadScore = async () => {
        const data = await fetchScoreById(id);
        setScore(data);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setScore((prevScore) => ({
            ...prevScore,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (editMode) {
            await updateScore(score);
        } else {
            await createScore(score);
        }
        navigate('/scores');
    };

    return (
        <div>
            <h1>{editMode ? 'Edit Score' : 'Create Score'}</h1>
            <form onSubmit={handleSubmit}>
                <label>
                    Team ID:
                    <input
                        type="text"
                        name="teamId"
                        value={score.teamId}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Set Number:
                    <input
                        type="number"
                        name="setNumber"
                        value={score.setNumber}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Points:
                    <input
                        type="number"
                        name="points"
                        value={score.points}
                        onChange={handleChange}
                    />
                </label>
                <button type="submit">{editMode ? 'Update' : 'Create'}</button>
            </form>
        </div>
    );
};

export default ScoreForm;