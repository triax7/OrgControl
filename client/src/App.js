import './App.css';
import React from 'react';
import { ConnectedRouter } from 'connected-react-router';
import { Route, Switch } from 'react-router';
import { history } from './redux/configureStore';
import UserDisplay from './components/TestDisplayUser';
import RegistrationForm from './components/RegistrationForm';
import LoginForm from './components/LoginForm';
import Header from './components/Header';
import EventsList from './components/EventsList/EventsList';
import EventPage from './components/EventPage/EventPage';

function App() {
  return (
    <ConnectedRouter history={history}> { /* place ConnectedRouter under Provider */}
      <> { /* your usual react-router v4/v5 routing */}
        <Header/>
        <Switch>
          <Route exact path='/user' component={UserDisplay}/>
          <Route exact path='/register' component={RegistrationForm}/>
          <Route exact path='/login' component={LoginForm}/>
          <Route exact path='/events' component={EventsList}/>
          <Route exact path='/events/:id' component={EventPage}/>
          <Route render={() => (<div>No route :(</div>)}/>
        </Switch>
      </>
    </ConnectedRouter>
  );
}

export default App;
