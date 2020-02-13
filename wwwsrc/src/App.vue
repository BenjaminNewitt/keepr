<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    await this.$auth.getUserData();
    this.$store.dispatch("setBearer", this.$auth.bearer);
  },
  components: {
    Navbar
  }
};
</script>

<style>
#app {
  background-color: #ccedd2;
  height: 100%;
}

h1,
h2,
h3,
h4 {
  font-family: "Open Sans", sans-serif;
}
</style>
