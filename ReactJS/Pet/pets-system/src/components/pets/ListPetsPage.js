import React, {Component} from 'react'
import queryString from 'query-string'
import petActions from '../../actions/PetActions'
import petStore from '../../stores/PetStore'

class ListPetsPage extends Component{
    constructor(props)
    {
        super(props)

        let query = queryString.parse(this.props.location.search)
        let page = parseInt(query.page) || 1
        this.state = {
            pets: [],
            'page': page
        }
        this.handlePetsFetched = this.handlePetsFetched.bind(this)
        petStore.on(petStore.eventTypes.PETS_FETCHED, this.handlePetsFetched)
    }

    handlePetsFetched (data){
        console.log(data)
    }

    componentDidMount(){
        petActions.all(this.state.page)
    }

    componentWillUnmount(){
        petStore.removeListener(petStore.eventTypes.PETS_FETCHED, this.handlePetsFetched)
    }

    render() {
        return (
            <div>Pets</div>
        )
    }
}

export default ListPetsPage