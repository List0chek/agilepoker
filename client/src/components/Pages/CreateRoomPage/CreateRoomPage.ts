import React from 'react';
import { withRouter } from 'react-router-dom';
import { IRootState } from '../../../store/Types';
import { compose, Dispatch } from 'redux';
import { connect } from 'react-redux';
import CreateRoomPageView from './CreateRoomPageView';
import { createUserAndRoomWithDiscussionOperation } from '../../../store/Room/RoomOperations';

const mapStateToProps = (state: IRootState) => {
  return {
    room: state.room,
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
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
