<template>
  <div class="vault">
    <div class="card mb-5" style="width: 20vw;">
      <div class="card-body">
        <p class="card-text">{{ vaultData.name }}</p>
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