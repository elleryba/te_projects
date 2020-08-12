import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:8080" // java api server 
});


export default {

    getListOfBreweries(){
        return http.get(`/home`);
        // return http.get(`/home`); // what path do i want to put in here...does it need to be the path that back-end put in their contoller
    },                      // need to talk to back-end about which path and params 
    addBrewery(aBrewery){
        return http.post(`/add`, aBrewery); // updated the path from back-end 
    },
    updateBrewery(id, aBrewery){ //updated params and path
        return http.put(`/update/${id}`, aBrewery)
    },
    deleteBrewery(breweryId){
        return http.delete(``, breweryId)
    },

    //getBreweryByName(name){ // Wasnt working 
    //    return http.get(`/get`,name)
    //}
}