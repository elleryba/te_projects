<template>
  <main>
    <best-seller-list />
    <new-releases-list />
  </main>
</template>

<script>
import BestSellerList from '@/components/BestSellerList';
import NewReleasesList from '@/components/NewReleasesList';

export default {
  components: {
    BestSellerList,
    NewReleasesList
  }
}
</script>

<style>

</style>