import React, { Component } from 'react'
import LoginForm from './LoginForm'
import FormHelpers from '../common/FormHelpers'
import userActions from '../../actions/UserActions'
import userStore from '../../stores/UserStore'
import Auth from './Auth'
import toastr from 'toastr'

class LoginPage extends Component{
    constructor(props)
    {
        super(props)

        this.state = {
            user: {
                email: 'test@test.com',
                password: '123456'
            },
            error: ''
        }
        this.handleUserLogin = this.handleUserLogin.bind(this)
        userStore.on(userStore.eventTypes.USER_LOGGED_IN, this.handleUserLogin)
    }

    componentWillUnmount()
    {
        userStore.removeListener(userStore.eventTypes.USER_LOGGED_IN, this.handleUserLogin)
    }

    handleUserLogin(data)
    {
        if(!data.success)
        {
            this.setState({
                error: data.message
            })
        }
        else {
            Auth.authenticateUser(data.token)
            Auth.saveUser(data.user)
            toastr.success(data.message)
            this.props.history.push('/')
        }
    }

     handleUserChange(event)
     {
        FormHelpers.handleFormChange.bind(this)(event, 'user')
     }

     handleUserForm(event){
         event.preventDefault()

         // Validate form
         userActions.login(this.state.user)
     }

    render(){
        return(
            <div>
                <h1>Login Into Your Account</h1>
                <LoginForm onChange={this.handleUserChange.bind(this)} onSave={this.handleUserForm.bind(this)} user={this.state.user}/>
            </div>
        )
    }
}

export default LoginPage