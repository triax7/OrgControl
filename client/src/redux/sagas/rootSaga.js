import { takeLatest } from '@redux-saga/core/effects';
import {
  handleGetCurrentUser,
  handleLoginUser,
  handleLogout,
  handleRegisterUser
} from './handlers/user';
import { getCurrentUser, registerUser, loginUser, logoutUser } from '../slices/userSlice';
import { getEvents } from '../slices/eventsSlice';
import { handleGetEvents } from './handlers/events';

export function* watcherSaga() {
  yield takeLatest(getCurrentUser.type, handleGetCurrentUser);
  yield takeLatest(registerUser.type, handleRegisterUser);
  yield takeLatest(loginUser.type, handleLoginUser);
  yield takeLatest(logoutUser.type, handleLogout);

  yield takeLatest(getEvents.type, handleGetEvents);
}
