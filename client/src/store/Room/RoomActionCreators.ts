import { IRoom } from '../Types';
import { Action } from 'redux';
import { ActionType } from '../Reducer';

export interface IUpdateRoomAction extends Action {
  room: IRoom;
}

export const updateRoom = (room: IRoom): IUpdateRoomAction => {
  return {
    type: ActionType.UPDATE_ROOM,
    room: room,
  };
};

export const deleteRoom = (): Action => {
  return {
    type: ActionType.DELETE_ROOM,
  };
};
