import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { fetchTeamById, createTeam, updateTeam } from '../api/teams';

const TeamForm = ({ editMode = false }) => {
    const [team, setTeam] = useState({
        name: '',
        coachName: '',
        practiceSchedule: '',
    });
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (editMode && id) {
            loadTeam();
        }
    }, [editMode, id]);

    const loadTeam = async () => {
        const data = await fetchTeamById(id);
        setTeam(data);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setTeam((prevTeam) => ({
            ...prevTeam,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (editMode) {
            await updateTeam(team);
        } else {
            await createTeam(team);
        }
        navigate('/');
    };

    return (
        <div>
            <h1>{editMode ? 'Edit Team' : 'Create Team'}</h1>
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input
                        type="text"
                        name="name"
                        value={team.name}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Coach Name:
                    <input
                        type="text"
                        name="coachName"
                        value={team.coachName}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Practice Schedule:
                    <input
                        type="text"
                        name="practiceSchedule"
                        value={team.practiceSchedule}
                        onChange={handleChange}
                    />
                </label>
                <button type="submit">{editMode ? 'Update' : 'Create'}</button>
            </form>
        </div>
    );
};

export default TeamForm;