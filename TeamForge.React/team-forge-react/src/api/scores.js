import axios from 'axios';

const API_URL = 'http://localhost:7152/api/scores';

export const fetchAllScores = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const fetchScoreById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createScore = async (score) => {
    const response = await axios.post(API_URL, score);
    return response.data;
};

export const updateScore = async (score) => {
    const response = await axios.put(`${API_URL}/${score.id}`, score);
    return response.data;
};

export const deleteScore = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};