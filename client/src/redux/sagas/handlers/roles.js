import { call, put } from '@redux-saga/core/effects';
import { create, getFromEvent, remove } from '../../../api/Roles';
import { removeRoleFromState, setRoles, updateOrAddRole } from '../../slices/rolesSlice';

export function* handleGetRoles(action) {
  try {
    const response = yield call(getFromEvent, action.payload);
    const {data} = response;
    yield put(setRoles(data));
  } catch (error) {
    console.log(error);
  }
}

export function* handleCreateRole(action) {
  try {
    const response = yield call(create, action.payload);
    const {data} = response;
    yield put(updateOrAddRole(data));
  } catch (error) {
    console.log(error);
  }
}

export function* handleDeleteRole(action) {
  try {
    const response = yield call(remove, action.payload);
    if(response.status === 200)
      yield put(removeRoleFromState(action.payload));
  } catch (error) {
    console.log(error);
  }
}
