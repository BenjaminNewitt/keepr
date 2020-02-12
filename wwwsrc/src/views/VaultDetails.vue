<template>
  <div id="vault-details" class="container-fluid">
    <div class="row">
      <div class="col-12">{{ activeVault }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vaultDetails",
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    }
  }
};
</script>

<style>
</style>