import { call, put } from '@redux-saga/core/effects';
import { create, getFromEvent } from '../../../api/Assignments';
import { setAssignments, updateOrAddAssignment } from '../../slices/assignmentsSlice';

export function* handleGetAssignments(action) {
  try {
    const response = yield call(getFromEvent, action.payload);
    const {data} = response;
    yield put(setAssignments(data));
  } catch (error) {
    console.log(error);
  }
}

export function* handleCreateAssignment(action) {
  try {
    const response = yield call(create, action.payload);
    const {data} = response;
    yield put(updateOrAddAssignment(data));
  } catch (error) {
    console.log(error);
  }
}
