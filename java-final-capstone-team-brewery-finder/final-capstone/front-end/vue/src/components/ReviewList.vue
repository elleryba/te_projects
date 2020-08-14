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
    <!--<li><router-link :to="{ name: 'beerList', params: {name: this.$route.params.name}}">Beer List</router-link></li>-->
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
nav li {
  list-style: none;
  background-color: rgb(0, 0, 0);
  line-height: 20px;
  width: 10%;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  margin: 10px;
  color: white;
}
ul li{
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
  border-radius: 5px;
  width: 40%;
}
</style>