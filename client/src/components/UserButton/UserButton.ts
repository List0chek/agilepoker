import { connect } from 'react-redux';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';
import { IRootState } from '../../store/Types';
import { deleteUserOperation } from '../../store/User/UserOperations';
import UserButtonView from './UserButtonView';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch: ThunkDispatch<IRootState, unknown, AnyAction>) => {
  return {
    deleteUser: async () => {
      dispatch(await deleteUserOperation());
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(UserButtonView);
