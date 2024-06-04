import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { fetchCoachById, createCoach, updateCoach } from '../api/coaches';

const CoachForm = ({ editMode = false }) => {
    const [coach, setCoach] = useState({
        id: '',
        name: '',
        specialization: '',
        experienceYears: 0,
        contactInfo: '',
    });
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (editMode && id) {
            loadCoach();
        }
    }, [editMode, id]);

    const loadCoach = async () => {
        const data = await fetchCoachById(id);
        setCoach(data);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCoach((prevCoach) => ({
            ...prevCoach,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (editMode) {
            await updateCoach(coach);
        } else {
            await createCoach(coach);
        }
        navigate('/coaches');
    };

    return (
        <div>
            <h1>{editMode ? 'Edit Coach' : 'Create Coach'}</h1>
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input
                        type="text"
                        name="name"
                        value={coach.name}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Specialization:
                    <input
                        type="text"
                        name="specialization"
                        value={coach.specialization}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Experience Years:
                    <input
                        type="number"
                        name="experienceYears"
                        value={coach.experienceYears}
                        onChange={handleChange}
                    />
                </label>
                <label>
                    Contact Info:
                    <input
                        type="text"
                        name="contactInfo"
                        value={coach.contactInfo}
                        onChange={handleChange}
                    />
                </label>
                <button type="submit">{editMode ? 'Update' : 'Create'}</button>
            </form>
        </div>
    );
};

export default CoachForm;
