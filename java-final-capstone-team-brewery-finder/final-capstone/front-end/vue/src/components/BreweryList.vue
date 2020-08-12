<template>

  <div class="brewery-list" id="main-grid">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
      <h3 id="headline">Breweries</h3>
    <p id="tagline">Click a brewery to view details</p>
     <ul id="body">
      <li
        v-for="brewery in this.$store.state.breweries"
        v-bind:key="brewery.breweryName" 
        v-on:click="showDetails = !showDetails"
      >{{ brewery.name }}
        <div class="brewery-details" v-show="showDetails">
            <p>Description: {{ brewery.history }}</p>
            <p>Opens at: {{ brewery.openFrom }}</p>
            <p>Closes at: {{ brewery.openTo }}</p>
            <p>Days open: {{ brewery.daysOpen }}</p>
            <p>Address: {{ brewery.address }}</p>
            <div class="viewbeers">
            <router-link :to="{ name: 'beerList', params: {name: brewery.name}}">View Beers</router-link>
            <li><router-link :to="{ name: 'updateBrewery', params: {id: brewery.id}}">Update Brewery</router-link></li>
            </div>
        </div>
        </li>
  </ul>
  <div>
  <nav>
  <ul>
    <li><router-link :to="{ name: 'add'}">Add Brewery</router-link></li>
    
    <li><router-link :to="{ name: 'addbeer'}">Add New Beer</router-link></li>
    <li><router-link :to="{ name: 'deletebeer'}">Delete A Beer</router-link></li>
    <li><router-link :to="{ name: 'worldbreweries'}">View World Breweries</router-link></li>
  </ul>
  </nav>
  </div>
  </div>
</template>



<script>
import breweryService from "../services/BreweryService";

export default {
  name: "brewery-list",
  //props: ,
  data() {
    return {
      breweries: [],
      
      showDetails: false
    }; //end of return
  }, // end of data


  created() {
    this.getBreweries();
  },


  methods: {
    getBreweries() {
      breweryService.getListOfBreweries().then((response) => {
        this.$store.commit('SET_BREWS', response.data);
      });
    },
  }, //end of methods
  //methods: {
  // addBrewery(){},// added cuz i assume well need unless we want to make a seperate component

  //}
}; // end of export default
</script>

<style scoped>

li {
  list-style: none;
}
nav ul li {
    list-style: none;
    background-color: rgb(78, 171, 246);
    line-height: 20px;
    width: 10%;
    border-radius: 5px;
    text-transform: uppercase;
    text-decoration: none;
    text-align: center;
    margin: 10px;
}
a {
  text-decoration: none;
}
a:hover{
  color: rgb(255, 255, 255);
}
a:visited{
  color:rgb(162, 58, 247);
}
  nav {
    display:flex;
    justify-content: flex-end;
    flex-direction: column;
  }
  nav ul {
    display:flex;
    justify-content: left;
    margin: 0px;
    padding: 0px;
  }
  .brewery-list{
    font-family: 'Open Sans', sans-serif;
  }
  h3{
    text-decoration: underline;
  }
  .viewbeers{
    list-style: none;
    background-color: rgb(78, 171, 246);
    line-height: 20px;
    width: 10%;
    border-radius: 5px;
    text-transform: uppercase;
    text-decoration: none;
    text-align: center;
    margin: 10px;
  }
  .brewery-details{
    font-size: 12px;
  }
  p{
    font-size: 14px;
  }
  ul li{
    margin: 7px;
  }
  #main-grid {
    display: grid;
    grid-gap: 20px 50px;
    grid-template-columns: 1fr;
    grid-template-areas:
            "headline"
            "tagline"
            "body";
    align-items: center;
}
#headline{
  grid-area: headline;
  
}
h3#headline {
    font-size: 32px;
    margin-top: 0.15em;
    margin-bottom: 0.15em;
    color: #088fe9;
    border-bottom: solid 1px black;
}
#tagline{
  grid-area: tagline;
  
}
#body{
  grid-area: body;
  
}
</style>