import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 15000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: [],
    vaults: [],
    vaultKeeps: [],
    activeKeep: {},
    activeVault: {}
  },
  mutations: {
    setResource(state, payload) {
      state[payload.name] = payload.data;
    },
    addUserKeep(state, payload) {
      state.userKeeps.push(payload);
    },
    addVault(state, payload) {
      state.vaults.push(payload);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    // NOTE Get requests
    //#region
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setResource", { name: "publicKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },

    async getKeepById({ commit, dispatch }, id) {
      try {
        let res = await api.get("keeps/" + id);
        commit("setResource", { name: "activeKeep", data: res.data });
        router.push({
          name: "keepDetails",
          params: { id: res.data.id }
        });
      } catch (error) {
        console.error(error);
      }
    },

    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user");
        commit("setResource", { name: "userKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },

    async getKeepsByVaultId({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaultkeeps/" + id + "/Keeps");
        commit("setResource", { name: "vaultKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },

    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit("setResource", { name: "vaults", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },

    async getVaultById({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaults/" + id);
        commit("setResource", { name: "activeVault", data: res.data });
        router.push({
          name: "vaultDetails",
          params: { id: res.data.id }
        });
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion

    // NOTE Post requests
    //#region
    async addKeep({ commit, dispatch }, keepData) {
      try {
        let res = await api.post("keeps", keepData);
        commit("addUserKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async addVault({ commit, dispatch }, vaultData) {
      try {
        let res = await api.post("vaults", vaultData);
        commit("addVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async addVaultKeep({ commit, dispatch }, vaultKeepData) {
      try {
        let res = await api.post("vaultkeeps", vaultKeepData);
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion
    // NOTE Put requests
    //#region

    //#endregion
    // NOTE Delete requests
    //#region
    async deleteUserKeep({ commit, dispatch }, keepId) {
      try {
        let res = await api.delete("keeps/" + keepId);
        dispatch("getUserKeeps");
      } catch (error) {
        console.error(error);
      }
    },

    async deleteVault({ commit, dispatch }, vaultId) {
      try {
        let res = await api.delete("vaults/" + vaultId);
        // TODO Remove vault from state instead of getVaults?
        dispatch("getVaults");
      } catch (error) {
        console.error(error);
      }
    },

    async RemoveKeepFromVault({ commit, dispatch }, payload) {
      try {
        let res = await api.delete(
          "vaultkeeps/" + payload.vaultId + "/keeps/" + payload.keepId
        );
        dispatch("getKeepsByVaultId", payload.vaultId);
      } catch (error) {
        console.error(error);
      }
    }
    //#endregion
  }
});
