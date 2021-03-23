import { call, put } from '@redux-saga/core/effects';
import getOwnEvents from '../../../api/Events';
import { setEvents } from '../../slices/eventsSlice';

export function* handleGetEvents(action) {
  try {
    const response = yield call(getOwnEvents);
    const {data} = response;
    yield put(setEvents(data));
  } catch (error) {
    console.log(error);
  }
}
