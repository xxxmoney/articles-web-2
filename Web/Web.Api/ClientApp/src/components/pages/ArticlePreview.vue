<template>
    <div class="card max-w-md bg-base-100 shadow-xl" v-if="article">
        <figure class="image-full h-52 cursor-pointer" @click="goToDetailAsync">
            <Image :withImagesPath="true" :src="article.pictureName" class="object-cover" />
        </figure>
        <div class="card-body gap-3">
            <h2 class="card-title text-2xl">{{ article.title }}</h2>
            <p class="text-sm" v-html="contentPreview"></p>
            <div>
                <span class="inline mr-2">{{ $t('common.by') }}:</span>
                <span class="inline text-xs cursor-pointer text-hover-highlight" @click="goToUserAsync">{{ article.user.name + ' ' + article.user.surname }}</span>
            </div>
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
    import Image from '../ui/Image.vue';

    export default {
        components: {
            Image
        },
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
                await router.push('/article/' + article.value.id);
            }
            const goToUserAsync = async () => {
                await router.push('/profile/' + article.value.user.id);
            }

            return {
                article,
                contentPreview,
                goToDetailAsync,
                goToUserAsync
            }
        }
    }
</script>
