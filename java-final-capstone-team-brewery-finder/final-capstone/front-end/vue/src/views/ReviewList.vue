<template>
  <div>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <h1>Review List</h1>
    <review-list />
  </div>
</template>

<script>
import ReviewList from "@/components/ReviewList.vue";

export default {
  components: {
    ReviewList
  },
};
</script>

<style>
h1{
  font-family: 'Shadows Into Light', cursive;
}
</style>
