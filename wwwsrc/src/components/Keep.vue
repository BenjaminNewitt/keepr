<template>
  <div class="keep">
    <div class="card mb-5" style="width: 20vw;">
      <div id="keep-hover" @click.prevent="setActiveKeep">
        <img :src="keepData.img" class="card-img-top" alt="..." />
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
