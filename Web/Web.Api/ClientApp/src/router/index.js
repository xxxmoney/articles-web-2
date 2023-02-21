import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../layouts/Main.vue'
import Home from '../pages/Main/Home.vue'
import Login from '../pages/Main/Login.vue'
import Register from '../pages/Main/Register.vue'

const routes = [
  { 
    path: '/', 
    component: MainLayout, 
    children: [
      { name: 'home', path: '', component: Home },  
      { name: 'login', path: 'login', component: Login },
      { name: 'register', path: 'register', component: Register }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
