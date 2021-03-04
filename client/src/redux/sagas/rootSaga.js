import {takeLatest} from '@redux-saga/core/effects';
import {handleGetCurrentUser, handleLoginUser, handleRegisterUser} from './handlers/user';
import {getCurrentUser, registerUser, loginUser} from '../slices/userSlice';

export function* watcherSaga() {
  yield takeLatest(getCurrentUser.type, handleGetCurrentUser);
  yield takeLatest(registerUser.type, handleRegisterUser);
  yield takeLatest(loginUser.type, handleLoginUser);
}
