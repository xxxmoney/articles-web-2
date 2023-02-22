<template>
    <Loading :loaded="loaded" />

    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        <ArticlePreview v-for="article in articles" :id="article.id" :key="article.id" class="m-auto" />
    </div>
</template>

<script>
import { useArticleStore } from '../../store/article';
import { useToast } from 'primevue/usetoast';
import { useI18n } from 'vue-i18n';
import { showError } from '../../helpers/ToastHelper';
import { computed, onMounted } from 'vue';
import Loading from '../../components/ui/Loading.vue';

export default {
    components: { 
        Loading 
    },
    setup() {
        const articleStore = useArticleStore();
        const toast = useToast;
        const { t } = useI18n();

        const loaded = computed(() => articleStore.loaded);

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

        return {
            loaded,
            articles
        };
    },
    components: { Loading }
}
</script>
