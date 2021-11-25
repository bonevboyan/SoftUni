import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const furnitureEndpoint = "/data/catalog";

export async function postFurniture(data) {
    return api.post(furnitureEndpoint, data);
}

export async function getAllFurniture() {
    return api.get(furnitureEndpoint);
}

export async function getFurnitureById(id) {
    return api.get(`${furnitureEndpoint}/${id}`);
}

export async function updateFurniture(data) {
    return api.put(furnitureEndpoint, data);
}

export async function deleteFurniture(id) {
    return api.del(`${furnitureEndpoint}/${id}`);
}

export async function getMyFurniture(userId) {
    return api.get(`${furnitureEndpoint}?where=_ownerId%3D%22${userId}%22`);
}