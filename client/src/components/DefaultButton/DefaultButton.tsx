import React from 'react';
import './DefaultButton.css';

interface IProps {
  className: string;
  buttonText: React.ReactNode;
  onClick(): void;
}

const DefaultButton: React.FunctionComponent<IProps> = (props) => {
  const handleClick = () => {
    props.onClick();
  };

  return (
    <button className={props.className} type='button' onClick={handleClick}>
      {props.buttonText}
    </button>
  );
};

export default DefaultButton;
