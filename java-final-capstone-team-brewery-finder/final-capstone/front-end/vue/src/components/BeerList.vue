<template>
  <div class="beer-list">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h3>Beers</h3>
    <p>Click a beer for details</p>
    <ul>
      <li
        v-for="beer in this.$store.state.beers"
        v-bind:key="beer.name"
        v-on:click="showDetails = !showDetails"
      >
        {{ beer.name }}
        <div class="beer-details" v-show="showDetails">
          <!-- <p>Image: {{ beer.image }}</p> -->
          <p><img :src= beer.image /></p>
          <p>Description: {{ beer.description }}</p>
          <p>ABV: {{ beer.abv }}</p>
          <p>Beer Type: {{ beer.type }}</p>
          <nav>
            <ul>
          <li><router-link :to="{ name: 'reviews', params: {name: beer.name}}">View Reviews</router-link></li>
          </ul>
          </nav>
        </div>
      </li>
    </ul>
    <nav>
      <ul>
      <li><router-link :to="{ name: 'addreview'}">Add Review</router-link></li>
      </ul>
    </nav>
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
    getAllBeers() {
      beerService.getListOfAllBeers().then((response) => {
        this.$store.commit("SET_BEERS", response.data);
      });
    },
  },
};
</script>
<style scoped>
.beer-list {
  font-family: "Open Sans", sans-serif;
}
h3 {
  text-decoration: underline;
}
ul li {
  margin: 7px;
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
a:hover {
  color: rgb(255, 255, 255);
}
a:visited {
  color: rgb(162, 58, 247);
}
p {
  font-size: 14px;
}
.beer-details {
  font-size: 12px;
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
  img{
    max-width: 20%;
    max-height: auto;
  }
</style>