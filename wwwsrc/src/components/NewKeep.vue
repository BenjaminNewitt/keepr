<template>
  <div id="new-keep">
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#newKeepModal"
    >new keep</button>

    <!-- Modal -->
    <div
      class="modal fade"
      id="newKeepModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="newKeepModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="newKeepModalLabel">New Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addKeep">
            <div class="modal-body">
              <div class="form-group">
                <input
                  v-model="newKeep.name"
                  type="text"
                  class="form-control"
                  placeholder="name"
                  required
                />
              </div>
              <div class="form-group">
                <input
                  v-model="newKeep.description"
                  type="text"
                  class="form-control"
                  placeholder="description"
                  required
                />
              </div>
              <div class="form-group">
                <input
                  v-model="newKeep.img"
                  type="text"
                  class="form-control"
                  placeholder="image URL (optional)"
                />
              </div>
              <div class="custom-control custom-switch text-left mt-3">
                <input
                  v-model="newKeep.isPrivate"
                  type="checkbox"
                  class="custom-control-input"
                  id="privacySwitch"
                />
                <label
                  v-if="this.newKeep.isPrivate"
                  class="custom-control-label"
                  for="privacySwitch"
                >Private</label>
                <label
                  v-else-if="!this.newKeep.isPrivate"
                  class="custom-control-label"
                  for="privacySwitch"
                >Public</label>
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Create Keep</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NewKeep",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: true
      }
    };
  },
  methods: {
    addKeep() {
      $("#newKeepModal").modal("hide");
      let keep = { ...this.newKeep };
      this.$store.dispatch("addKeep", keep);
      this.newKeep.name = "";
      this.newKeep.description = "";
      this.newKeep.img = "";
      this.newKeep.isPrivate = true;
    }
  }
};
</script>

<style>
</style>