class FormHelpers {
    static handleFormChange(event, stateField){
        const target = event.target
        const field = target.name
        const value = target.value
        const state = this.state[stateField]
        state[field] = value
        this.setState({ [stateField]: state})
    }

    static getErrorMessage(data, )
    {
        let firstError = ''
        if(data.errors)
        {
            firstError = Object
            .keys(data.errors)
            .map(k => data.error[k])[0]
        }
        return firstError
    }
}

export default FormHelpers