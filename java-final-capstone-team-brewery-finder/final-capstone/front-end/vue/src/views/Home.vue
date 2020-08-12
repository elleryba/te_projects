<template>
  <div class="home">
    <link
      href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap"
      rel="stylesheet"/>
    <h1>Brewery Finder</h1>
    <brewery-list />
  </div>
</template>

<script>
import BreweryList from "@/components/BreweryList.vue";

export default {
  name: "home",
  components: {
    BreweryList,
  },
};
</script>

<style scoped>
h1 {
  font-family: "Shadows Into Light", cursive;
}
p {
  font-family: "Open Sans", sans-serif;
  font-size: 12px;
}


</style>