import { Action } from 'redux';
import { ActionType } from '../Reducer';
import { IUser } from '../Types';

export interface IUpdateUserAction extends Action {
  user: IUser;
}

export const updateUser = (user: IUser): IUpdateUserAction => {
  return {
    type: ActionType.UPDATE_USER,
    user: user
  };
};

export const deleteUser = (): Action => {
  return {
    type: ActionType.DELETE_USER,
  };
};
