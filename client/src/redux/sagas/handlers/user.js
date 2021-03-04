import {current, login, logout, register} from '../../../api/Accounts';
import {call, put} from '@redux-saga/core/effects';
import {setUser} from '../../slices/userSlice';
import {push} from 'connected-react-router';


export function* handleGetCurrentUser(action) {
  try {
    const response = yield call(current);
    const {data} = response;
    yield put(setUser({...data}));
  } catch (error) {
    console.log(error);
  }
}

export function* handleRegisterUser(action) {
  try {
    const response = yield call(register, action.payload);
    const {data} = response;
    yield put(setUser({...data}));
    yield put(push('/user'));
  } catch (error) {
    console.log(error);
  }
}

export function* handleLoginUser(action) {
  try {
    const response = yield call(login, action.payload);
    const {data} = response;
    yield put(setUser({...data}));
    yield put(push('/user'));
  } catch (error) {
    console.log(error);
  }
}

export function* handleLogout(action) {
  try {
    yield call(logout);
    yield put(setUser({}));
    yield put(push('/login'));
  } catch (error) {
    console.log(error);
  }
}
