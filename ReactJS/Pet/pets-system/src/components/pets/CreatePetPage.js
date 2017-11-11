import React, { Component } from 'react'
import CreatePetForm from './CreatePetForm'
import FormHelper from '../common/FormHelpers'
import petActions from '../../actions/PetActions'
import petStore from '../../stores/PetStore'
import toastr from 'toastr'

class CreatePetPage extends Component {
    constructor(props)
    {
        super(props)
        
        this.state = {
            pet: {
                name: 'PEsho',
                image: 'http://www.petsworld.in/blog/wp-content/uploads/2014/09/adorable-cat.jpg',
                age: '2',
                type: 'Cat',
                breed: 'Persion'
            },
            error: ''
        }
        this.handlePetCreate = this.handlePetCreate.bind(this)
        petStore.on(petStore.eventTypes.PET_CREATED, this.handlePetCreate)
    }

    componentWillUnmount()
    {
        petStore.removeListener(petStore.eventTypes.PET_CREATED, this.handlePetCreate)
    }
    
    handlePetCreate(pet)
    {
        if(!pet.success)
        {
            let error = FormHelper.getErrorMessage(pet)
            this.setState({
                error
            })
        }
        else{
            toastr.success(pet.message)
            this.props.history.push(`/pets/details/${pet.pet.id}`)
        }
    }

    handleChange(event)
    {
        FormHelper.handleFormChange.bind(this)(event, 'pet')
    }

    handleForm(event)
    {
        event.preventDefault()
        petActions.create(this.state.pet)
        // validateForm
    }

    render() {
        return(
            <div>
                <h1>Pet Create</h1>
                <CreatePetForm
                    pet={this.state.pet}
                    error={this.state.error}
                    onChange={this.handleChange.bind(this)}
                    onSave={this.handleForm.bind(this)} />
            </div>
        )
    }
}
export default CreatePetPage