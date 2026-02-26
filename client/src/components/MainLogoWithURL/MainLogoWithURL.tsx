import React from 'react';
import { Link } from 'react-router-dom';
import { RoutePath } from '../Routes';
import logo from '../../images/pie_chart_24px.svg';
import './MainLogoWithURL.css';

const MainLogoWithURL = () => {
  return (
    <Link className='main_page_url' to={RoutePath.INDEX}>
      <img className='main_page_url_logo' src={logo} alt='logo' width='48.33' height='48.33' />
      <h1 className='main_page_url_name'>PlanPoker</h1>
    </Link>
  );
};

export default MainLogoWithURL;
