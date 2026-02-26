import React from 'react';
import { Link } from 'react-router-dom';
import { RoutePath } from '../Routes';
import './Footer.css';

const Footer = () => {
  return (
    <footer className='main_footer'>
      <div className='main_footer_content_block'>
        <p className='main_footer_copyright'>
          Copyright 2021{' '}
          <Link className='main_footer_url' to={RoutePath.INDEX}>
            PlanPoker
          </Link>
        </p>
      </div>
    </footer>
  );
};

export default Footer;
