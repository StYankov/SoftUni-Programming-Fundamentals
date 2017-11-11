import React, { Component } from 'react'
import { Switch, Route } from 'react-router-dom'
import ListPetsPage from '../pets/ListPetsPage'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import PrivateRoute from './PrivateRoute'
import LogoutPage from '../users/LogoutPage'
import CreatePetPage from '../pets/CreatePetPage'

class Routes extends Component {
    render() {
        return (
            <Switch>
                <Route path='/' exact component={ListPetsPage} />
                <Route path='/users/register' component={ RegisterPage } />
                <Route path='/users/login' component={LoginPage} />
                <PrivateRoute path='/pets/add' component={CreatePetPage} />
                <PrivateRoute exact path='/users/logout' component={LogoutPage} />
            </Switch>
            )
    }
}

export default Routes