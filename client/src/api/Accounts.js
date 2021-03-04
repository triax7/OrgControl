import axios from 'axios';
import axiosInherit from 'axios-inherit';

axiosInherit(axios);
axios.interceptors.response.use((response) => {
  return response;
}, async function (error) {
  const originalRequest = error.config;
  if (error.response.status === 401 && !originalRequest._retry && originalRequest.url !== 'updateAccessToken') {
    console.log(originalRequest);
    originalRequest._retry = true;
    await updateAccessToken();
    return api(originalRequest);
  }
  return Promise.reject(error.response);
});

const api = axios.create({
  baseURL: 'https://localhost:5001/api/accounts',
  timeout: 5000,
  withCredentials: true
});

export async function register(credentials) {
  return api.post('register', credentials);
}

export async function login(credentials) {
  return api.post('login', credentials);
}

export async function current() {
  return api.get('current');
}

export async function updateAccessToken() {
  return api.post('updateAccessToken');
}

export async function emailExists(email) {
  return api.post('exists', {email}).then(res => res.data);
}

export async function logout() {
  return api.post('logout');
}
