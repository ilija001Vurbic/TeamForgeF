import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { fetchTeamById } from '../api/teams';

const TeamDetail = () => {
    const [team, setTeam] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        loadTeam();
    }, [id]);

    const loadTeam = async () => {
        const data = await fetchTeamById(id);
        setTeam(data);
    };

    if (!team) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>{team.name}</h1>
            <p>Coach: {team.coachName}</p>
            <p>Practice Schedule: {team.practiceSchedule}</p>
            <Link to={`/teams/${team.id}/edit`}>Edit</Link>
        </div>
    );
};

export default TeamDetail;