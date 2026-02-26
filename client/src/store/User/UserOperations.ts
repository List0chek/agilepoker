import * as api from '../../api/Api';
import { Dispatch } from 'redux';
import { IRootState, IUser } from '../Types';
import { updateUser, deleteUser as deleteUserFromStore } from './UserActionCreators';
import { deleteRoom } from '../Room/RoomActionCreators';
import { operationWithLoadingIndicatorWrapper } from '../Loading/OperationWrappers';

export const loadUserOperation = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IUser> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.getUserRequest();
      dispatch(updateUser(response));
      return response;
    });
  };
};

export const createUserOperation = (userName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IUser> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.createUserRequest(userName);
      dispatch(updateUser(response));
      return response;
    });
  };
};

export const deleteUserOperation = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      await api.deleteUserRequest();
      localStorage.clear();
      dispatch(deleteUserFromStore());
      dispatch(deleteRoom());
    });
  };
};
