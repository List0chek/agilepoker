import React from 'react';
import Footer from '../../Footer/Footer';
import MainHeader from '../../MainHeader/MainHeader';

interface IProps {
  children?: React.ReactNode;
}

const BasePage: React.FunctionComponent<IProps> = (props) => {
  return (
    <>
      <MainHeader />
      {props.children}
      <Footer />
    </>
  );
};

export default BasePage;
