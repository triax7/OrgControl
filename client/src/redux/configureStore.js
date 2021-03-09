import createSagaMiddleware from 'redux-saga';
import {combineReducers} from 'redux';
import {connectRouter, routerMiddleware} from 'connected-react-router';
import {configureStore, getDefaultMiddleware} from '@reduxjs/toolkit';
import {createBrowserHistory} from 'history';
import {watcherSaga} from './sagas/rootSaga';
import userReducer from './slices/userSlice';

const createRootReducer = (browserHistory) => combineReducers({
  router: connectRouter(browserHistory),
  user: userReducer
});

export const history = createBrowserHistory();

const sagaMiddleware = createSagaMiddleware();

export const store = configureStore({
  reducer: createRootReducer(history),
  middleware: [...getDefaultMiddleware({thunk: false}), sagaMiddleware, routerMiddleware(history)]
});

sagaMiddleware.run(watcherSaga);

