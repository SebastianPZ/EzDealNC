import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Servicio from './components/Servicio.vue'
import Usuario from './components/Usuario.vue'
import Anuncio from './components/Anuncio.vue'
import Login from './components/Login.vue'
import Registro from './components/Registro.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/servicios',
      name: 'servicios',
      component: Servicio
    },
    {
      path: '/usuarios',
      name: 'usuarios',
      component: Usuario
    },
    {
      path: '/anuncios',
      name: 'anuncios',
      component: Anuncio
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/registro',
      name: 'registro',
      component: Registro
    },
  ]
})
