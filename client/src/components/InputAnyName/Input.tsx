import React from 'react';
import './Input.css';

export interface IInputProps {
  className: string;
  labelName: string;
  placeholderText: string;
  inputName: string;
}

class Input extends React.Component<IInputProps> {
  constructor(props: IInputProps) {
    super(props);
  }

  render(): React.ReactElement {
    const { className, labelName, placeholderText, inputName } = this.props;
    return (
      <div className={className}>
        <label className='login_form_label' htmlFor={labelName}>
          {labelName}
        </label>
        <input
          className='textarea_name'
          id={labelName}
          type='text'
          name={inputName}
          placeholder={placeholderText}
          required={true}
        />
      </div>
    );
  }
}

export default Input;
