import { Action } from 'redux';
import { ActionType } from '../Reducer';

export interface IToggleLoadingIndicator extends Action {
  showIndicator: boolean;
}

export const toggleLoadingIndicator = (showIndicator: boolean): IToggleLoadingIndicator => {
  return {
    type: ActionType.TOGGLE_LOADING_INDICATOR,
    showIndicator,
  };
};
