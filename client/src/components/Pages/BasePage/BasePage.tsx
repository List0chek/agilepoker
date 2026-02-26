import React from 'react';
import MainHeader from '../../MainHeader/MainHeader';
import Footer from '../../Footer/Footer';

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
