import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api/events',
  timeout: 5000,
  withCredentials: true
});

export default function getOwnEvents() {
  return api.get('')
}
