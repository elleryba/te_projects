<template>
  <div>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <beer-list />
  </div>
</template>

<script>
import BeerList from "@/components/BeerList.vue";

export default {
  components: {
    BeerList
  }
};
</script>

<style scoped>
h1 {
  font-family: "Shadows Into Light", cursive;
  text-align: center;
}
p {
  font-family: "Open Sans", sans-serif;
  font-size: 12px;
}
</style>
