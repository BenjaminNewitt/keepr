<template>
  <div id="vault-details" class="container-fluid">
    <div class="row">
      <div class="col-12 top-of-view">
        <h2>{{ activeVault.name }}</h2>
        <p>{{ activeVault.description }}</p>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <vaultKeep
            v-for="vaultKeep in vaultKeeps"
            :key="vaultKeep.Id"
            :keepData="vaultKeep"
            :vaultData="activeVault"
          ></vaultKeep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import VaultKeep from "@/components/VaultKeep.vue";
export default {
  name: "vaultDetails",
  components: {
    VaultKeep
  },
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
.top-of-view {
  margin-top: 8%;
}

@media only screen and (max-width: 481px) {
  .top-of-view {
    margin-top: 20%;
  }
}
</style>