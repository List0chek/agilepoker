import { ActionType } from '../Reducer';
import { IUpdateErrorAction } from './ErrorActionCreators';
import { IError } from '../Types';

const initState = null;

export function errorReducer(state: IError | null = initState, action: IUpdateErrorAction): IError | null {
  switch (action.type) {
    case ActionType.UPDATE_ERROR:
      return action.error;
    default:
      return state;
  }
}
