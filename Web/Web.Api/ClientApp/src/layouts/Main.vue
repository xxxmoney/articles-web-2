<template>
    <header class="p-6 md:sticky md:top-0">
        <ul class="flex flex-col sm:flex-row items-center gap-4 m-auto max-w-6xl">                      
            <li>
                <router-link to="/"><img src="/src/assets/logo.png" alt="Logo" class="logo"></router-link>
            </li>
            <li class="flex-1"></li>
            <li v-if="!isHome">
                <a href="#" @click.prevent="goHomeAsync"><span>{{ $t('main.header.links.home') }}</span></a>
            </li>  
            <li>
                <router-link to="/articles"><span>{{ $t('main.header.links.articles') }}</span></router-link>
            </li>  
            <li class="hidden md:block">|</li>
            <li v-if="!isLoggedIn">
                <router-link to="/login"><span>{{ $t('main.header.links.login') }}</span></router-link>
            </li>
            <li v-if="!isLoggedIn">
                <router-link to="/register"><span>{{ $t('main.header.links.register') }}</span></router-link>
            </li>
            <li v-if="isLoggedIn">
                <router-link to="/profile"><span>{{ $t('main.header.links.profile') }}</span></router-link>
            </li>
            <li v-if="isLoggedIn">
                <a href="" @click.prevent="logout">{{ $t('main.header.links.logout') }}</a>
            </li>
            <li class="hidden md:block">|</li>
            <li>
                <LocaleSwitcher />
            </li>
        </ul>
    </header>

    <main class="flex-1">
        <router-view class="m-auto max-w-6xl" />
    </main>
    
    <footer>
        <ul class="m-auto max-w-6xl"></ul>
    </footer>
</template>

<script>
    import { useAuthStore } from '../store/auth';
    import { useRoute, useRouter } from 'vue-router';
    import { computed } from 'vue';
    import LocaleSwitcher from '../components/layout/LocaleSwitcher.vue';

    export default {
        components: {
            LocaleSwitcher
        },
        setup() {
            const authStore = useAuthStore();
            const router = useRouter();
            const route = useRoute();

            // Computed of whether current route is /.
            const isHome = computed(() => route.path === '/');

            const isLoggedIn = computed(() => authStore.isLoggedIn);
            const logout = async () => {
                authStore.logout();

                await router.push('/');
            };

            // Goes to home page.
            const goHomeAsync = async () => {
                await router.push('/');
            };

            return {
                isLoggedIn,
                isHome,
                goHomeAsync,
                logout
            }
        }
    }
</script>

<style>
    #app {        
        padding-block: 1rem;
        padding-top: 0;

        display: flex;
        flex-direction: column;
        gap: 2.5rem;
    } 

    header {
        background-color: var(--background-secondary);

        border-radius: 0.1rem;     
    }

    .logo {
        width: 3rem;
        height: 3rem;
    }
</style>
