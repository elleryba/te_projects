<template>
  <div class="create-beer">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">

    <form v-on:submit.prevent="createBeer">
      <!--start of form elements -->
      <div class="form-element">
        <label for="beerName">Beer Name:</label>
        <input id="beerName" type="text" v-model="beerDto.aBeer.name" />
      </div>
      <div class="form-element">
        <label for="image">Image:</label>
        <input id="image" type="text" v-model="beerDto.aBeer.image" />
      </div>
      <div class="form-element">
        <label for="description">Description:</label>
        <input id="description" type="text" v-model="beerDto.aBeer.description" />
      </div>
      <div class="form-element">
        <label for="abv">ABV:</label>
        <input id="abv" type="text" v-model="beerDto.aBeer.abv" />
      </div>
      <div class="form-element">
        <label for="type">Type:</label>
        <input id="type" type="text" v-model="beerDto.aBeer.type" />
      </div>
      <div class="form-element">
        <label for="breweryName">Brewery Name:</label>
        <input id="breweryName" type="text" v-model="beerDto.breweryName" />
      </div>

      <!--end of form elements -->

      <button class="navbtn" v-on:submit.prevent="createBeer">Submit</button>

      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
    </form>
  </div>
</template>

<script>
import beerService from "../services/BeerService";
export default {
  name: "create-beer",
  data() {
    return {
      beerDto: {
        breweryName: "",
        aBeer: {
          //beerid: "",
          name: "",
          image: "",
          description: "",
          abv: "",
          type: "",
        },
      },
    }; // end of return
  }, // end of data
  methods: {
    createBeer() {
      beerService.addBeer(this.beerDto).then((response) => {
        this.$store.commit("ADD_BEER", response.data);
        this.beerDto = response.data;
      });
      this.$router.push({ name: "home" });
    },
    resetForm() {
      this.beerDto = {};
      this.$router.push({ name: "home" });
    }
  }
};
</script>

<style scoped>
.form-element{
  font-family: 'Open Sans', sans-serif;
    width: 300px;
  clear: both;
}
.form-element input{
    width: 100%;
  clear: both;
}
.navbtn {
  background-color:black;
  line-height: 20px;
  width: 10%;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  margin: 10px;
  color: white;
}
</style>