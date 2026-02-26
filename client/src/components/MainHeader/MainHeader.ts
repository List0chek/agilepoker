import { connect } from 'react-redux';
import { IRootState } from '../../store/Types';
import './MainHeader.css';
import MainHeaderView from './MainHeaderView';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
  };
};

export default connect(mapStateToProps)(MainHeaderView);
