import React from 'react';
import { RouteComponentProps } from 'react-router';
import { RoutePath } from '../../Routes';
import Form from '../../Form/Form';
import { IRoom, IUser } from '../../../store/Types';

const data = [
  {
    className: 'input_username',
    labelName: 'Username',
    placeholderText: 'Enter your name',
    inputName: 'username',
  },
];

interface IMatchParams {
  id: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  createUser(userName: string): Promise<{ user: IUser; token: string }>;
  addMemberToRoom(roomId: string, userId: string): Promise<IRoom>;
  user: IUser;
  room: IRoom;
}

class InvitePageView extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  public async handleSubmit(inputUsernameValue: string) {
    try {
      await this.props.createUser(inputUsernameValue);
      await this.props.addMemberToRoom(this.props.match.params.id, this.props.user.id);
      this.props.history.push(`${RoutePath.MAIN}/${this.props.match.params.id}`);
    } catch (error) {
      alert(error);
    }
  }

  render() {
    return (
      <>
        <main className='main_main'>
          <div className='main_block'>
            <Form title={'Join the room:'} values={data} onSubmit={this.handleSubmit} />
          </div>
        </main>
      </>
    );
  }
}

export default InvitePageView;
