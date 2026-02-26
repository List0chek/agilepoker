import { IRoom } from '../Types';
import { ActionType } from '../Reducer';
import { IUpdateRoomAction } from './RoomActionCreators';

const initState = null;

export function roomReducer(state: IRoom | null = initState, action: IUpdateRoomAction): IRoom | null {
  switch (action.type) {
    case ActionType.UPDATE_ROOM:
      return action.room;
    case ActionType.DELETE_ROOM:
      return null;
    default:
      return state;
  }
}
