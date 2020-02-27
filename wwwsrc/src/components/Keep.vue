<template>
  <div id="keep" class="col-12 col-sm-4 col-md-3 col-lg-2 align-col">
    <div class="card mb-3" style="width: 100%;">
      <div id="keep-hover" @click.prevent="setActiveKeep" class="m-2 mb-0">
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
        <!-- <button type="button" class="btn btn-outline-dark">Share</button> -->
        <div class="row d-flex flex-row-reverse">
          <div class="col-3">
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
  name: "Keep",
  props: ["keepData"],
  mounted() {
    // this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    setActiveKeep() {
      // NOTE reroutes user to activeKeep/KeepDetails
      this.$store.dispatch("getPublicKeepById", this.keepData.id);
    },
    addVaultKeep(vaultId) {
      this.$store.dispatch("addVaultKeep", {
        keepId: this.keepData.id,
        vaultId: vaultId
      });
    }
  }
};
</script>

<style>
#keep-hover hover {
  cursor: pointer;
}
</style>
