<template>
  <div class="vault">
    <div class="card mb-5" style="width: 20vw;">
      <div class="card-body">
        <h4 class="card-text">{{ vaultData.name }}</h4>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"]
};
</script>

<style>
</style>