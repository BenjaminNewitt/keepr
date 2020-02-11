<template>
  <div class="home row">
    <div class="col-12">
      <h1>KEEPR</h1>
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
