import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../layouts/Main.vue'
import Home from '../pages/Main/Home.vue'

const routes = [
  { 
    path: '/', 
    component: MainLayout, 
    children: [
      { path: '', component: Home },  
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
