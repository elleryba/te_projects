import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:8081/worldbreweries" // java api server 
});


export default {

    getListOfWorldBreweries(){
        return axios.get(`https://api.openbrewerydb.org/breweries`)
    },                      // need to talk to back-end about which path and params 
    
    getWorldBreweryByName(name){ //updated params and path
        return http.get(`/breweries?by_name=${name}`)
    },
    
    getWorldBreweryByState(state){
        return http.get(`/breweries?by_state=${state}`)
    }

    //getBreweryByName(name){ // Wasnt working 
    //    return http.get(`/get`,name)
    //}
}