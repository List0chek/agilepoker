import React from 'react';
import './Spinner.css';

interface IProps {
  show: boolean;
}

const Spinner: React.FC<IProps> = (props) => {
  if (!props.show) return null;
  return (
    <div className={'loading_indicator_wrap'}>
      <div className={'lds-facebook'}>
        <div></div>
        <div></div>
        <div></div>
      </div>
    </div>
  );
};

export default Spinner;
