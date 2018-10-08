import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dash from './views/Dash.vue'
//@ts-ignore
import KeepDetails from './components/KeepDetails.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path:'/keeps/:id',
      name:'KeepDetails',
      component:KeepDetails
    },
    {
      path: '/dash',
      name: 'dash',
      component: Dash
    }
  ]
})
