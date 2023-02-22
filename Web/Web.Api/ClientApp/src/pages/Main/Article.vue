<template>
    <div>

    </div>
</template>

<script>
import { onMounted } from 'vue';
import { useArticleStore } from '../../store/article';

export default {
    props: {
        id: {
            type: Number,
            default: null
        }
    },
    setup (props) {
        const articleStore = useArticleStore();

        const article = computed(() => articleStore.articles.find(a => a.id === props.id));

        onMounted(async () => {
            // If article is not in store, get it.
            if (!article.value) {
                await articleStore.getArticlesAsync(props.id);
            }
        });

        return {
            article
        }        
    }
}
</script>
