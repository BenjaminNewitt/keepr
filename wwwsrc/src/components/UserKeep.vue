<template>
  <div id="userKeep" class="col-12 col-sm-4 col-md-3 align-col">
    <div class="card mb-3" style="width: 100%;">
      <div id="user-keep-hover" @click.prevent="setActiveKeep" class="m-2">
        <img :src="keepData.img" class="card-img-top rounded" alt="..." />
      </div>
      <div class="card-body p-1">
        <h5 class="card-text">{{ keepData.name }}</h5>
        <p class="card-text border-top pt-1">
          <i class="far fa-eye"></i>
          :
          {{ keepData.views }} |
          <i class="fas fa-key"></i>
          : {{ keepData.keeps }} |
          <i class="fas fa-share-square"></i>
          :
          {{ keepData.shares }}
        </p>
        <div class="row justify-content-between">
          <div class="col-6 text-left">
            <i
              v-if="$auth.isAuthenticated"
              class="vault-hover fas fa-times text-danger ml-2"
              @click.prevent="deleteUserKeep"
            ></i>
          </div>
          <div class="col-6 text-right">
            <div v-if="$auth.isAuthenticated" class="dropdown d-inline-block">
              <button
                v-if="$auth.isAuthenticated"
                class="btn btn-outline-dark border-0 dropdown-toggle"
                data-toggle="dropdown"
              >
                <i class="fas fa-plus text-right"></i>
              </button>
              <div v-if="$auth.isAuthenticated" class="dropdown-menu">
                <a
                  class="dropdown-item"
                  v-for="vault in vaults"
                  :key="vault.id"
                  @click.prevent="addVaultKeep(vault.id)"
                  >{{ vault.name }}</a
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "UserKeep",
  props: ["keepData"],
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
        keepId: this.keepData.id,
        vaultId: vaultId
      });
    },
    deleteUserKeep() {
      this.$store.dispatch("deleteUserKeep", this.keepData.id);
    }
  }
};
</script>

<style>
#user-keep-hover {
  cursor: pointer;
}
</style>
