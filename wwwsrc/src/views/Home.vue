<template>
  <div id="home" class="container-fluid">
    <div class="row">
      <div class="col-12 align-col top-of-view">
        <div class="row">
          <public-keep
            v-for="publicKeep in publicKeeps"
            :key="publicKeep.Id"
            :keepData="publicKeep"
          ></public-keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PublicKeep from "@/components/PublicKeep.vue";
export default {
  name: "home",
  components: {
    PublicKeep
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style scoped>
.align-col {
  text-align: -webkit-center;
}

.top-of-view {
  margin-top: 8%;
}

@media only screen and (max-width: 481px) {
  .top-of-view {
    margin-top: 20%;
  }
}
</style>
