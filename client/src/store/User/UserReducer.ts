import { IUser } from '../Types';
import { ActionType } from '../Reducer';
import { IUpdateUserAction } from './UserActionCreators';

const initState = null;

export function userReducer(state: IUser | null = initState, action: IUpdateUserAction): IUser | null {
  switch (action.type) {
    case ActionType.UPDATE_USER:
      return action.user;
    case ActionType.DELETE_USER:
      return null;
    default:
      return state;
  }
}
