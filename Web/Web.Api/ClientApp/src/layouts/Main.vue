<template>
    <header class="p-6">
        <ul class="flex flex-col md:flex-row items-center gap-4 m-auto max-w-6xl md:sticky">
            <li>
                <router-link to="/"><img src="src/assets/logo.svg" alt="Logo" class="logo"></router-link>
            </li>
            <li class="flex-1"></li>
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
    import { useRouter } from 'vue-router';
    import { computed } from 'vue';
    import LocaleSwitcher from '../components/layout/LocaleSwitcher.vue';

    export default {
        components: {
            LocaleSwitcher
        },
        setup() {
            const authStore = useAuthStore();
            const router = useRouter();

            const isLoggedIn = computed(() => authStore.isLoggedIn);
            const logout = async () => {
                authStore.logout();

                await router.push('/');
            };

            return {
                isLoggedIn,
                logout
            }
        }
    }
</script>

<style>
    #app {        
        padding-block: 1rem;

        display: flex;
        flex-direction: column;
        gap: 2.5rem;
    } 

    header {
        background-color: rgba(54, 54, 54, 0.5);

        border: 1px solid rgba(54, 54, 54, 0.5);
        border-radius: 0.1rem;
        box-shadow: 0 0 0 3px rgba(54, 54, 54, 0.3);        
    }

    .logo {
        width: 2.5rem;
        height: 2.5rem;
    }
</style>
