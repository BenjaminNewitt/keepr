<template>
  <div id="keep-details" class="container-fluid">
    <div class="row">
      <div class="col-12 mt-5">
        <div class="row">
          <div class="col-6 text-center">
            <img :src="activeKeep.img" class="rounded" />
            <p>
              <i class="far fa-eye"></i>
              :
              {{ activeKeep.views }} |
              <i class="fas fa-share-square"></i>
              :
              {{ activeKeep.shares }}
            </p>
          </div>
          <div class="col-6">
            <h2>{{ activeKeep.name }}</h2>
            <p>{{activeKeep.description }}</p>
          </div>
          <div class="col-12">
            <h4>More Keeps</h4>
            <div class="row">
              <keep
                class="col-3 align-col"
                v-for="publicKeep in publicKeeps"
                :key="publicKeep.Id"
                :keepData="publicKeep"
              ></keep>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "keepDetails",
  components: {
    Keep
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style scoped>
.align-col {
  text-align: -webkit-center;
}
</style>