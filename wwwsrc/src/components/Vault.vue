<template>
  <div class="vault col-3">
    <div class="card mb-5" style="width: 20vw;">
      <i class="vault-hover fas fa-times text-right text-danger" @click.prevent="deleteVault"></i>
      <div class="card-body vault-hover" @click.prevent="setActiveVault">
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
    },
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  }
};
</script>

<style>
.vault-hover {
  cursor: pointer;
}
</style>