<template>
    <div class="hero h-full">
        <div class="hero-content flex-col gap-8 lg:flex-row-reverse">
            <!-- <img src="/images/stock/photo-1635805737707-575885ab0820.jpg" class="max-w-sm rounded-lg shadow-2xl" /> -->
            <i class="pi pi-comments extra-big-icon"></i>
            <div>
                <h1 class="text-5xl font-bold">{{ $t('main.pages.home.title') }}</h1>
                <p class="py-6">{{ $t('main.pages.home.subtitle') }}</p>
                <Button :label="$t('main.pages.home.get_started')" @click="goToArticlesAsync" />
            </div>
        </div>
    </div>
</template>

<script>
    import { useRouter } from 'vue-router';

    export default {
        setup() {
            const router = useRouter();

            const goToArticlesAsync = async () => {
                await router.push('/articles');
            };

            return {
                goToArticlesAsync
            };
        }
    }
</script>

<style scoped>
    .extra-big-icon {
        font-size: 8rem;
    }
</style>
