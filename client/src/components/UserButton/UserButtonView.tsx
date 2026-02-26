import React from 'react';
import userIcon from '../../images/User Icon.svg';
import DefaultButton from '../DefaultButton/DefaultButton';
import { IUser } from '../../store/Types';
import history from '../../services/HistoryService';
import { RoutePath } from '../Routes';
import './UserButton.css';

interface IProps {
  userName: string;
  user: IUser | null;
  deleteUser(): void;
}

class UserButtonView extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
    this.handleSignOutButtonClick = this.handleSignOutButtonClick.bind(this);
  }

  public async handleSignOutButtonClick() {
    history.push(`${RoutePath.INDEX}`);
    await this.props.deleteUser();
  }

  render() {
    return (
      <button className='user_btn' id='user_button'>
        <div className={'user_btn_username_and_logo_wrap'}>
          <span className='user_btn_username'>{this.props.userName}</span>
          <img src={userIcon} alt='userIcon' width='59' height='59' />

          <DefaultButton
            onClick={this.handleSignOutButtonClick}
            buttonText={'Sign out'}
            className={'sign_out_button'}
          />
        </div>
      </button>
    );
  }
}

export default UserButtonView;
