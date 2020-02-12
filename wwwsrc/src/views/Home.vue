<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-4">
        <h1>KEEPR</h1>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <keep
            class="col-3"
            v-for="publicKeep in publicKeeps"
            :key="publicKeep.Id"
            :keepData="publicKeep"
          ></keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "home",
  components: {
    Keep
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getVaults");
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
</style>
