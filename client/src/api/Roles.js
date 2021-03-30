import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api/roles',
  timeout: 5000,
  withCredentials: true
});

export async function getFromEvent(eventId) {
  return api.get(`getFromEvent/${eventId}`)
}

export async function create(role) {
  return api.post('create', role)
}

export async function remove(roleId) {
  return api.delete(`delete/${roleId}`)
}
