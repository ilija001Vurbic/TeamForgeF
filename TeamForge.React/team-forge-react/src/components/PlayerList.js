import React, { useState, useEffect } from 'react';
import { fetchAllPlayers, deletePlayer } from '../api/players';
import { Link } from 'react-router-dom';

const PlayerList = () => {
    const [players, setPlayers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const loadPlayers = async () => {
            try {
                const playerData = await fetchAllPlayers();
                setPlayers(playerData);
            } catch (error) {
                setError('Failed to fetch players');
            } finally {
                setLoading(false);
            }
        };

        loadPlayers();
    }, []);

    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this player?')) {
            try {
                await deletePlayer(id);
                setPlayers(players.filter(player => player.id !== id));
            } catch (error) {
                setError('Failed to delete player');
            }
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div>
            <h1>Players</h1>
            <Link to="/create">Create New Player</Link>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Height</th>
                        <th>Weight</th>
                        <th>Age</th>
                        <th>Blocking</th>
                        <th>Attacking</th>
                        <th>Serving</th>
                        <th>Passing</th>
                        <th>Setting</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {players.map(player => (
                        <tr key={player.id}>
                            <td>{player.id}</td>
                            <td>{player.name}</td>
                            <td>{player.height}</td>
                            <td>{player.weight}</td>
                            <td>{player.age}</td>
                            <td>{player.blocking}</td>
                            <td>{player.attacking}</td>
                            <td>{player.serving}</td>
                            <td>{player.passing}</td>
                            <td>{player.setting}</td>
                            <td>
                                <Link to={`/edit/${player.id}`}>Edit</Link>
                                <button onClick={() => handleDelete(player.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default PlayerList;