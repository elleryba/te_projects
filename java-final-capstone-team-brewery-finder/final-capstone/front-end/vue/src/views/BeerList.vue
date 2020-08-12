<template>
  <div>
      
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <h1>Beer List</h1>
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

<style>
h1{
  font-family: 'Shadows Into Light', cursive;
}
</style>
