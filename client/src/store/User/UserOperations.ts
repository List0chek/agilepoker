import { Dispatch } from 'redux';
import * as api from '../../api/Api';
import { operationWithLoadingIndicatorWrapper } from '../Loading/OperationWrappers';
import { deleteRoom } from '../Room/RoomActionCreators';
import { IUser } from '../Types';
import { deleteUser as deleteUserFromStore, updateUser } from './UserActionCreators';

export const loadUserOperation = (): ((dispatch: Dispatch) => Promise<IUser>) => {
  return async (dispatch: Dispatch): Promise<IUser> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.getUserRequest();
      dispatch(updateUser(response));
      return response;
    });
  };
};

export const createUserOperation = (userName: string): ((dispatch: Dispatch) => Promise<IUser>) => {
  return async (dispatch: Dispatch): Promise<IUser> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.createUserRequest(userName);
      dispatch(updateUser(response));
      return response;
    });
  };
};

export const deleteUserOperation = (): ((dispatch: Dispatch) => Promise<void>) => {
  return async (dispatch: Dispatch): Promise<void> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      await api.deleteUserRequest();
      localStorage.clear();
      dispatch(deleteUserFromStore());
      dispatch(deleteRoom());
    });
  };
};
