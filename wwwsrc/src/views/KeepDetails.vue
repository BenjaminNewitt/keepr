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
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keepDetails",
  mounted() {},
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>

<style>
</style>