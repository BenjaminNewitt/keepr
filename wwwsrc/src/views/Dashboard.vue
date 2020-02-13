<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-4">
        <newKeep></newKeep>
        <p>My Keeps</p>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <userKeep v-for="userKeep in userKeeps" :key="userKeep.id" :keepData="userKeep"></userKeep>
        </div>
      </div>
      <div class="col-4">
        <newVault></newVault>
        <p>My Vaults</p>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <vault v-for="vault in vaults" :key="vault.id" :vaultData="vault"></vault>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserKeep from "@/components/UserKeep.vue";
import NewKeep from "@/components/NewKeep.vue";
import Vault from "@/components/Vault.vue";
import NewVault from "@/components/NewVault.vue";
export default {
  name: "dashboard",
  components: {
    UserKeep,
    NewKeep,
    Vault,
    NewVault
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  }
};
</script>

<style scoped>
.align-col {
  text-align: -webkit-center;
}
</style>
