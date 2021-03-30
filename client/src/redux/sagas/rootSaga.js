import { takeEvery, takeLatest } from '@redux-saga/core/effects';
import {
  handleGetCurrentUser,
  handleLoginUser,
  handleLogout,
  handleRegisterUser
} from './handlers/user';
import { getCurrentUser, registerUser, loginUser, logoutUser } from '../slices/userSlice';
import { createEvent, getEvents } from '../slices/eventsSlice';
import { handleCreateEvent, handleGetEvents } from './handlers/events';
import { createRole, deleteRole, getRoles } from '../slices/rolesSlice';
import { handleCreateRole, handleDeleteRole, handleGetRoles } from './handlers/roles';

export function* watcherSaga() {
  yield takeLatest(getCurrentUser.type, handleGetCurrentUser);
  yield takeLatest(registerUser.type, handleRegisterUser);
  yield takeLatest(loginUser.type, handleLoginUser);
  yield takeLatest(logoutUser.type, handleLogout);

  yield takeLatest(getEvents.type, handleGetEvents);
  yield takeEvery(createEvent.type, handleCreateEvent);

  yield takeLatest(getRoles.type, handleGetRoles);
  yield takeEvery(createRole.type, handleCreateRole);
  yield takeEvery(deleteRole.type, handleDeleteRole);
}
