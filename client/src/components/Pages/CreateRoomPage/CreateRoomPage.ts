import React from 'react';
import { withRouter } from 'react-router-dom';
import { IRootState } from '../../../store/Types';
import { AnyAction, compose } from 'redux';
import { connect } from 'react-redux';
import { ThunkDispatch } from 'redux-thunk';
import CreateRoomPageView from './CreateRoomPageView';
import { createUserAndRoomWithDiscussionOperation } from '../../../store/Room/RoomOperations';

const mapStateToProps = (state: IRootState) => {
  return {
    room: state.room,
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch: ThunkDispatch<IRootState, unknown, AnyAction>) => {
  return {
    createUserAndRoomWithDiscussion: async (userName: string, roomName: string, discussionName: string) => {
      return dispatch(await createUserAndRoomWithDiscussionOperation(userName, roomName, discussionName));
    },
  };
};

export default compose<React.ComponentClass>(
  withRouter,
  connect(mapStateToProps, mapDispatchToProps)
)(CreateRoomPageView);
