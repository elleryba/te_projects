import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:8080" // java api server 
});


export default {
    getListOfBeers(name){
        return http.get(`/beers/${name}`);
    },
    getListOfAllBeers(){
      return http.get(`/beers`);
  }, 
    addBeer(beerDto){
      return http.post(`/addbeer`, beerDto)
    },
    deleteBeer(beerDto){
      console.log(`${beerDto}`);
      return http.delete(`/delete`, {data: beerDto})
    }
    
}
