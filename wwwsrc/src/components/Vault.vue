<template>
  <div class="vault col-3">
    <div id="vault-hover" @click.prevent="setActiveVault" class="card mb-5" style="width: 20vw;">
      <div class="card-body">
        <h4 class="card-text">{{ vaultData.name }}</h4>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"],
  methods: {
    setActiveVault() {
      // NOTE reroutes user to activeVault/VaultDetails
      this.$store.dispatch("getVaultById", this.vaultData.id);
    }
  }
};
</script>

<style>
#vault-hover {
  cursor: pointer;
}
</style>