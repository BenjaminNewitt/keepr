<template>
  <div id="keep-details" class="container-fluid">
    <div class="row">
      <div class="col-12 top-of-view">
        <div class="row">
          <div class="col-12 col-md-6 text-center">
            <img :src="activeKeep.img" style="width: 100%;" class="rounded" />
            <p>
              <i class="far fa-eye"></i>
              :
              {{ activeKeep.views }} |
              <i class="fas fa-key"></i>
              : {{ activeKeep.keeps }} |
              <i class="fas fa-share-square"></i>
              :
              {{ activeKeep.shares }}
            </p>
          </div>
          <div class="col-10 col-md-6">
            <h2>{{ activeKeep.name }}</h2>
            <p>{{ activeKeep.description }}</p>
          </div>
          <div class="col-12 align-col">
            <h4 class="text-left">More Keeps</h4>
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
    </div>
  </div>
</template>

<script>
import PublicKeep from "@/components/PublicKeep.vue";
export default {
  name: "keepDetails",
  components: {
    PublicKeep
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

.top-of-view {
  margin-top: 8%;
}

@media only screen and (max-width: 481px) {
  .top-of-view {
    margin-top: 20%;
  }
}
</style>
