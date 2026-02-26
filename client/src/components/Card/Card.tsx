import React from 'react';
import { ICard } from '../../store/Types';
import './Card.css';

interface IProps {
  card: ICard;

  onChange(value: ICard): void;
}

const coffeeIcon = (
  <svg className='card_text' width='38' height='34' viewBox='0 0 38 34' xmlns='http://www.w3.org/2000/svg'>
    <path d='M33.6667 0.5H4.33333V18.8333C4.33333 22.885 7.615 26.1667 11.6667 26.1667H22.6667C26.7183 26.1667 30 22.885 30 18.8333V13.3333H33.6667C35.7017 13.3333 37.3333 11.7017 37.3333 9.66667V4.16667C37.3333 2.13167 35.7017 0.5 33.6667 0.5ZM33.6667 9.66667H30V4.16667H33.6667V9.66667ZM33.6667 33.5H0.666668V29.8333H33.6667V33.5Z' />
  </svg>
);

const Card: React.FunctionComponent<IProps> = (props): React.ReactElement => {
  const handleChange = (): void => {
    props.onChange(props.card);
  };

  let cardIcon: React.ReactNode;

  switch (props.card.value) {
    case 'coffee':
      cardIcon = coffeeIcon;
      break;
    case 'infinity':
      cardIcon = '∞';
      break;
    default:
      cardIcon = props.card.name;
  }

  return (
    <>
      <input
        id={props.card.id}
        className='radio'
        type='radio'
        name='radio'
        value={props.card.value}
        onChange={handleChange}
      />
      <label className='card' htmlFor={props.card.id}>
        <span className='card_text'>{cardIcon}</span>
      </label>
    </>
  );
};

export default Card;
