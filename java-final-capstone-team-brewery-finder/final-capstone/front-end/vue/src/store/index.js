import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    breweries: [],
    beers: [],
    beerDtos: [],
    reviews: [],
    reviewDtos: [],

    activeBrewery:{  // might need 
      brewery_name: "",
      history: "",
      open_from: "",
      open_to: "",
      days_open: "",
      address: ""
    }
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    SET_BREWS(state, data){
      state.breweries = data;
    },
    ADD_BREWERY(state, data){ // added and called by CreateBrewery and UpdateBrewery
     // state.activeBrewery = data; originally had this 
     state.breweries.push(data); // changed to this but not sure if right
     //unshift will add the new object to the beginning of the array
     //looks good!  
    },
    UPDATE_BREW(state, data){
      let brewToUpdate = state.breweries.find(x => x.id === data.id)
    
      if(brewToUpdate){
      
        brewToUpdate = data;
        
      }
    },
    ADD_BEER(state, data){
      state.beerDtos.push(data);
    },
    SET_BEERS(state, data){ // added this to be called in our beers list component
    state.beers = data;
    },
    DELETE_BEER(state, data){ // not sure what to put here but created so can be included in method
      state.beerDtos.pop(data);
    },
    SET_REVIEWS(state, data){
      state.reviews = data;
    },
    ADD_REVIEW(state, data){
      state.reviews.push(data);
    },
    
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    }
  }
})
