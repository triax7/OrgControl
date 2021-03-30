import createSagaMiddleware from 'redux-saga';
import { combineReducers } from 'redux';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit';
import { createBrowserHistory } from 'history';
import { watcherSaga } from './sagas/rootSaga';
import userReducer from './slices/userSlice';
import eventsReducer from './slices/eventsSlice';
import rolesReducer from './slices/rolesSlice';

const createRootReducer = (browserHistory) => combineReducers({
  router: connectRouter(browserHistory),
  user: userReducer,
  events: eventsReducer,
  roles: rolesReducer
});

export const history = createBrowserHistory();

const sagaMiddleware = createSagaMiddleware();

export const store = configureStore({
  reducer: createRootReducer(history),
  middleware: [...getDefaultMiddleware({thunk: false}), sagaMiddleware, routerMiddleware(history)]
});

sagaMiddleware.run(watcherSaga);

