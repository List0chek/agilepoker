import React from 'react';
import './ActionName.css';

interface IProps {
  actionName: string;
}

const ActionName: React.FunctionComponent<IProps> = (props) => {
  return <p className='login_form_action_name'>{props.actionName}</p>;
};

export default ActionName;
