import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:8080" // java api server 
});


export default {

    getListOfBreweries(){
        return http.get(`/home`);
    }, 
    addBrewery(aBrewery){
        return http.post(`/add`, aBrewery);
    },
    updateBrewery(id, aBrewery){
        return http.put(`/update/${id}`, aBrewery)
    },
    deleteBrewery(breweryId){
        return http.delete(``, breweryId)
    },
    getBreweryByName(name){ 
        return http.get(`/get/${name}`, name)
    }
}