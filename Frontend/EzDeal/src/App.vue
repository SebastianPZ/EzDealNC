<template>
  <v-app id="app">
    <v-content id="fondo">
      <v-toolbar color="blue">
        <div id="picture1"></div>
      </v-toolbar>
      <router-view />
    </v-content>
  </v-app>
</template>

<style>
#picture1 {
   width: 15%;
   height: 80%;
   background-image: url('Resources/logo.png');
   background-size: 100% 100%;
   display: block;
   margin: auto;
  
}
#fondo{
  background-image: url("Resources/fondo.png");
  background-size: 100% 100%;
}
</style>



<script>
export default {
  name: "App",
  data() {
    return {

      drawer: true
    };
  }
};
</script>
