<template>
  <div class="home">
    <h1>KEEPR</h1>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {},
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
