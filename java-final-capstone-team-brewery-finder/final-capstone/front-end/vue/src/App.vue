<template>
  

  <div id="app" >
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <div id="nav">
      <nav>
        <ul>
        <li><router-link  v-bind:to="{ name: 'home' }">Home</router-link></li>
        <li><router-link  v-bind:to="{ name: 'logout' }" >Logout</router-link></li>
        </ul>
      </nav>
    </div>
    <router-view />
  </div>
</template>

<style scoped>

li {
  text-decoration: none;
}

nav ul li {
    list-style: none;
    background-color: rgb(0, 0, 0);
    line-height: 30px;
    width: 10%;
    border-radius: 5px;
    text-transform: uppercase;
    text-decoration: none;
    text-align: center;
    margin: 10px;
}
a {
  text-decoration: none;
}
a:hover{
  color: rgb(255, 255, 255);
}
a:visited{
  color:rgb(255, 255, 255);
}
  nav {
    display:flex;
    justify-content: flex-end;
    flex-direction: column;
    font-family: 'Open Sans', sans-serif;
  }
  nav ul {
    display:flex;
    justify-content: left;
    margin: 0px;
    padding: 0px;
  }
#app{
  background: url("../public/foamgif.gif");
  background-repeat: no-repeat;
  background-size:cover;
  background-position: center;
  background-attachment: fixed;
  
}




</style>
