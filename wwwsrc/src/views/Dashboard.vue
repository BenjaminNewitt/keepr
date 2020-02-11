<template>
  <div class="dashboard">
    <h1>DASHBOARD</h1>
    public {{ publicKeeps }}
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    publicKeeps() {
      return this.$store.state.userKeeps;
    }
  }
};
</script>

<style></style>
