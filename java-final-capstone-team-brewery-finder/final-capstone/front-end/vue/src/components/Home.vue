<template>
  <div>
      <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
      <h1>Brewery Finder</h1>
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
            breweries: []
        }//end of return
    },//end of data()
created(){
    this.getBreweries();
},//end of created()
methods: {
    getBreweries(){
    BreweryService.getListOfBreweries()
        .then(response => {
            this.$store.commit('SET_BREWS', response.data)
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