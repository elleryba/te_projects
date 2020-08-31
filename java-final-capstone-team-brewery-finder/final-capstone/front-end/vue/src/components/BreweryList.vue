<template>
  <div class="brewery-list" id="main-grid">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h1 class="headline">Brewery List</h1>
    <ul id="body">
      <li
        class="list-o-breweries"
        v-for="brewery in this.$store.state.breweries"
        v-bind:key="brewery.breweryName"
        v-on:click="showDetails = !showDetails"
      >
      <div class="brewname">
        {{ brewery.name }}
        </div>
        <div class="brewery-details" v-show="showDetails">
          <p>Description: {{ brewery.history }}</p>
          <p>Opens at: {{ brewery.openFrom }}</p>
          <p>Closes at: {{ brewery.openTo }}</p>
          <p>Days open: {{ brewery.daysOpen }}</p>
          <p>Address: {{ brewery.address }}</p>
          <div class="viewbeers">
            <router-link :to="{ name: 'beerList', params: {name: brewery.name}}">View Beers</router-link>
            <li>
              <router-link :to="{ name: 'updateBrewery', params: {id: brewery.id}}">Update Brewery</router-link>
            </li>
          </div>
        </div>
      </li>
    </ul>
    <div id="nav">
      <nav>
        <ul>
          <li>
            <router-link :to="{ name: 'add'}">Add Brewery</router-link>
          </li>

          <li>
            <router-link :to="{ name: 'addbeer'}">Add New Beer</router-link>
          </li>
          <li>
            <router-link :to="{ name: 'deletebeer'}">Delete A Beer</router-link>
          </li>
          <li>
            <router-link :to="{ name: 'worldbreweries'}">World Breweries</router-link>
          </li>
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
      isLoading: true,
      showDetails: false,
    }; //end of return
  }, // end of data

  created() {
    this.getBreweries();
    this.isLoading = false;
  },

  methods: {
    getBreweries() {
      breweryService
        .getListOfBreweries()
        .then((response) => {
          this.$store.commit("SET_BREWS", response.data);
          this.isLoading = false;
        })
        .catch((error) => {
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
  background-color: rgb(74, 178, 226);
  line-height: 30px;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  align-items: center;
  margin: 10px;
}
a {
  text-decoration: none;
  color: white;
}
a:hover {
  color: white;
  text-decoration: underline;
}
a:visited {
  color: white;
}
nav {
  display: flex;
  justify-content: space-between;
  flex-direction: column;
  font-family: "Open Sans", sans-serif;
  background-color: rgb(74, 178, 226);
}
nav ul {
  display: flex;
  justify-content: left;
  align-items: center;
  margin: 0px;
  padding: 0px;
}
.brewery-list {
  font-family: "Open Sans", sans-serif;
  align-items: center;
}
.viewbeers {
  display: flex;
  list-style: none;
  background-color: rgb(74, 178, 226);
  line-height: 20px;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  align-items: center;
  justify-content: space-around;
  margin: auto;
  color: white;
  max-width: 30%;
  cursor: pointer;
}
.brewery-details {
  font-size: 13px;
  color: black;
  align-items: center;
  text-align: center;
  background-color: white;
  cursor: default;
}
p {
  font-size: 14px;
}
ul li {
  margin: 7px;
  align-items: center;
  text-align: center;
}
#main-grid {
  display: grid;
  grid-gap: 20px 50px;
  grid-template-columns: 1fr, 1fr, 1fr, 1fr;
  grid-template-areas:
  ". headline headline ."
    ". body body ."
    ". . . ."
    "nav nav nav nav";
  align-items: center;
}
#body {
  grid-area: body;
  align-items: center;
}
#nav{
  grid-area: nav;
}
.list-o-breweries {
  color: #f7fafc;
  border-radius: 10px;
  padding: 40px;
  flex: 1;
  margin: 10px;
  text-align: center;
  align-items: center;
  cursor: pointer;
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
  background-color: white;
}
ul{
  align-items: center;
}
.brewname{
  color: black;
  font-weight: bold;
}
h1.headline{
  grid-area: headline;
  align-items: center;
  text-align: center;
}
</style>