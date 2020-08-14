<template>
  <div>
      <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
      <h1>Brewery Finder</h1>
      <div class="loading" v-if="isLoading">
        <img src="/public/loadingbeer.gif" />
      </div>
      <div class="breweries">
          <li v-for="brewery in this.$store.state.breweries" v-bind:key="brewery.breweryID">
              {{ brewery.name }}
              </li>
      </div>
  </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name: 'home',
    data(){
        return{
            breweries: [],
            isLoading: true
        }//end of return
    },//end of data()
created(){
    this.getBreweries();
    this.isLoading = false;
},//end of created()
methods: {
    getBreweries(){
    BreweryService.getListOfBreweries()
        .then(response => {
            this.$store.commit('SET_BREWS', response.data);
            this.isLoading = false;
        })
        .catch(error => {
          if (error.response) {
            this.errorMsg =
              "Error retrieving breweries. Response received was '" +
              error.response.statusText +
              "'.";
          } else if (error.request) {
            this.errorMsg =
              "Error retrieving breweries. Server could not be reached.";
          } else {
            this.errorMsg =
              "Error retrieving breweries. Request could not be created.";
          }
          this.isLoading = false;
        });
    }
}//end of methods
}
</script>

<style>
h1{
    font-family: 'Shadows Into Light', cursive;
}
h3{
    font-family: 'Shadows Into Light', cursive;
}
</style>