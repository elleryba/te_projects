<template><!--didnt add anything other than a div so it would not have red squiggles-->
   <div class="update-brewery">

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
        <label for="history">History:</label>
        <input id="history" type="text" v-model="history" />
      </div>
       <!--end of form elements -->

       <button class="navbtn" type="submit" v-on:click="updateBrewery">Submit</button>
       
       <!-- <button v-on:submit.prevent="updateBrewery">Submit</button> submit button-->
       <!--button to cancel form that your filling out -->
       <!--not sure about type=cancel - looks goood to me Reva!-->
       <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
       </form>
       </div> 
</template>

<script>
import breweryService from "../services/BreweryService";
export default {
    name:"update-brewery",
    props: ["id"], // not sure why in an example its in an array so for now i also put it in an array 
    data(){
        return {
            // need to talk to back end about what rows there is 

        name: "",
        history: "",
        openFrom: "",
        openTo: "",
        daysOpen: "",
        address: ""

             
        }// end of return 
    },// end of data 
    methods: {
        updateBrewery(){
            const brewery = {id: this.$route.params.id, name: this.name, history: this.history, openFrom: this.openFrom, openTo: this.openTo, daysOpen: this.daysOpen, address: this.address }
            breweryService.updateBrewery(this.$route.params.id, brewery)
            .then(response => {
            this.$store.commit("UPDATE_BREW", brewery); // readding brewery with updated info 
            
            this.name = response.data.name; // 68-73 Why you do dis reset form thang
            this.history = response.data.history;
            this.openFrom = response.data.openFrom;
            this.openTo = response.data.openTo;
            this.daysOpen = response.data.daysOpen;
            this.address = response.data.address;
            

            

            if (response.status == 200) {
            this.$router.push({name: 'home'});
        }

            });
        },
        resetForm() { // i added
      this.newReview = {};                  // reset brewery object to empty
      this.$router.push({name : 'home'}); //return user to homepage 
    }
    }
    /* created() {
        breweryService
      .getBreweryByName(this.name)
      
      } */
    }

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
