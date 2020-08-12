<template> 
    <div class="delete-brewery">
        </div>
</template>
<script>
import breweryService from "../services/BreweryService";

export default {
    name: "delete-brewery",
    
    methods: {
    deleteBrewery(breweryId){
        breweryService.deleteBrewery(breweryId)
        //.then(response =>{}) // do i need to call a mutation from the store 
    }
    }
}
</script>
<style scoped>

</style>