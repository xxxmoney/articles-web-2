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
      { path: '', component: Home },  
      { path: 'login', component: Login },
      { path: 'register', component: Register }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
