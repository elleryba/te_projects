<template>
  <div class="create-brewery">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h1 class="headline">Add New Brewery</h1>
    <div class="body">
    <form v-if="showForm === true" v-on:submit.prevent="createBrewery">
      <!--start of form elements -->
      <div class="form-element">
        <label for="breweryName">Brewery Name:</label>
        <input id="breweryName" type="text" v-model="brewery.name" />
      </div>
      <div class="form-element">
        <label for="address">Address:</label>
        <input id="address" type="text" v-model="brewery.address" />
      </div>
      <div class="form-element">
        <label for="openFrom">Open From:</label>
        <input id="openFrom" type="text" v-model="brewery.openFrom" />
      </div>
      <div class="form-element">
        <label for="openTo">Open To:</label>
        <input id="openTo" type="text" v-model="brewery.openTo" />
      </div>
      <div class="form-element">
        <label for="daysOpen">Days Open:</label>
        <input id="daysOpen" type="text" v-model="brewery.daysOpen" />
      </div>
      <div class="form-element">
        <label for="history">History:</label>
        <input id="history" type="text" v-model="brewery.history" />
      </div>
      </form>
    </div>
      <!--end of form elements -->
      <div class="nav">
      <button class="navbtn" v-on:submit.prevent="createBrewery">Submit</button>
      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
      </div>
  </div>
</template>
<script>
import breweryService from "../services/BreweryService";

export default {
  name: "create-brewery",
  data() {
    return {
      showForm: true, // changed to true to check form loads when link is clicked
      brewery: {
        name: "",
        history: "",
        openFrom: "",
        openTo: "",
        daysOpen: "",
        address: "",
      },
    }; // end of return
  }, // end of data
  methods: {
    //addBrewery(){ //this method is added as a tester to see what my code can access and what it is running
    // this.$store.commit("ADD_BREWERY", this.brewery);
    // this.resetForm();
    //},
    createBrewery() {
      breweryService.addBrewery(this.brewery).then((response) => {
        this.$store.commit("ADD_BREWERY", response.data);
        this.brewery = response.data;
      });
      this.$router.push({ name: "home" });
    },
    resetForm() {
      this.showForm = false; // hide the form
      this.newReview = {}; // reset brewery object to empty
      this.$router.push({ name: "home" }); //return user to homepage
    },
  },
};
</script>
<style scoped>
.form-element {
  font-family: "Open Sans", sans-serif;
    width: 300px;
  clear: both;
}
.form-element input{
    width: 100%;
  clear: both;
}
.create-brewery {
  font-family: "Open Sans", sans-serif;
  display: grid;
  grid-gap: 20px 50px;
  grid-template-columns: 1fr, 1fr, 1fr, 1fr;
  grid-template-areas:
    ". headline headline ."
    ". body body ."
    ". nav nav .";
  align-items: center;
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
h1.headline {
  grid-area: headline;
  align-items: center;
  margin: auto;
}
.body {
  grid-area: body;
  align-items: center;
  margin: auto;
}
.nav {
  grid-area: nav;
  align-items: center;
  margin: auto;
}
</style>