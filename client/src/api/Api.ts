import { IError, IRoom, IUser } from '../store/Types';
import { post, get } from './FetchWrapper';
import authService from '../services/AuthService';

const baseUrl = 'http://localhost:52106/api';

export const createUserRequest = async (userName: string): Promise<IUser> => {
  const response = await post(`${baseUrl}/user/create/?name=${userName}`);
  authService.setToken(response.token);
  return response.user;
};

export const getUserRequest = async (): Promise<IUser> => {
  return await get(`${baseUrl}/user/get`, { token: authService.getToken() });
};

export const deleteUserRequest = async (): Promise<void> => {
  return await get(`${baseUrl}/user/delete`, { token: authService.getToken() });
};

export const createRoomRequest = async (roomName: string, userId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/room/create/?name=${roomName}&ownerId=${userId}`, { token: authService.getToken() });
};

export const addMemberToRoomRequest = async (roomId: string, userId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/room/addmember/?roomId=${roomId}&newUserId=${userId}`);
};

export const getRoomInfoRequest = async (roomId: string, userId: string): Promise<IRoom> => {
  return await get(`${baseUrl}/room/getroominfo/?roomId=${roomId}&userId=${userId}`);
};

export const createDiscussionRequest = async (roomId: string, topicName: string, hostId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/discussion/create/?roomId=${roomId}&topic=${topicName}&hostId=${hostId}`, {
    token: authService.getToken(),
  });
};

export const setVoteRequest = async (discussionId: string, userId: string, cardId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/discussion/setvote/?discussionId=${discussionId}&userId=${userId}&cardId=${cardId}`);
};

export const closeDiscussionRequest = async (roomId: string, discussionId: string, hostId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/discussion/close/?roomId=${roomId}&discussionId=${discussionId}&hostId=${hostId}`);
};

export const deleteDiscussionRequest = async (roomId: string, discussionId: string, hostId: string): Promise<IRoom> => {
  return await post(`${baseUrl}/discussion/delete/?roomId=${roomId}&discussionId=${discussionId}&hostId=${hostId}`);
};

export const createUserAndRoomWithDiscussionRequest = async (
  userName: string,
  roomName: string,
  discussionName: string
): Promise<{ user: IUser; room: IRoom }> => {
  const response = await post(
    `${baseUrl}/room/CreateUserAndRoomWithDiscussion/?userName=${userName}&roomName=${roomName}&discussionName=${discussionName}`
  );
  authService.setToken(response.token);
  return {
    user: response.user,
    room: response.room,
  };
};
