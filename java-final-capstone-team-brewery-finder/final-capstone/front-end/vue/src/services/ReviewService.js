import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:8080" // java api server 
});


export default {
    addReview(reviewDto){
        return http.post(`/beers/addreview`, reviewDto)
      },
      getListOfReviews(name){
        return http.get(`/beers/${name}/reviews`);
    }

}