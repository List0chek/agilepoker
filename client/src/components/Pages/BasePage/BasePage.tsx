import React from 'react';
import Footer from '../../Footer/Footer';
import MainHeader from '../../MainHeader/MainHeader';

const BasePage: React.FunctionComponent<any> = (props) => {
  return (
    <>
      <MainHeader />
      {props.children}
      <Footer />
    </>
  );
};

export default BasePage;
