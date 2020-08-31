<template>
  <div class="review-list">
    <h1 class="headline">Review List</h1>
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"
    />
    <h3 class="beername">{{this.$route.params.name}}</h3>
    <div class="body">
      <ul>
        <li v-for="review in this.$store.state.reviews" v-bind:key="review.review">
          <b>Review:</b>
          {{ review.review }}
          <br />
          <b>Rating:</b>
          {{review.rating}}
        </li>
      </ul>
    </div>
    <div id="nav">
      <nav>
        <button v-on:click="goBack()">Back</button>
      </nav>
    </div>
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
      prevRoute: null,
    }; // end of return
  },
  created() {
    this.getReviews();
  },
  methods: {
    getReviews() {
      reviewService
        .getListOfReviews(this.$route.params.name)
        .then((response) => {
          this.$store.commit("SET_REVIEWS", response.data);
        });
    },
    goBack() {
      this.$router.go(-1);
    },
    getAvgRating() {},
  },
};
</script>

<style scoped>
a {
  text-decoration: none;
  color: white;
}
a:hover {
  color: white;
  text-decoration: underline;
}
a:visited {
  color: white;
}
.review-list {
  font-family: "Open Sans", sans-serif;
  display: grid;
  grid-gap: 20px 50px;
  grid-template-columns: 1fr, 1fr, 1fr, 1fr;
  grid-template-areas:
    ". headline headline ."
    ". beername beername ."
    ". body body ."
    ". nav nav .";
  align-items: center;
}
.body {
  grid-area: body;
  align-items: center;
  box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  padding: 10px;
  border-radius: 5px;
  width: 40%;
  margin: auto;
  text-align: center;
}
h1.headline {
  grid-area: headline;
  align-items: center;
  text-align: center;
}
h3 {
  text-decoration: underline;
  grid-area: beername;
  align-items: center;
  text-align: center;
}
li {
  list-style: none;
}
#nav {
  grid-area: nav;
  line-height: 30px;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  align-items: center;
  margin: 10px;
  display: flex;
  justify-content: space-between;
  flex-direction: column;
  font-family: "Open Sans", sans-serif;
}
button {
  background-color: rgb(74, 178, 226);
  line-height: 20px;
  border-radius: 5px;
  text-transform: uppercase;
  text-decoration: none;
  text-align: center;
  margin: 10px;
  color: white;
  cursor: pointer;
}
</style>