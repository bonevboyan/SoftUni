import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

//TODO
const endpoint = {
    allData: `/data/memes?sortBy=_createdOn%20desc`,
    byId: `/data/memes/`,
    getOwnBefore = '/data/memes?where=_ownerId%3D%22',
    getOwnAfter = '%22&sortBy=_createdOn%20desc'
}

export async function getAllData() {
    return api.get(allMemes);
  }
  
  export async function getById(id) {
    return api.get(endpoint.byId + id);
  }
  
  export async function getOwn(userId) {
    return api.get(endpoint.getOwnBefore + userId + endpoint.getOwnAfter);
  }
  
  export async function create(meme) {
    return api.post(endpoint.byId, meme);
  }
  
  export async function editById(id, meme) {
    return api.put(endpoint.byId + id, meme);
  }
  
  export async function deleteById(id) {
    return api.del(endpoint.byId + id);
  }