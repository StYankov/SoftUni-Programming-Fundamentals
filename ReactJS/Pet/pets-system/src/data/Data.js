import Auth from '../components/users/Auth'
const baseUrl = 'http://localhost:5000/'
const getOptions = () => {
    return {
        headers: {
            "Content-Type": 'application/json',
            'Accept': 'application/json'
        },
        mode: 'cors' 
    }
}

const applyAuthorizationHeader = (options, authenticated) => {
    if(authenticated)
    {
        options.headers.Authorization = `bearer ${Auth.getToken()}`
    }
}

class Data {
    static post(url, data, authenticated){
        let options = getOptions()
        options.method = 'POST'
        options.body = JSON.stringify(data)
        applyAuthorizationHeader(options, authenticated)

        return window.fetch(`${baseUrl}${url}`, options)
        .then(res => res.json())
    }

    static get(url, authenticate){
        let options = getOptions()
        options.method = 'GET'
        applyAuthorizationHeader()
    
        return window.fetch(`${baseUrl}${url}`, options)
        .then(res => res.json())
    }
}

export default Data