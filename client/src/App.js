import './App.css'
import React from 'react'
import {ConnectedRouter} from 'connected-react-router'
import {Route, Switch} from 'react-router'
import {history} from './redux/configureStore'
import UserDisplay from './components/TestDisplayUser'
import RegistrationForm from './components/RegistrationForm'
import LoginForm from './components/LoginForm';

function App() {
    return (
        <ConnectedRouter history={history}> { /* place ConnectedRouter under Provider */}
            <> { /* your usual react-router v4/v5 routing */}
                <Switch>
                    <Route exact path="/" render={() => (<div>Match</div>)}/>
                    <Route exact path='/user' component={UserDisplay}/>
                    <Route exact path='/register' component={RegistrationForm}/>
                    <Route exact path='/login' component={LoginForm}/>
                    <Route render={() => (<div>Miss</div>)}/>
                </Switch>
            </>
        </ConnectedRouter>
    )
}

export default App
