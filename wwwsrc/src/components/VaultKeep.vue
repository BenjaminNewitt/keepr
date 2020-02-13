<template>
  <div class="vaultKeep col-2 align-col">
    <div class="m-2" style="width: 100%;">
      <div id="keep-hover" @click.prevent="setActiveKeep">
        <img :src="keepData.img" class="card-img-top rounded" alt="..." />
      </div>
      <i
        v-if="$auth.isAuthenticated"
        class="vault-hover fas fa-times text-left text-danger"
        @click.prevent="RemoveKeepFromVault()"
      ></i>
      <div v-if="$auth.isAuthenticated" class="dropdown text-right">
        <button class="btn btn-outline-dark border-0 dropdown-toggle" data-toggle="dropdown">
          <i class="fas fa-plus text-right"></i>
        </button>
        <!-- list of vaults here, only visible if user is authenticated -->
        <div class="dropdown-menu">
          <a
            class="dropdown-item"
            v-for="vault in vaults"
            :key="vault.id"
            @click.prevent="addVaultKeep(vault.id)"
          >{{ vault.name }}</a>
        </div>
      </div>
      <div class="card-body">
        <h4 class="card-text">{{ keepData.name }}</h4>
        <p class="card-text border-top pt-1"">
          <i class="far fa-eye"></i>
          :
          {{ keepData.views }} |
          <i class="fas fa-key"></i>
          : {{ keepData.keeps}} |
          <i class="fas fa-share-square"></i>
          :
          {{ keepData.shares }}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "VaultKeep",
  props: ["keepData", "vaultData"],
  mounted() {},
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    setActiveKeep() {
      // NOTE reroutes user to activeKeep/KeepDetails
      this.$store.dispatch("getKeepById", this.keepData.id);
    },
    addVaultKeep(vaultId) {
      this.$store.dispatch("addVaultKeep", {
        keepId: this.keepData.id
      });
    },
    RemoveKeepFromVault() {
      this.$store.dispatch("RemoveKeepFromVault", {
        keepId: this.keepData.id,
        vaultId: this.vaultData.id
      });
    }
  }
};
</script>

<style>
#keep-hover {
  cursor: pointer;
}
</style>
