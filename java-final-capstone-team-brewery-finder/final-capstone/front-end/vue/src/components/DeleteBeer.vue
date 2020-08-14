<template>
  <div class="delete-beer">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"/>

    <form v-on:submit.prevent="deleteBeer">
      <div class="form-element">
        <label for="beerName">Beer Name:</label>
        <input id="beerName" type="text" v-model="beerDto.aBeer.name" />
      </div>
      <div class="form-element">
        <label for="breweryName">Brewery Name:</label>
        <input id="breweryName" type="text" v-model="beerDto.breweryName" />
      </div>
      <button class="navbtn" v-on:submit.prevent="deleteBeer">Submit</button>
      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
    </form>
  </div>
</template>
<script>
import beerService from "../services/BeerService";
export default {
  name: "delete-beer",
  data() {
    return {
      beerDto: {
        breweryName: "",
        aBeer: {
          //beerid: "",
          name: "",
        //  image: "",
        //  description: "",
        //  abv: "",
        //  type: "",
        },
      },
    }; // end of return
  }, // end of data
  methods: {
    deleteBeer() {
      beerService.deleteBeer(this.beerDto).then((response) => {
        this.$store.commit("DELETE_BEER", response.data);
        this.beerDto = response.data;
      });
      this.$router.push({ name: "home" });
    },
    resetForm() {
      this.beerDto = {};
      this.$router.push({ name: "home" });
    },
  },
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