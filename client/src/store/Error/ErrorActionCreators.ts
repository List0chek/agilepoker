import { Action } from 'redux';
import { ActionType } from '../Reducer';
import { IError } from '../Types';

export interface IUpdateErrorAction extends Action {
  error: IError;
}

export const updateError = (error: IError): IUpdateErrorAction => {
  return {
    type: ActionType.UPDATE_ERROR,
    error
  };
};
