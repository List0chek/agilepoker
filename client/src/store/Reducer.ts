import { combineReducers } from 'redux';
import { errorReducer } from './Error/ErrorReducer';
import { loadingIndicatorReducer } from './Loading/LoadingReducer';
import { roomReducer } from './Room/RoomReducer';
import { IRootState } from './Types';
import { userReducer } from './User/UserReducer';

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
