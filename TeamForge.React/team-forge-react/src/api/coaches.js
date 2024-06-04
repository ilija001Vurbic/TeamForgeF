import axios from 'axios';

const API_URL = 'http://localhost:7152/api/coaches';

export const fetchAllCoaches = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const fetchCoachById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createCoach = async (coach) => {
    const response = await axios.post(API_URL, coach);
    return response.data;
};

export const updateCoach = async (coach) => {
    const response = await axios.put(`${API_URL}/${coach.id}`, coach);
    return response.data;
};

export const deleteCoach = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};