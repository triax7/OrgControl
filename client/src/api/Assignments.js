import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api/assignments',
  timeout: 5000,
  withCredentials: true
});

export async function getFromEvent(eventId) {
  return api.get(`getFromEvent/${eventId}`);
}

export async function create(assignment) {
  return api.post('create', assignment);
}

export async function getForUserInEvent(userId, eventId) {
  return api.get(`getAssignmentsInEvent/${userId}/${eventId}`);
}

export async function autoAssignDuties(assignmentIds) {
  return api.post(`autoAssignDuties`, {assignmentIds});
}
