import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

//TODO
const endpoint = {
  allData: `/data/albums?sortBy=_createdOn%20desc&distinct=name`,
  post: '/data/albums',
  byId: `/data/albums/`,
  search: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`
}

export async function getAllData() {
  return api.get(endpoint.allData);
}

export async function getById(id) {
  return api.get(endpoint.byId + id);
}

export async function create(meme) {
  return api.post(endpoint.post, meme);
}

export async function editById(id, meme) {
  return api.put(endpoint.byId + id, meme);
}

export async function deleteById(id) {
  return api.del(endpoint.byId + id);
}

export async function searchByQuery(query) {
  return api.get(endpoint.search(query))
}