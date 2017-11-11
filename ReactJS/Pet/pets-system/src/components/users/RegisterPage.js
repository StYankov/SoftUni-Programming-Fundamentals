import React, { Component } from 'react'
import RegisterForm from './RegisterForm'
import FormHelpers from '../common/FormHelpers'
import userActions from '../../actions/UserActions'
import UserStore from '../../stores/UserStore'
import toastr from 'toastr'

class RegisterPage extends Component{
    constructor(props)
    {
        super(props)

        this.state = {
            user: {
                email: 'test@test.com',
                password: '123456',
                name: 'Test',
                confirmPassword: '123456'
            },
            error: ''
        }

        this.handleUserRegistration = this.handleUserRegistration.bind(this)

        UserStore.on(UserStore.eventTypes.USER_REGISTERED, this.handleUserRegistration)
    }

    componentWIllUnmount()
    {
        UserStore.removeListener(UserStore.eventTypes.USER_REGISTERED, this.handleUserRegistration)
    }

    handleUserRegistration(data)
    {
        if(!data.success){
            let firstError = FormHelpers.getErrorMessage(data)
            this.setState({
                error: firstError
            })
        }
        else{
            toastr.success(data.message)
            this.props.history.push('/users/login')
        }
    }

    handleUserChange (event)
    {
        FormHelpers.handleFormChange.bind(this)(event, 'user')
    }

    handleUserForm (event)
    {
        event.preventDefault()

        if(!this.validateUser())
            return
        userActions.register(this.state.user)
    }

    validateUser() {
        const user = this.state.user
        let formIsValid = true;
        let error = ''
        if(user.password !== user.confirmPassword){
            error = 'Password and confirmation password doesn\'t match'
            formIsValid = false
        }

        if(error){
            this.setState({ error })
        }

        return formIsValid
    }

    render() {
        return (
            <div>
                <h1>Register User</h1>
                <RegisterForm 
                    user={this.state.user}
                    error={this.state.error}
                    onChange={this.handleUserChange.bind(this)} 
                    onSave={this.handleUserForm.bind(this)}/>
            </div>
        )
    }
}

export default RegisterPage