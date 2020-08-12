<template>

  <div class="review-list">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
      <h3>{{this.$route.params.name}}</h3>
     <ul>
      <li
        v-for="review in this.$store.state.reviews"
        v-bind:key="review.review" 
      >Review: {{ review.review }} | Rating: {{review.rating}}
        </li>
  </ul>
  <nav>
  </nav>
  </div>
</template>

<script>
import reviewService from "../services/ReviewService";
export default {
    name: "review-list",
  data() {
    return {
      reviews: [],
      numOfReviews: 0,
      totalRating: 0,
      avgRating: 0,

    }; // end of return
  },
  created() {
      this.getReviews();
  },
  methods: {
      getReviews() {
        reviewService.getListOfReviews(this.$route.params.name)
        .then((response) => {
            this.$store.commit("SET_REVIEWS", response.data)
            
        });

  },
      getAvgRating() {
        
      }
  }
}
</script>

<style scoped>
.review-list{
  font-family: 'Open Sans', sans-serif;
}
h3 {
  text-decoration: underline;
}
li{
  list-style: none;
}
</style>