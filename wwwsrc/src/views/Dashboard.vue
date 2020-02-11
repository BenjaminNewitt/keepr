<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-4">
        <h1>DASHBOARD</h1>
        <p>My Keeps</p>
      </div>
      <div class="col-12 align-col">
        <div class="row">
          <keep
            class="col-3"
            v-for="userKeep in userKeeps"
            :key="userKeep.Id"
            :keepData="userKeep"
          ></keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "dashboard",
  components: {
    Keep
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  }
};
</script>

<style scoped>
.align-col {
  text-align: -webkit-center;
}
</style>
