import { call, put } from '@redux-saga/core/effects';
import { create, getOwnEvents } from '../../../api/Events';
import { setEvents, updateOrAddEvent } from '../../slices/eventsSlice';

export function* handleGetEvents(action) {
  try {
    const response = yield call(getOwnEvents);
    const {data} = response;
    yield put(setEvents(data));
  } catch (error) {
    console.log(error);
  }
}

export function* handleCreateEvent(action) {
  try {
    const response = yield call(create, action.payload);
    const {data} = response;
    yield put(updateOrAddEvent(data));
  } catch (error) {
    console.log(error);
  }
}
