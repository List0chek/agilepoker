import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { Dispatch, compose } from 'redux';
import { IRootState } from '../../../store/Types';
import RoomPageView from './RoomPageView';
import {
  addMemberToRoomOperation,
  closeDiscussionOperation,
  createDiscussionOperation,
  deleteDiscussionOperation,
  loadRoomOperation,
  setVoteOperation,
} from '../../../store/Room/RoomOperations';
import { loadUserOperation } from '../../../store/User/UserOperations';

const mapStateToProps = (state: IRootState) => {
  return {
    room: state.room,
    user: state.user,
    error: state.error,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    setVote: async (discussionId: string, userId: string, cardId: string) => {
      return dispatch(await setVoteOperation(discussionId, userId, cardId));
    },
    loadUser: async () => {
      return dispatch(await loadUserOperation());
    },
    loadRoomInfo: async (roomId: string, userId: string) => {
      return dispatch(await loadRoomOperation(roomId, userId));
    },
    closeDiscussion: async (roomId: string, discussionId: string, userId: string) => {
      return dispatch(await closeDiscussionOperation(roomId, discussionId, userId));
    },
    createDiscussion: async (roomId: string, topicName: string, userId: string) => {
      return dispatch(await createDiscussionOperation(roomId, topicName, userId));
    },
    deleteDiscussion: async (roomId: string, discussionId: string, userId: string) => {
      return dispatch(await deleteDiscussionOperation(roomId, discussionId, userId));
    },
    addMemberToRoom: async (roomId: string, userId: string) => {
      return dispatch(await addMemberToRoomOperation(roomId, userId));
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
