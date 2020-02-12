<template>
  <div id="keep-details" class="container-fluid">
    <div class="row">
      <div class="col-12">{{ activeKeep }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keepDetails",
  mounted() {},
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>

<style>
</style>