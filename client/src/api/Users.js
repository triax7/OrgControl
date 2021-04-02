import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api/users',
  timeout: 5000,
  withCredentials: true
});

export async function searchUsers(searchString, page = 1) {
  return api.get(`search`, {params: {searchString, page}});
}
