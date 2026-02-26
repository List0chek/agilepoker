import React from 'react';
import './InviteFriend.css';

interface IProps {
  url: string;
}

const InviteFriend: React.FunctionComponent<IProps> = (props) => {
  const handleClick = (event: any) => {
    event.target.select();
  };

  return (
    <div className='story_vote_invite_friend'>
      <label>
        Invite friend
        <input
          className='story_vote_invite_friend_url'
          type='url'
          name='url'
          value={props.url}
          onClick={handleClick}
          readOnly
        />
      </label>
    </div>
  );
};

export default InviteFriend;
