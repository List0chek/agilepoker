import React from 'react';
import { RoutePath } from '../../Routes';
import { RouteComponentProps } from 'react-router';
import Form from '../../Form/Form';
import { IRoom, IUser } from '../../../store/Types';

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

interface IProps extends RouteComponentProps<any> {
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

  public async handleSubmit(inputUsernameValue: string, inputRoomnameValue: string, inputDiscussionName: string) {
    try {
      await this.props.createUserAndRoomWithDiscussion(inputUsernameValue, inputRoomnameValue, inputDiscussionName);
      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.id}`);
    } catch (error) {
      alert(error);
    }
  }

  render() {
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
