import React from 'react';
import { IUser } from '../../store/Types';
import MainLogoWithURL from '../MainLogoWithURL/MainLogoWithURL';
import UserButton from '../UserButton/UserButton';

interface IProps {
  user: IUser | null;
}

const MainHeaderView: React.FunctionComponent<IProps> = (props) => {
  return (
    <header className='main_header'>
      <div className='main_header_content_block'>
        <MainLogoWithURL />
        {props.user && <UserButton userName={props.user.name} />}
      </div>
    </header>
  );
};

export default MainHeaderView;
