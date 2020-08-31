<template>
  <div class="beer-list" id="main-grid">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h1 class="headline">Beer List</h1>
    <ul id="body">
      <li
        class="allbeers"
        v-for="beer in this.$store.state.beers"
        v-bind:key="beer.name"
        v-on:click="showDetails = !showDetails"
      >
        <div class="beername">{{ beer.name }}</div>
        <div class="beer-details" v-show="showDetails">
          <!-- <p>Image: {{ beer.image }}</p> -->
          <p>
            <img :src="beer.image" />
          </p>
          <p>Description: {{ beer.description }}</p>
          <p>ABV: {{ beer.abv }}</p>
          <p>Beer Type: {{ beer.type }}</p>
          <ul>
            <li>
              <div class="view">
                <router-link :to="{ name: 'reviews', params: {name: beer.name}}">View Reviews</router-link>
              </div>
            </li>
          </ul>
        </div>
      </li>
    </ul>
    <button id="back" v-on:click="goBack()">Back</button>
    <div id="nav">
      <nav>
        <ul>
          <li>
            <router-link :to="{ name: 'addreview'}">Add Review</router-link>
          </li>
        </ul>
      </nav>
    </div>
  </div>
</template>
<script>
import beerService from "../services/BeerService";
export default {
  name: "beer-list",
  //props: ["name"], COMMENTED OUt TO TEST
  data() {
    return {
      beers: [],
      showDetails: false,
    }; // end of return
  }, // end of data
  created() {
    this.getBeers();
    //this.getAllBeers(); COMMENTED OUT, MAY NEED LATER
  }, // end of created
  methods: {
    getBeers() {
      beerService.getListOfBeers(this.$route.params.name).then((response) => {
        this.$store.commit("SET_BEERS", response.data);
      });
    },
    goBack() {
      this.$router.go(-1);
    },
    getAllBeers() {
      beerService.getListOfAllBeers().then((response) => {
        this.$store.commit("SET_BEERS", response.data);
      });
    },
  },
};
</script>
<style scoped>
li {
  list-style: none;
}
.beer-list {
  font-family: "Open Sans", sans-serif;
  align-items: center;
}
ul li {
  margin: auto;
  align-items: center;
  text-align: center;
}
.allbeers {
  margin: auto;
  list-style: none;
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
  border-radius: 5px;
  align-items: center;
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
p {
  font-size: 14px;
}
.beer-details {
  font-size: 13px;
  color: black;
  align-items: center;
  text-align: center;
  background-color: white;
  cursor: default;
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
img {
  max-width: 20%;
  max-height: auto;
}
.beername {
  cursor: pointer;
  text-align: center;
  font-weight: bold;
}
.view {
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
ul {
  align-items: center;
}
#main-grid {
  display: grid;
  grid-gap: 20px 50px;
  grid-template-columns: 1fr, 1fr, 1fr, 1fr;
  grid-template-areas:
    ". headline headline ."
    ". body body ."
    ". back back ."
    "nav nav nav nav";
  align-items: center;
}
#body {
  grid-area: body;
  align-items: center;
}
#nav {
  grid-area: nav;
}
p {
  font-size: 14px;
}
h1.headline {
  grid-area: headline;
  align-items: center;
  text-align: center;
}
button {
  grid-area: back;
  background-color: rgb(74, 178, 226);
  line-height: 20px;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  margin: auto;
  color: white;
  cursor: pointer;
  align-items: center;
}
</style>