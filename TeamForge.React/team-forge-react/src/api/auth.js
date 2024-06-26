import axios from 'axios';

const API_URL = 'http://localhost:7152/api/user';

export const register = async (user) => {
    const response = await axios.post(`${API_URL}/register`, user);
    return response.data;
};

export const login = async (credentials) => {
    const response = await axios.post(`${API_URL}/login`, credentials);
    return response.data;
};