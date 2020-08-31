<template>
  <div class="beer-review">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h1 class="headline">Add a Review</h1>
    <div class="body">
      <form v-on:submit.prevent="reviewBeer">
        <!--start of form elements -->
        <div class="form-element">
          <label for="review">Beer Name</label>
          <br />
          <textarea id="review" v-model="reviewDto.beerName"></textarea>
        </div>
        <div class="form-element">
          <label for="rating">Rating</label>
          <br />
          <select id="rating" v-model.number="reviewDto.aReview.rating">
            <option value="1">1 Star</option>
            <option value="2">2 Stars</option>
            <option value="3">3 Stars</option>
            <option value="4">4 Stars</option>
            <option value="5">5 Stars</option>
          </select>
        </div>
        <div class="form-element">
          <label for="review">Review</label>
          <br />
          <textarea id="review" v-model="reviewDto.aReview.review"></textarea>
        </div>
      </form>
    </div>
    <!--end of form elements -->
    <div class="nav">
      <button class="navbtn" v-on:submit.prevent="reviewBeer">Submit</button>
      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
    </div>
  </div>
</template>

<script>
import reviewService from "../services/ReviewService";
import beerService from "../services/BeerService";
export default {
  name: "beer-review",
  data() {
    return {
      beers: [],
      reviewDto: {
        beerName: "",
        aReview: {
          rating: 0,
          review: "",
        },
      },
    };
  },
  created() {
    this.getAllBeers();
  },
  methods: {
    reviewBeer() {
      reviewService.addReview(this.reviewDto).then((response) => {
        this.$store.commit("ADD_REVIEW", response.data);
        this.reviewDto = response.data;
      });
      this.$router.push({ name: "home" });
    },
    getAllBeers() {
      beerService.getListOfAllBeers().then((response) => {
        this.$store.commit("SET_BEERS", response.data);
      });
    },
    resetForm() {
      this.aReview = {};
      this.$router.go(-1);
    },
  },
};
</script>

<style scoped>
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
.beer-review {
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