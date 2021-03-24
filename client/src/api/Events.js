import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api/events',
  timeout: 5000,
  withCredentials: true
});

export async function getOwnEvents() {
  return api.get('')
}

export async function create(event) {
  return api.post('create', event)
}
