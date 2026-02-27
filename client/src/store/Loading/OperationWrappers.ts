import { Dispatch } from 'redux';
import { toggleLoadingIndicator } from './LoadingActionCreators';

export const operationWithLoadingIndicatorWrapper = async <T>(dispatch: Dispatch, operation: () => Promise<T>): Promise<T> => {
  dispatch(toggleLoadingIndicator(true));
  try {
    return await operation();
  }
  finally {
    dispatch(toggleLoadingIndicator(false));
  }
};

export const baseOperationWrapper = async <T>(dispatch: Dispatch, operation: () => Promise<T>): Promise<T> => {
  return operation();
};
