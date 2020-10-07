<template>
  <div class="update-brewery">
    <h1 class="headline">Update Brewery</h1>
    <div class="body">
      <form v-on:submit.prevent="updateBrewery">
        <!--start of form elements -->
        <div class="form-element">
          <label for="breweryName">Brewery Name:</label>
          <input id="breweryName" type="text" v-model="name" />
        </div>
        <div class="form-element">
          <label for="address">Address:</label>
          <input id="address" type="text" v-model="address" />
        </div>
        <div class="form-element">
          <label for="openFrom">Open From:</label>
          <input id="openFrom" type="text" v-model="openFrom" />
        </div>
        <div class="form-element">
          <label for="openTo">Open To:</label>
          <input id="openTo" type="text" v-model="openTo" />
        </div>
        <div class="form-element">
          <label for="daysOpen">Days Open:</label>
          <input id="daysOpen" type="text" v-model="daysOpen" />
        </div>
        <div class="form-element">
          <label for="history">Description:</label>
          <input id="history" type="text" v-model="history" />
        </div>
      </form>
    </div>
    <!--end of form elements -->
    <div class="nav">
      <button class="navbtn" type="submit" v-on:click="updateBrewery">Submit</button>
      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
    </div>
  </div>
</template>

<script>
import breweryService from "../services/BreweryService";
export default {
  name: "update-brewery",
  props: ["id"],
  data() {
    return {
      activeBrewery:{
      id: "",
      name: "",
      history: "",
      openFrom: "",
      openTo: "",
      daysOpen: "",
      address: "",
      },
      name: this.$route.params.name,
      history: "",
      openFrom: "",
      openTo: "",
      daysOpen: "",
      address: "",
    }; // end of return
  }, // end of data
  methods: {
    updateBrewery() {
      const brewery = {
        id: this.$route.params.id,
        name: this.name,
        history: this.history,
        openFrom: this.openFrom,
        openTo: this.openTo,
        daysOpen: this.daysOpen,
        address: this.address,
      };
      breweryService
        .updateBrewery(this.$route.params.id, brewery)
        .then((response) => {
          this.$store.commit("UPDATE_BREW", brewery);

          this.name = response.data.name;
          this.history = response.data.history;
          this.openFrom = response.data.openFrom;
          this.openTo = response.data.openTo;
          this.daysOpen = response.data.daysOpen;
          this.address = response.data.address;

          if (response.status == 200) {
            this.$router.push({ name: "home" });
          }
        });
    },
    getBrewery(){
      breweryService.getBreweryByName(this.$route.params.name)
      .then((response) => {
        this.$store.commit("SET_ACTIVE_BREWERY", response.data);
        this.activeBrewery.id = response.data.id;
        this.activeBrewery.name = response.data.name;
        this.activeBrewery.history = response.data.history;
        this.activeBrewery.openFrom = response.data.openFrom;
        this.activeBrewery.openTo = response.data.openTo;
        this.activeBrewery.daysOpen = response.data.daysOpen;
        this.activeBrewery.address = response.data.address;
      })
    },
    resetForm() {
      this.newReview = {}; // reset brewery object to empty
      this.$router.push({ name: "home" }); //return user to homepage
    },
  },
  created() {
    this.getBrewery();
  },
};
</script>
<style scoped>
.form-element {
  font-family: "Open Sans", sans-serif;
  width: 300px;
  clear: both;
}
.form-element input {
  width: 100%;
  clear: both;
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
.update-brewery {
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
