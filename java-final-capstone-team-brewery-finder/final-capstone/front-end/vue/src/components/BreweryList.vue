<template>
  <div class="brewery-list" id="main-grid">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h3 id="headline">Breweries</h3>
   <div class="loading" v-if="isLoading">
      <img src="/public/loadingbeer.gif" />
    </div>
    <p id="tagline">Click a brewery to view details</p>
    <ul id="body">
      <li
        class="list-o-breweries"
        v-for="brewery in this.$store.state.breweries"
        v-bind:key="brewery.breweryName"
        v-on:click="showDetails = !showDetails"
      >
        {{ brewery.name }}
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
    <div>
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
            <router-link :to="{ name: 'worldbreweries'}">View World Breweries</router-link>
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
  display: flex;
  justify-content: center;
  list-style: none;
  background-color: rgb(0, 0, 0);
  line-height: 20px;
  width: 10%;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  margin: 10px;
  color: white;
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
}
a {
  text-decoration: none;
}
a:hover {
  color: rgb(238, 75, 161);
}
a:visited {
  color: white;
}
nav {
  display: flex;
  justify-content: center;
  flex-direction: column;
}
nav ul {
  display: flex;
  margin: 0px;
  padding: 0px;
}
.brewery-list {
  font-family: "Open Sans", sans-serif;
}
h3 {
  text-decoration: underline;
}
.viewbeers {
  display: flex;
  flex-direction: column;
  list-style: none;
  background-color: black;
  line-height: 20px;
  width: 40%;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  justify-content: center;
  margin: 10px;
  color: white;
}
.brewery-details {
  font-size: 12px;
}
p {
  font-size: 14px;
}
ul li {
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
#headline {
  grid-area: headline;
}
h3#headline {
  font-size: 32px;
  margin-top: 0.15em;
  margin-bottom: 0.15em;
  color: black;
  border-bottom: solid 1px black;
}
#tagline {
  grid-area: tagline;
}
#body {
  grid-area: body;
}
.list-o-breweries {
  color: #f7fafc;
  border-radius: 10px;
  padding: 40px;
  flex: 1;
  margin: 10px;
  text-align: center;
  cursor: crosshair;
  width: 30%;
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
}
</style>