<template>
  <div id="vault-details" class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h2>{{ activeVault.name }}</h2>
        <p>{{ activeVault.description }}</p>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <keep
            class="col-3 align-col"
            v-for="vaultKeep in vaultKeeps"
            :key="vaultKeep.Id"
            :keepData="vaultKeep"
          ></keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "vaultDetails",
  components: {
    Keep
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
</style>