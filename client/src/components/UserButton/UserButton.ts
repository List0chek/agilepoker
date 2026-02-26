import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { IRootState } from '../../store/Types';
import { deleteUserOperation } from '../../store/User/UserOperations';
import UserButtonView from './UserButtonView';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    deleteUser: async () => {
      dispatch(await deleteUserOperation());
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(UserButtonView);
