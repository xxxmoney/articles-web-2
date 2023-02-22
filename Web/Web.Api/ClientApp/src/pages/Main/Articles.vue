<template>
    <Loading :loaded="loaded" />

    <div v-if="isLoggedIn" class="flex flex-row justify-center gap-3 mb-5">
        <Button icon="pi pi-plus" @click="goToAddArticleAsync" />
    </div>

    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        <ArticlePreview v-for="article in articles" :id="article.id" :key="article.id" class="m-auto" />
    </div>
</template>

<script>
import { useArticleStore } from '../../store/article';
import { useAuthStore } from '../../store/auth';
import { useToast } from 'primevue/usetoast';
import { useI18n } from 'vue-i18n';
import { showError } from '../../helpers/ToastHelper';
import { computed, onMounted } from 'vue';
import Loading from '../../components/ui/Loading.vue';
import { useRouter } from 'vue-router';

export default {
    components: { 
        Loading 
    },
    setup() {
        const articleStore = useArticleStore();
        const authStore = useAuthStore();
        const toast = useToast;
        const { t } = useI18n();
        const router = useRouter();

        const loaded = computed(() => articleStore.loaded);
        const isLoggedIn = computed(() => authStore.isLoggedIn);
        const articles = computed(() => articleStore.articles);

        const getArticlesAsync = async () => {
            try {
                await articleStore.getArticlesAsync();
            }
            catch (error) {
                console.error(error);
                showError(toast, t);
            }
        };

        // Load articles on mounted.
        onMounted(() => {
            getArticlesAsync();
        });
        
        const goToAddArticleAsync = async () => {
            await router.push(`/article`);
        };

        return {
            loaded,
            articles,
            isLoggedIn,
            goToAddArticleAsync
        };
    },
    components: { Loading }
}
</script>

<style scoped>
    :deep(.p-button-icon-only) {
        width: 10rem !important;
    }
</style>
