import React from 'react';
import { RouteComponentProps } from 'react-router';
import { IRoom, IUser } from '../../../store/Types';
import Form from '../../Form/Form';
import { RoutePath } from '../../Routes';

const data = [
  {
    className: 'input_username',
    labelName: 'Username',
    placeholderText: 'Enter your name',
    inputName: 'username',
  },
  {
    className: 'input_roomname',
    labelName: 'Room name',
    placeholderText: 'Enter room name',
    inputName: 'roomname',
  },
  {
    className: 'input_discussionName',
    labelName: 'Discussion name',
    placeholderText: 'Enter discussion name',
    inputName: 'discussionName',
  },
];

interface IProps extends RouteComponentProps {
  createUserAndRoomWithDiscussion(
    userName: string,
    roomName: string,
    discussionName: string
  ): Promise<{ user: IUser; room: IRoom }>;
  room: IRoom;
  user: IUser;
}

class CreateRoomPageView extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  public async handleSubmit(inputUsernameValue: string, inputRoomnameValue: string, inputDiscussionName: string): Promise<void> {
    try {
      await this.props.createUserAndRoomWithDiscussion(inputUsernameValue, inputRoomnameValue, inputDiscussionName);
      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.id}`);
    }
 catch (error) {
      alert(error);
    }
  }

  render(): React.ReactElement {
    return (
      <>
        <main className='main_main'>
          <div className='main_block'>
            <Form title={'Create the room:'} values={data} onSubmit={this.handleSubmit} />
          </div>
        </main>
      </>
    );
  }
}

export default CreateRoomPageView;
