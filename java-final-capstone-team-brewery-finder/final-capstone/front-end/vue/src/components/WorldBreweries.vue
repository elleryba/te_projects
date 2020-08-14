<template>
  <div class="brewery-list">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h3>World Breweries</h3>
    <div class="loading" v-if="isLoading">
        <img src="/public/loadingbeer.gif" />
      </div>
    <p>Click a brewery to view details</p>
    <ul>
      <li
        v-for="brewery in displayedPosts"
        v-bind:key="brewery.name"
        v-on:click="showDetails = !showDetails"
      >
        {{ brewery.name }}
        <div class="brewery-details" v-show="showDetails">
          <p>Brewery Type: {{ brewery.brewery_type }}</p>
          <p>Street: {{ brewery.street }}</p>
          <p>City: {{ brewery.city }}</p>
          <p>State: {{ brewery.state }}</p>
          <p>Postal Code: {{ brewery.postal_code }}</p>
          <p>Country: {{ brewery.country }}</p>
          <p>Longitude: {{ brewery.longitude }}</p>
          <p>Latitude: {{ brewery.latitude }}</p>
          <p>Phone: {{ brewery.phone }}</p>
          <p>Website: <router-link :to= brewery.website_url >{{ brewery.website_url }}</router-link></p>
          <p>Last Updated: {{ brewery.updated_at }}</p>
        </div>
      </li>
    </ul>
    <nav>
      <ul>
        <li class="page-item">
          <button type="button" class="page-link" v-if="page != 1" @click="page--">Previous</button>
        </li>
        <li class="page-item">
          <button
            type="button"
            class="page-link"
            v-for="pageNumber in pages.slice(page-1, page+5)"
            :key="pageNumber.index"
            @click="page = pageNumber"
          >{{pageNumber}}</button>
        </li>
        <li class="page-item">
          <button type="button" @click="page++" v-if="page < pages.length" class="page-link">Next</button>
        </li>
      </ul>
    </nav>
  </div>
</template>



<script>
import worldBreweryService from "../services/WorldBreweryService";

export default {
  name: "brewery-list",
  //props: ,
  data() {
    return {
      breweries: [],
      page: 1,
      perPage: 20,
      pages: [],
      showDetails: false,
      showPagination: true,
      isLoading: true,
    }; //end of return
  }, // end of data

  created() {
    this.getWorldBreweries();
    this.isLoading = false;
  },

  methods: {
    getWorldBreweries() {
      worldBreweryService.getListOfWorldBreweries().then((response) => {
        this.$store.commit("SET_BREWS", response.data);
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
    },
    setPages() {
      let numberOfPages = Math.ceil(this.breweries.length / this.perPage);
      for (let index = 1; index <= numberOfPages; index++) {
        this.pages.push(index);
      }
    },
    paginate(breweries) {
      let page = this.page;
      let perPage = this.perPage;
      let from = page * perPage - perPage;
      let to = page * perPage;
      return breweries.slice(from, to);
    },
  }, //end of methods
  computed: {
    displayedPosts() {
      return this.paginate(this.$store.state.breweries);
    },
  },
  watch: {
    posts() {
      this.setPages();
    },
  },
  filters: {
    trimWords(value) {
      return value.split(" ").splice(0, 20).join(" ") + "...";
    },
  },
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
a:hover {
  color: rgb(255, 255, 255);
}
a:visited {
  color: rgb(162, 58, 247);
}
nav {
  display: flex;
  justify-content: flex-end;
  flex-direction: column;
}
nav ul {
  display: flex;
  justify-content: left;
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
.brewery-details {
  font-size: 12px;
}
p {
  font-size: 14px;
}
ul li {
  margin: 7px;
}
button.page-link {
  display: flex;
  flex-direction: row;
  justify-content: left;
}
button.page-link {
  font-size: 20px;
  color: #29b3ed;
  font-weight: 500;
}
.offset {
  width: 500px !important;
  margin: 20px auto;
}
</style>