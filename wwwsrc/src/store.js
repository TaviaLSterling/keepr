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
    keeps:[],
    vaults:[],
    vaultKeeps:[]
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
    setKeeps(state,keeps){      
      state.keeps = keeps
    },
    setDash(state,user) {
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
    logout({commit,dispatch})
    {
      auth.delete('logout')
      .then(res => {
        dispatch('logout')
        router.push({name: 'login'})
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

      createKeep({commit,dispatch},data){
        api.post("keeps",data)
        .then(res =>{
          dispatch('getKeeps')
        })
      },
      getKeeps({commit,dispatch}) {
        api.get("keeps")
        .then(res => {
          commit('setKeeps',res.data)
        })
      },
      deleteKeep({dispatch, commit}, id){
        api.delete("keeps/" + id)
        .then(res=>{
          dispatch('getKeeps')
        })
      },

      //// Vault things
      createVault({commit,dispatch,state},vault){
        api.post("/Dash",vault)
        .then(res =>{
          dispatch('getVaults')
        })
      },
      deleteVault({dispatch, commit}, id){
        api.delete('/vaults'+id)
        .then(res=>{
          dispatch('getVaults')
        })
      },
      getVaults({commit,dispatch}) {
        api.get("vaults")
        .then(res => {
          commit('setVaults',res.data)
        })
      }
  }
})