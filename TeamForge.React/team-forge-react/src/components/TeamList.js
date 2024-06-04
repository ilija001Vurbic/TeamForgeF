import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { fetchAllTeams, deleteTeam } from '../api/teams';

const TeamList = () => {
    const [teams, setTeams] = useState([]);

    useEffect(() => {
        loadTeams();
    }, []);

    const loadTeams = async () => {
        const data = await fetchAllTeams();
        setTeams(data);
    };

    const handleDelete = async (id) => {
        await deleteTeam(id);
        loadTeams();
    };

    return (
        <div>
            <h1>Teams</h1>
            <Link to="/teams/new">Add Team</Link>
            <ul>
                {teams.map((team) => (
                    <li key={team.id}>
                        <Link to={`/teams/${team.id}`}>{team.name}</Link>
                        <button onClick={() => handleDelete(team.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TeamList;