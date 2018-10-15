import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    logout(state, user) {
      state.user = {}
      router.push({ name: 'login' })
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    },
    setDash(state, user) {
      state.user = user
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          dispatch('logout')
          router.push({ name: 'login' })
        })
    },
    getDash({ commit, dispatch }) {
      api.get('dash')
        .then(res => {
          commit('setDash', res.data)
          router.push({ name: 'dash' })
        })
        .catch(e => {
          console.log('Must Login')
        })
    },


    ////// Keeps Things

    createKeep({ commit, dispatch }, data) {
      api.post("keeps", data)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get("keeps")
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    editKeep({ dispatch, commit }, id) {
      api.put("keeps/" + id)
        .then(res => {
          commit('setKeeps', res.data.keeps)
        })
    },
    deleteKeep({ dispatch, commit }, keepId) {
      api.delete("keeps/" + keepId)
        .then(res => {
          dispatch('getKeeps')
        })
        .catch(err => {
          console.log(err)
        })
    },
    saveKeep({ commit, dispatch }, keep) {
      api.post("vaultKeeps/")
      dispatch("saveVaultKeep", keep)
      
    },

    //// Vault things
    createVault({ commit, dispatch }, vault) {
      api.post("vaults", vault)
        .then(res => {
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
    },
    getVaults({ commit, dispatch }) {
      api.get("vaults")
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    editVault({ dispatch, commit }, vaultId) {
      api.put('vaults/' + vaultId)
        .then(res => {
          commit('setVaults', res.data.vaults)
        })
    },
    //// VaultKeep things

    savedVaultKeep({ commit, dispatch }, vaultKeep) {
      api.post('vaultKeeps', vaultKeep)
      .then(res =>{
        commit('setVaultKeeps')
      })
    },
    getVaultKeeps({ commit, dispatch },vaultData) {
      api.get('vaultkeeps/' + vaultData)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    createVaultKeep({ commit, dispatch }, data) {
      api.post("vaultkeeps", data)
        .then(res => {
          commit('setVaultKeeps')
        })
    },
    deleteVaultKeep({ commit, dispatch }, data) {
      api.delete('vaultKeeps/vaults/' + data.vaultId + "/keeps/" + data.keepId)
        .then(res => {
          dispatch('getVaultKeeps', data.vaultId)
        })
    },
  }
})