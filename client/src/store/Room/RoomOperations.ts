import * as api from '../../api/Api';
import { updateRoom } from './RoomActionCreators';
import { Dispatch } from 'redux';
import { IRoom, IRootState, IUser } from '../Types';
import { updateUser } from '../User/UserActionCreators';
import { baseOperationWrapper, operationWithLoadingIndicatorWrapper } from '../Loading/OperationWrappers';

export const createRoomOperation = (roomName: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.createRoomRequest(roomName, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const setVoteOperation = (discussionId: string, userId: string, cardId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.setVoteRequest(discussionId, userId, cardId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const loadRoomOperation = (roomId: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return baseOperationWrapper(dispatch, async () => {
      const response = await api.getRoomInfoRequest(roomId, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const closeDiscussionOperation = (roomId: string, discussionId: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.closeDiscussionRequest(roomId, discussionId, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const createDiscussionOperation = (roomId: string, topicName: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.createDiscussionRequest(roomId, topicName, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const deleteDiscussionOperation = (roomId: string, discussionId: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.deleteDiscussionRequest(roomId, discussionId, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const addMemberToRoomOperation = (roomId: string, userId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.addMemberToRoomRequest(roomId, userId);
      dispatch(updateRoom(response));
      return response;
    });
  };
};

export const createUserAndRoomWithDiscussionOperation = (
  userName: string,
  roomName: string,
  discussionName: string
): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<{ user: IUser; room: IRoom }> => {
    return operationWithLoadingIndicatorWrapper(dispatch, async () => {
      const response = await api.createUserAndRoomWithDiscussionRequest(userName, roomName, discussionName);
      dispatch(updateUser(response.user));
      dispatch(updateRoom(response.room));
      return response;
    });
  };
};
