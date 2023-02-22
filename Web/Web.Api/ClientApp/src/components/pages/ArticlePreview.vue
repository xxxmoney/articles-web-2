<template>
    <div class="card card-side max-w-md bg-base-100 shadow-xl" v-if="article">
        <figure class="image-full">
            <img :src="article.image ?? '/src/assets/default_thumb.jpg'" class="w-full h-full object-cover" />
        </figure>
        <div class="card-body gap-3">
            <h2 class="card-title text-2xl">{{ article.title }}</h2>
            <p class="text-sm">{{ contentPreview }}</p>
            <span class="text-xs">{{ $t('common.by') + ': ' + article.user.name + ' ' + article.user.surname }}</span>
            <div class="card-actions justify-end">
                <Button class="" @click="goToDetailAsync">{{ $t('common.detail') }}</Button>
            </div>
        </div>
    </div>
</template>

<script>
    import { computed } from 'vue';
    import { useArticleStore } from '../../store/article';
    import { useRouter } from 'vue-router';

    export default {
        props: {
            id: {
                type: Number,
                required: true
            }
        },
        setup (props) {
            const maxLength = 175;
            const articleStore = useArticleStore();
            const router = useRouter();

            const article = computed(() => articleStore.articles.find(a => a.id === props.id));

            const contentPreview = computed(() => {
                if (article.value) {
                    return article.value.content.substring(0, maxLength) + '...';
                }
                return '';
            });

            const goToDetailAsync = async () => {
                await router.push('/article/' + props.id);
            }

            return {
                article,
                contentPreview,
                goToDetailAsync
            }
        }
    }
</script>
