import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { createPlayer, updatePlayer, fetchAllPlayers } from '../api/players';

const PlayerForm = ({ editMode = false }) => {
    const [player, setPlayer] = useState({
        name: '',
        height: 0,
        weight: 0,
        age: 0,
        blocking: 0,
        attacking: 0,
        serving: 0,
        passing: 0,
        setting: 0,
    });
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (editMode && id) {
            const loadPlayer = async () => {
                try {
                    const allPlayers = await fetchAllPlayers();
                    const playerToEdit = allPlayers.find(p => p.id === id);
                    if (playerToEdit) {
                        setPlayer(playerToEdit);
                    } else {
                        setError('Player not found');
                    }
                } catch (error) {
                    setError('Failed to load player data');
                }
            };

            loadPlayer();
        }
    }, [editMode, id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setPlayer((prevPlayer) => ({
            ...prevPlayer,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (editMode) {
                await updatePlayer(player);
            } else {
                await createPlayer(player);
            }
            navigate('/');
        } catch (error) {
            setError('Failed to save player');
        }
    };

    return (
        <div>
            <h1>{editMode ? 'Edit Player' : 'Create Player'}</h1>
            {error && <div>{error}</div>}
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input
                        type="text"
                        name="name"
                        value={player.name}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Height:
                    <input
                        type="number"
                        name="height"
                        value={player.height}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Weight:
                    <input
                        type="number"
                        name="weight"
                        value={player.weight}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Age:
                    <input
                        type="number"
                        name="age"
                        value={player.age}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Blocking:
                    <input
                        type="number"
                        name="blocking"
                        value={player.blocking}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Attacking:
                    <input
                        type="number"
                        name="attacking"
                        value={player.attacking}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Serving:
                    <input
                        type="number"
                        name="serving"
                        value={player.serving}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Passing:
                    <input
                        type="number"
                        name="passing"
                        value={player.passing}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Setting:
                    <input
                        type="number"
                        name="setting"
                        value={player.setting}
                        onChange={handleChange}
                    />
                </label>
                <button type="submit">{editMode ? 'Update' : 'Create'}</button>
            </form>
        </div>
    );
};

export default PlayerForm;