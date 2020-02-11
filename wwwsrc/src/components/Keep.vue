<template>
  <div class="keep">
    <div class="card" style="width: 20vw;">
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <p
          class="card-text"
        >Some quick example text to build on the card title and make up the bulk of the card's content.</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"]
};
</script>

<style>
</style>