<template>
  <div class="dashboard row">
    <div class="col-12">
      <h1>DASHBOARD</h1>
      public {{ publicKeeps }} user {{ userKeeps}}
    </div>
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
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  }
};
</script>

<style></style>
