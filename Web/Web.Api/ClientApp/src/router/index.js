import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '../store/auth'
import MainLayout from '../layouts/Main.vue'
import Home from '../pages/Main/Home.vue'
import Login from '../pages/Main/Login.vue'
import Register from '../pages/Main/Register.vue'
import Articles from '../pages/Main/Articles.vue'
import Article from '../pages/Main/Article.vue'
import User from '../pages/Main/User.vue'

const routes = [
  { 
    path: '/', 
    component: MainLayout, 
    children: [
      { name: 'home', path: '', component: Home },  
      { name: 'login', path: 'login', component: Login },
      { name: 'register', path: 'register', component: Register },
      { name: 'articles', path: 'articles', component: Articles },
      { name: 'article', path: 'article/:id?', component: Article },
      { name: 'user', path: 'user/:id?', component: User },
      { name: 'profile', path: 'profile', component: User }
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
