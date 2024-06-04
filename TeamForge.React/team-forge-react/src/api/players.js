import axios from 'axios';

const API_BASE_URL = 'https://localhost:7152/api'; 

export const fetchAllPlayers = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/players`);
        return response.data;
    } catch (error) {
        console.error('Error fetching players:', error);
        throw error;
    }
};

export const createPlayer = async (player) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/players`, player);
        return response.data;
    } catch (error) {
        console.error('Error creating player:', error);
        throw error;
    }
};

export const updatePlayer = async (player) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/players/${player.id}`, player);
        return response.data;
    } catch (error) {
        console.error('Error updating player:', error);
        throw error;
    }
};

export const deletePlayer = async (id) => {
    try {
        await axios.delete(`${API_BASE_URL}/players/${id}`);
    } catch (error) {
        console.error('Error deleting player:', error);
        throw error;
    }
};