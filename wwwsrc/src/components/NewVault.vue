<template>
  <div id="new-vault">
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#newVaultModal"
    >new vault</button>

    <!-- Modal -->
    <div
      class="modal fade"
      id="newVaultModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="newVaultModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="newVaultModalLabel">New Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addVault">
            <div class="modal-body">
              <div class="form-group">
                <input
                  v-model="newVault.name"
                  type="text"
                  class="form-control"
                  placeholder="name"
                  required
                />
              </div>
              <div class="form-group">
                <textarea
                  v-model="newVault.description"
                  class="form-control"
                  placeholder="description"
                  required
                  rows="3"
                />
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Create Vault</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NewVault",
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  methods: {
    addVault() {
      $("#newVaultModal").modal("hide");
      let vault = { ...this.newVault };
      this.$store.dispatch("addVault", vault);
      this.newVault.name = "";
      this.newVault.description = "";
    }
  }
};
</script>

<style>
</style>