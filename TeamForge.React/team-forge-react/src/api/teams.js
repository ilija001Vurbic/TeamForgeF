import axios from 'axios';

const API_URL = 'http://localhost:7152/api/team';

export const fetchAllTeams = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const fetchTeamById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createTeam = async (team) => {
    const response = await axios.post(API_URL, team);
    return response.data;
};

export const updateTeam = async (team) => {
    const response = await axios.put(`${API_URL}/${team.id}`, team);
    return response.data;
};

export const deleteTeam = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};