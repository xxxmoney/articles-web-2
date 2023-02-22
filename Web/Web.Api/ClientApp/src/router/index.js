import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../layouts/Main.vue'
import Home from '../pages/Main/Home.vue'
import Login from '../pages/Main/Login.vue'
import Register from '../pages/Main/Register.vue'
import { useAuthStore } from '../store/auth'

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
});

// Check for authentication in before each route.
router.beforeEach((to, from, next) => {
  const authStore = useAuthStore();

  // If auth is required and user is not logged in, redirect to login page.
  if (to.meta.auth && !authStore.isLoggedIn) {
    return next('/login');
  }    

  next();
});

export default router
