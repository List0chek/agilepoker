import React from 'react';
import './Button.css';

interface IProps {
  className: string;
  onClick?(event: React.FormEvent): void;
}

const Button: React.FunctionComponent<IProps> = (props) => {
  const handleClick = (event: React.FormEvent) => {
    props.onClick && props.onClick(event);
  };

  return (
    <div className='input_enter_btn'>
      <button className={`enter_btn + ${props.className}`} onClick={handleClick}>
        Enter
      </button>
    </div>
  );
};

export default Button;
