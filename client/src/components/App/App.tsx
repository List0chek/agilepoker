import * as React from 'react';
import { Switch, Route } from 'react-router-dom';
import { RoutePath } from '../Routes';
import FirstPage from '../Pages/CreateRoomPage/CreateRoomPage';
import InvitePage from '../Pages/InvitePage/InvitePage';
import RoomPage from '../Pages/RoomPage/RoomPage';
import ErrorPage from '../Pages/ErrorPage/ErrorPage';
import BasePage from '../Pages/BasePage/BasePage';
import { connect } from 'react-redux';
import { IRootState } from '../../store/Types';
import Spinner from '../Spinner/Spinner';
import './App.css';

interface IProps {
  loadingIndicator: boolean;
}

const App: React.FunctionComponent<IProps> = ({ loadingIndicator }) => {
  return (
    <BasePage>
      <Spinner show={loadingIndicator} />
      <Switch>
        <Route path={RoutePath.INDEX} exact={true} component={FirstPage} />
        <Route path={`${RoutePath.MAIN}/:id`} exact={true} component={RoomPage} />
        <Route path={`${RoutePath.INVITE}/:id`} exact={true} component={InvitePage} />
        <Route component={ErrorPage} />
      </Switch>
    </BasePage>
  );
};

const mapStateToProps = (state: IRootState) => {
  return {
    loadingIndicator: state.loadingIndicator,
  };
};

export default connect(mapStateToProps)(App);
