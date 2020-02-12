<template>
  <div id="vault-details" class="container-fluid">
    <div class="row">
      <div class="col-12">{{ activeVault }}</div>
      <div class="col-12">{{ vaultKeeps }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vaultDetails",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.activeVault.id);
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  }
};
</script>

<style>
</style>