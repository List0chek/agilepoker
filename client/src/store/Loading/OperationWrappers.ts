import { Dispatch } from 'redux';
import { toggleLoadingIndicator } from './LoadingActionCreators';

export const operationWithLoadingIndicatorWrapper = async <T>(
  dispatch: Dispatch,
  operation: () => Promise<T>
): Promise<T> => {
  dispatch(toggleLoadingIndicator(true));
  try {
    return await operation();
  } catch (error: any) {
    console.log(error);
    throw error;
  } finally {
    dispatch(toggleLoadingIndicator(false));
  }
};

export const baseOperationWrapper = async <T>(dispatch: Dispatch, operation: () => Promise<T>): Promise<T> => {
  try {
    return await operation();
  } catch (error: any) {
    console.log(error);
    throw error;
  }
};
