import { IRootState } from '../../store/Types';
import { connect } from 'react-redux';
import MainHeaderView from './MainHeaderView';
import './MainHeader.css';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
  };
};

export default connect(mapStateToProps)(MainHeaderView);
