<template>
  <div class="keep">
    <div class="card mb-3" style="width: 12vw;">
      <div id="keep-hover" @click.prevent="setActiveKeep">
        <img :src="keepData.img" class="card-img-top rounded" alt="..." />
      </div>
      <div v-if="$auth.isAuthenticated" class="dropdown text-right">
        <button class="dropdown-toggle" data-toggle="dropdown">
          <i class="fas fa-plus text-right">
            <!-- list of vaults here, only visible if user is authenticated -->
          </i>
        </button>
        <div class="dropdown-menu">
          <a class="dropdown-item" v-for="vault in vaults" :key="vault.id" href="#">{{ vault.name }}</a>
        </div>
      </div>
      <div class="card-body">
        <p class="card-text">
          <i class="far fa-eye"></i>
          :
          {{ keepData.views }} |
          <i class="fas fa-share-square"></i>
          :
          {{ keepData.shares }}
        </p>
        <h4 class="card-text">{{ keepData.name }}</h4>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    setActiveKeep() {
      // NOTE reroutes user to activeKeep/KeepDetails
      this.$store.dispatch("getKeepById", this.keepData.id);
    }
  }
};
</script>

<style>
#keep-hover {
  cursor: pointer;
}
</style>
