import React from 'react';
import './Spinner.css';

const Spinner: React.FC<any> = (props) => {
  return (
    props.show && (
      <div className={'loading_indicator_wrap'}>
        <div className={'lds-facebook'}>
          <div></div>
          <div></div>
          <div></div>
        </div>
      </div>
    )
  );
};

export default Spinner;
