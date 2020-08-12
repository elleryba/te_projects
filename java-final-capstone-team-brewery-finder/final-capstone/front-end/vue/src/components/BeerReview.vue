<template>
  <div class="beer-review">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />

    <form v-on:submit.prevent="reviewBeer">
      <!--start of form elements -->
      <div class="form-element">
        <label for="rating">Rating:</label>
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
        <textarea id="review" v-model="reviewDto.aReview.review"></textarea>
      </div>
      <div class="form-element">
        <label for="review">Beer Name</label>
        <textarea id="review" v-model="reviewDto.beerName"></textarea>
      </div>
      <!--end of form elements -->

      <button class="navbtn" v-on:submit.prevent="reviewBeer">Submit</button>

      <button class="navbtn" v-on:click.prevent="resetForm" type="cancel">Cancel</button>
    </form>
  </div>
</template>

<script>
import reviewService from "../services/ReviewService";
export default {
  name: "beer-review",
  data() {
    return {
      reviewDto: {
        beerName: "",
        aReview: {
          rating: 0,
          review: "",
        },
      },
    };
  },
  methods: {
    reviewBeer() {
      reviewService.addReview(this.reviewDto).then((response) => {
        this.$store.commit("ADD_REVIEW", response.data);
        this.reviewDto = response.data;
      });
      this.$router.push({ name: "home" });
    },
    resetForm() {
      this.aReview = {};
      this.$router.push({ name: "home" });
    },
  },
};
</script>

<style scoped>
</style>