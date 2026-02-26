import React from 'react';
import cellUserIcon from '../../../images/User Icon.svg';
import checkCircle from '../../../images/check_circle_24px.png';
import { ICard, IUser } from '../../../store/Types';
import './PlayerRow.css';

export interface IPlayerRowProps {
  user: IUser;
  card?: ICard;
  isCardChecked?: boolean | null;
  isDiscussionClosed: boolean;
}

const coffeeIcon = (
  <svg className='card_text' width='27' height='24' viewBox='0 0 38 34' xmlns='http://www.w3.org/2000/svg'>
    <path d='M33.6667 0.5H4.33333V18.8333C4.33333 22.885 7.615 26.1667 11.6667 26.1667H22.6667C26.7183 26.1667 30 22.885 30 18.8333V13.3333H33.6667C35.7017 13.3333 37.3333 11.7017 37.3333 9.66667V4.16667C37.3333 2.13167 35.7017 0.5 33.6667 0.5ZM33.6667 9.66667H30V4.16667H33.6667V9.66667ZM33.6667 33.5H0.666668V29.8333H33.6667V33.5Z' />
  </svg>
);

const PlayerRow: React.FunctionComponent<IPlayerRowProps> = (props): React.ReactElement => {
  let userVoteValueIcon: React.ReactNode;

  if (props.card) {
    switch (props.card.value) {
      case 'coffee':
        userVoteValueIcon = coffeeIcon;
        break;
      case 'infinity':
        userVoteValueIcon = '∞';
        break;
      default:
        userVoteValueIcon = props.card.name;
    }
  } else {
    userVoteValueIcon = `?`;
  }

  return (
    <tr className='row'>
      <td className='cell_user_icon'>
        <img src={cellUserIcon} alt='userIcon' width='42' height='42' />
      </td>
      <td className='cell_username'>{props.user.name}</td>
      <td className='cell_voted_icon'>
        {!props.isDiscussionClosed && props.isCardChecked === true && (
          <img src={checkCircle} alt='check_circle_icon' width='24' height='24' />
        )}
        {props.isDiscussionClosed && userVoteValueIcon}
      </td>
    </tr>
  );
};

export default PlayerRow;
