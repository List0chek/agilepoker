import { IRootState } from './Types';
import { combineReducers } from 'redux';
import { roomReducer } from './Room/RoomReducer';
import { userReducer } from './User/UserReducer';
import { loadingIndicatorReducer } from './Loading/LoadingReducer';
import { errorReducer } from './Error/ErrorReducer';

export const ActionType = {
  UPDATE_USER: 'UPDATE_USER',
  UPDATE_ROOM: 'UPDATE_ROOM',
  TOGGLE_LOADING_INDICATOR: 'TOGGLE_LOADING_INDICATOR',
  DELETE_USER: 'DELETE_USER',
  DELETE_ROOM: 'DELETE_ROOM',
  UPDATE_ERROR: 'UPDATE_ERROR',
};

export const reducer = combineReducers<IRootState>({
  room: roomReducer,
  user: userReducer,
  loadingIndicator: loadingIndicatorReducer,
  error: errorReducer,
});
