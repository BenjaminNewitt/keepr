<template>
  <div class="keep">
    <div class="card mb-5" style="width: 20vw;">
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <p class="card-text">{{ keepData.description }}</p>
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

<style></style>
