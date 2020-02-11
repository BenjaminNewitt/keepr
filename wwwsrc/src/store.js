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
  timeout: 8000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: [],
    vaults: []
  },
  mutations: {
    setResource(state, payload) {
      state[payload.name] = payload.data;
    },
    addUserKeep(state, payload) {
      state.userKeeps.push(payload);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setResource", { name: "publicKeeps", data: res.data });
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

    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user");
        commit("setResource", { name: "userKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },

    async addKeep({ commit, dispatch }, keepData) {
      try {
        let res = await api.post("keeps", keepData);
        commit("addUserKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    }
  }
});
